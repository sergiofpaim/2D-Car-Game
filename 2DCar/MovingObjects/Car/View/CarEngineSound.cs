using CarGame.Interfaces;
using CarGame.Utilities;

namespace CarGame.MovingObjects.Car
{
    internal class CarEngineSound : IEngineSound
    {
        private readonly SoundChannelType channel;
        private readonly float minRpm;
        private readonly float maxRpm;
        private float rpm;

        internal SoundChannelType Channel => channel;

        public float Rpm
        {
            get => rpm; set
            {
                RpmChange(value);
            }
        }

        private LoopingPitchable soundSource;

        public CarEngineSound(SoundChannelType channel, string engineSampleFile, float minRpm, float maxRpm)
        {
            if (minRpm < 0 || minRpm > maxRpm)
                throw new ArgumentException($"{nameof(minRpm)} must be less than all the other rpm parameters");

            this.minRpm = minRpm;
            this.maxRpm = maxRpm;
            this.channel = channel;
            soundSource = new(engineSampleFile, channel);
        }

        public void RpmChange(float newRpm)
        {
            bool changed = false;
            const float MIN_PITCH = -8f;
            const float MAX_PITCH = 12f;
            const float MIN_PITCH_CHANGE = .01f;
            const float OCTAVES = 12f;

            if (newRpm < minRpm || newRpm > maxRpm)
                throw new ArgumentException($"'{nameof(newRpm)} must be between '{nameof(minRpm)}' and {nameof(maxRpm)}'");

            //To be implemented (to sound according to the gas pedal)
            if (rpm < newRpm)
            {
                //To be implemented: sound like accelerating the engine
                changed = Math.Abs(1 - rpm / newRpm) > MIN_PITCH_CHANGE;
            }
            else if (rpm > newRpm)
            {
                //To be implemented: souncds like slowing the engine
                changed = Math.Abs(1 - newRpm / rpm) > MIN_PITCH_CHANGE;
            }
            else
            {
                //To be implemented: sounds like an engine in the same rpm
            }

            if (changed)
            {
                rpm = newRpm;

                soundSource.PitchShift = (float)Math.Pow(2F, ((rpm - minRpm) / (maxRpm - minRpm) *
                                                              (MAX_PITCH - MIN_PITCH) + MIN_PITCH) / OCTAVES);
            }
        }

        public void Start()
        {
            rpm = minRpm;
            soundSource.GainDB = 2;
            soundSource.Start();
        }

        public void Stop()
        {
            soundSource.Stop();
        }
    }
}
