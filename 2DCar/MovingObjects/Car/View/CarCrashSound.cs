using CarGame.Utilities;
using CSCore.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarGame.MovingObjects.Car.View
{
    public static class CarCrashSound
    {
        private static LoopingPitchable soundSource;

        public static void Play()
        {
            soundSource = new("Resources/carCrash.wav", SoundChannelType.Mono, false);
            soundSource.GainDB = -5;
            soundSource.Start();
        }
    }
}
