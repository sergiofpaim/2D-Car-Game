using GameEngine.Interfaces;
using MovingObjects.Car;
using GameEngine.Utilities;

namespace Enviroment.View
{
    public partial class SteeringWheel : UserControl, IUISchedule
    {
        public float steeringToRender = 0;
        private const int MAX_GAP = 1;
        private float imageAngle = 0;

        private CarChassis chassis;
        private readonly Image picture;

        public SteeringWheel()
        {
            InitializeComponent();
            picture = carSteeringWheel.Image;
        }

        public void Run(bool byStep)
        {
            if (Math.Abs(steeringToRender - chassis.SteeringAngle) > MAX_GAP)
            {
                steeringToRender = chassis.SteeringAngle;
                imageAngle = steeringToRender;
                carSteeringWheel.Image = ImageHelper.Rotate(picture, imageAngle);
            }
        }

        public void Restart()
        {
            Run(false);
        }

        internal void SetSteeringWheel(Car car)
        {
            chassis = car.Position.Movement.Chassis;
        }

        public void Stop() { }
    }
}
