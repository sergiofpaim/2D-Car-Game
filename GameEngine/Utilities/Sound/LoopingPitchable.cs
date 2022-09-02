using CSCore;
using CSCore.Codecs;

namespace GameEngine.Utilities
{
    public class LoopingPitchable: ISampleSource
    {
        private readonly ISampleSource? source;
        private SoundChannelType channelType;
        private bool looping;
        private bool playing = false;

        public LoopingPitchable(string fileName, SoundChannelType type = SoundChannelType.Mono, bool looping = true)
        {
            try
            {
                channelType = type;
                if (type != SoundChannelType.Stereo)
                    source = CodecFactory.Instance.GetCodec(fileName).ToSampleSource().ToMono();
                else 
                    source = CodecFactory.Instance.GetCodec(fileName).ToSampleSource();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException($"The sound file '{nameof(fileName)}' couldn't be found or decoded", ex);
            }

            PitchShift = 1;
            this.looping = looping;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            return ReadContinuous(buffer, offset, 0, count);
        }

        private int ReadContinuous(float[] buffer, int readOffset, int resumingOffset, int count)
        {
            if (!playing)
                return 0;

            float gainAmplification = (float)(Math.Pow(10.0, GainDB / 20.0));
            int samples = source.Read(buffer, readOffset, count);
            if (gainAmplification != 1.0f)
            {
                for (int i = readOffset; i < readOffset + samples; i++)
                {
                    buffer[i + resumingOffset] = Math.Max(Math.Min(buffer[i + resumingOffset] * gainAmplification, 1), -1);
                }
            }

            if (PitchShift != 1.0f)
                PitchShifter.PitchShift(PitchShift, resumingOffset, count, 2048, 4, source.WaveFormat.SampleRate, buffer);

            if (samples < count && looping)
            {
                source.Position = 0;
                samples += ReadContinuous(buffer, 0, resumingOffset + samples + 1, count - samples);
            }

            return samples;
        }
        public float GainDB { get; set; } = 0;

        public float PitchShift { get; set; } = 1;

        public bool CanSeek
        {
            get { return source?.CanSeek == true; }
        }

        public WaveFormat WaveFormat
        {
            get { return source?.WaveFormat ?? new WaveFormat(); }
        }

        public long Position
        {
            get
            {
                return source?.Position ?? 0;
            }
            set
            {
                if (source is not null)
                    source.Position = value;
            }
        }

        public long Length
        {
            get { return source?.Length ?? 0; }
        }

        public bool Looping { get => looping; set => looping = value; }

        public void Dispose()
        {
            if (source != null) source.Dispose();
        }

        public void Stop()
        {
            playing = false;
        }

        public void Start()
        {
            SoundEngine.AddSource(this, channelType);
            playing = true;
        }
    }
}