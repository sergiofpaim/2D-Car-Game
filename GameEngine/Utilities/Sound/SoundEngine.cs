using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;

namespace GameEngine.Utilities
{
    public static class SoundEngine
    {
        private static WasapiOut? soundOut;
        private static SourceMixer mixer = new(44100) //44,1 KHz
                                               {
                                                   FillWithZeros = false,
                                                   DivideResult = true //This is set to true for avoiding tick sounds because of exceeding -1 and 1
                                               };
        public static bool Active => soundOut is not null;

        public static bool Play()
        {
            try
            {
                if (!Active)
                {
                    MMDevice? outputDevice = new MMDeviceEnumerator()?.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active)
                                                                      .FirstOrDefault();
                    if (outputDevice is null)
                        return false;

                    //Init sound play device with a latency of 5 ms.
                    soundOut = new(false, AudioClientShareMode.Exclusive, 5)
                    {
                        Device = outputDevice
                    };

                    soundOut.Initialize(mixer.ToWaveSource(16));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while setting up output device", ex);
            }

            //Start rolling!
            soundOut?.Play();

            return true;
        }

        public static bool Stop()
        {
            if (!Active)
                return false;

            soundOut?.Stop();
            soundOut?.Dispose();
            soundOut = null;

            return true;
        }

        public static void AddSource(ISampleSource source, SoundChannelType channel = SoundChannelType.Mono) 
        {
            mixer.AddSource(source.ChangeSampleRate(mixer.WaveFormat.SampleRate), channel);
        }

        public static void RemoveSource(ISampleSource source) 
        {
            mixer.RemoveSource(source);
        }
    }
}
