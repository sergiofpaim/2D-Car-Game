using GameEngine.Interfaces;
using MovingObjects.Car;
using GameEngine.Utilities;

namespace Enviroment.View
{
    public partial class Tachometer : UserControl, IUISchedule
    {
        private const int MAX_GAP = 80;
        private const int INITIAL_ROTATION_ANGLE = 50;
        private const int DEGREES_PER_RPM = -30;

        public float lastRPM = 0;
        private float imageAngle = 0;

        private CarPowerTrain carPowerTrain;
        private readonly Image picture;

        public Tachometer()
        {
            InitializeComponent();
            picture = tachometerMark.BackgroundImage;
            tachometerNumbers.Controls.Add(tachometerMark);
        }

        public void Run(bool byStep)
        {
            if (Math.Abs(lastRPM - carPowerTrain.RPM) >= MAX_GAP)
            {
                lastRPM = carPowerTrain.RPM;

                var rpmToRender = INITIAL_ROTATION_ANGLE + (carPowerTrain.RPM / 1000 * DEGREES_PER_RPM);
                imageAngle = rpmToRender;
                tachometerMark.BackgroundImage = ImageHelper.Rotate(picture, imageAngle);
                tachometerBox.Text = $"{Math.Abs(Math.Round(carPowerTrain.RPM / 1000, 1))}";
            }
        }

        public void Restart()
        {
            Run(false);
        }

        internal void SetTachometer(Car car)
        {
            carPowerTrain = car.Position.Movement.PowerTrain;
        }

        public void Stop() { }
    }
}
