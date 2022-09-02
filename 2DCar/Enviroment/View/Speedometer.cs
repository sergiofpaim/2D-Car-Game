using GameEngine.Interfaces;
using MovingObjects.Car;
using GameEngine.Utilities;

namespace Enviroment.View
{
    public partial class Speedometer : UserControl, IUISchedule
    {
        private const double MAX_GAP = 0.2;
        private const float DEGREES_PER_KMH = -1.8F;

        public float lastSpeed = 0;
        private float imageAngle = 0;

        private CarChassis chassis;
        private readonly Image picture;

        public Speedometer()
        {
            InitializeComponent();
            picture = speedMark.BackgroundImage;
            speedometerCar.Controls.Add(speedMark);
        }

        public void Run(bool byStep)
        {
            if (Math.Abs(lastSpeed - chassis.Speed) >= MAX_GAP)
            {
                lastSpeed = chassis.Speed;

                var speedToRender = (Math.Abs(chassis.Speed) * TwoDWorld.MPS_TO_KMH * DEGREES_PER_KMH);
                imageAngle = speedToRender;
                speedMark.BackgroundImage = ImageHelper.Rotate(picture, imageAngle);
                speedBox.Text = $"{Math.Abs(Math.Round(chassis.Speed * TwoDWorld.MPS_TO_KMH))}";
            }
        }

        public void Restart()
        {
            Run(false);
        }

        internal void SetSpeedometer(Car car)
        {
            chassis = car.Position.Movement.Chassis;
        }

        public void Stop() { }
    }
}
