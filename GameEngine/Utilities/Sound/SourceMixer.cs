using CSCore;
using System.Linq.Expressions;

namespace GameEngine.Utilities
{
    public class SourceMixer : ISampleSource
    {
        private readonly WaveFormat waveFormat;
        private readonly List<(ISampleSource source, SoundChannelType type)> sampleSources = new();
        private readonly object lockObj = new();
        private float[]? mixerBuffer;

        public bool FillWithZeros { get; set; }

        public bool DivideResult { get; set; }

        public SourceMixer(int sampleRate)
        {
            if(sampleRate < 1)
                throw new ArgumentOutOfRangeException(nameof(sampleRate));

            waveFormat = new WaveFormat(sampleRate, 32, 2, AudioEncoding.WindowsMediaAudio);
            FillWithZeros = false;
        }

        public void AddSource(ISampleSource source, SoundChannelType type = SoundChannelType.Mono)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (source.WaveFormat.Channels > 1 && type != SoundChannelType.Stereo)
                throw new ArgumentException("Non-stereo source should have only one channel.", "source");
            
            if (source.WaveFormat.Channels == 1 && type == SoundChannelType.Stereo)
                throw new ArgumentException("Stereo source should have 2 channels.", "source");

            if (source.WaveFormat.SampleRate != WaveFormat.SampleRate)
                throw new ArgumentException("Invalid format.", "source");

            lock (lockObj)
            {
                if (!Contains(source))
                    sampleSources.Add((source, type));
            }
        }

        public void RemoveSource(ISampleSource source)
        {
            //don't throw null ex here
            lock (lockObj)
            {
                if (Contains(source))
                    sampleSources.RemoveAll(s => s.source == source);
            }
        }

        public bool Contains(ISampleSource source)
        {
            if (source == null)
                return false;
            return sampleSources.Any(s => s.source == source);
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int numberOfStoredSamples = 0;

            if (count > 0 && sampleSources.Count > 0)
            {
                lock (lockObj)
                {
                    mixerBuffer = mixerBuffer.CheckBuffer(count);
                    List<int> numberOfReadSamples = new List<int>();
                    for (int m = sampleSources.Count -1; m >= 0; m--)
                    {
                        var sampleSource = sampleSources[m];
                        int read = 0;

                        switch (sampleSource.type)
                        {
                            case SoundChannelType.Stereo:
                                read = sampleSource.source.Read(mixerBuffer, 0, count);
                                for (int i = offset, n = 0; n < read; i++, n++)
                                    if (i <= numberOfStoredSamples)
                                        buffer[i] += mixerBuffer[n];
                                    else
                                        buffer[i] = mixerBuffer[n];
                                break;
                            case SoundChannelType.Mono:
                                read = sampleSource.source.Read(mixerBuffer, 0, count / 2);
                                for (int i = offset, n = 0; n < read; i += 2, n++)
                                    if (i <= numberOfStoredSamples)
                                    {
                                        buffer[i] += mixerBuffer[n];
                                        buffer[i + 1] += mixerBuffer[n];
                                    }
                                    else
                                    {
                                        buffer[i] = mixerBuffer[n];
                                        buffer[i + 1] = mixerBuffer[n];
                                    }
                                break;
                            case SoundChannelType.Left:
                                read = sampleSource.source.Read(mixerBuffer, 0, count / 2);
                                for (int i = offset, n = 0; n < read; i += 2, n++)
                                    if (i <= numberOfStoredSamples)
                                        buffer[i] += mixerBuffer[n];
                                    else
                                        buffer[i] = mixerBuffer[n];
                                break;
                            case SoundChannelType.Right:
                                read = sampleSource.source.Read(mixerBuffer, 0, count / 2);
                                for (int i = offset, n = 0; n < read; i += 2, n++)
                                    if (i <= numberOfStoredSamples)
                                        buffer[i + 1] += mixerBuffer[n];
                                    else
                                        buffer[i + 1] = mixerBuffer[n];
                                break;
                        }

                        if (sampleSource.type == SoundChannelType.Stereo)
                        {
                            if (read > numberOfStoredSamples)
                                numberOfStoredSamples = read;

                            if (read > 0)
                                numberOfReadSamples.Add(read);
                        }
                        else 
                        { 
                            if (read * 2 > numberOfStoredSamples)
                                numberOfStoredSamples = read * 2;

                            if (read * 2 > 0)
                                numberOfReadSamples.Add(read * 2);
                        }

                            //raise event here
                        if (read == 0)
                            RemoveSource(sampleSource.source); //remove the input to make sure that the event gets only raised once.
                    }

                    if (DivideResult)
                    {
                        numberOfReadSamples.Sort();
                        int currentOffset = offset;
                        int remainingSources = numberOfReadSamples.Count;

                        foreach (var readSamples in numberOfReadSamples)
                        {
                            if (remainingSources == 0)
                                break;

                            while (currentOffset < offset + readSamples)
                            {
                                buffer[currentOffset] /= remainingSources;
                                buffer[currentOffset] = Math.Max(-1, Math.Min(1, buffer[currentOffset]));
                                currentOffset++;
                            }
                            remainingSources--;
                        }
                    }
                }
            }

            if (FillWithZeros && numberOfStoredSamples != count)
            {
                Array.Clear(
                    buffer,
                    Math.Max(offset + numberOfStoredSamples - 1, 0),
                    count - numberOfStoredSamples);

                return count;
            }

            return numberOfStoredSamples;
        }

        public bool CanSeek { get { return false; } }

        public WaveFormat WaveFormat
        {
            get { return waveFormat; }
        }

        public long Position
        {
            get { return 0; }
            set
            {
                throw new NotSupportedException();
            }
        }

        public long Length
        {
            get { return 0; }
        }

        public void Dispose()
        {
            lock (lockObj)
            {
                foreach (var sampleSource in sampleSources.ToArray())
                {
                    sampleSource.source.Dispose();
                    RemoveSource(sampleSource.source);
                }
            }
        }
    }
}
