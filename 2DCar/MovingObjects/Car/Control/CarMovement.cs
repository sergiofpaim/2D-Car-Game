using CarGame.Enviroment;
using CarGame.Physics;

namespace CarGame.MovingObjects.Car
{
    public class CarMovement
    {
        private const float STEERING_INCREMENT_PER_SECOND = 150;
        private const float STEERING_IDLE = 100;
        private float STEERING_IDLE_CENTER_IN_DEGREES = STEERING_INCREMENT_PER_SECOND / 2000 * Scheduler.LoopInterval;

        public readonly ControlType controlType;

        public CarPowerTrain PowerTrain { get; private set; }
        public CarChassis Chassis { get; internal set; }

        public bool GasPedal { get; private set; } = false;
        public bool BreakPedal { get; private set; } = false;

        public CarMovement(ControlType controlType, float wheelBase)
        {
            this.controlType = controlType;
            Chassis = new CarChassis(wheelBase);
            PowerTrain = new();
        }

        public Location NextPosition(Location current)
        {
            var inputs = GamingControl.Inputs(controlType);

            Location nextPosition = current;

            if (inputs.Contains(InputValue.Left) &&
                !inputs.Contains(InputValue.Right))
                Chassis.SteeringAngle += STEERING_INCREMENT_PER_SECOND * Scheduler.LoopInterval / 1000;
            else if (!inputs.Contains(InputValue.Left) &&
                     inputs.Contains(InputValue.Right))
                Chassis.SteeringAngle -= STEERING_INCREMENT_PER_SECOND * Scheduler.LoopInterval / 1000;
            else
            {
                if (Chassis.SteeringAngle < 0)
                    Chassis.SteeringAngle += STEERING_IDLE * Scheduler.LoopInterval / 1000;
                else if (Chassis.SteeringAngle > 0)
                    Chassis.SteeringAngle -= STEERING_IDLE * Scheduler.LoopInterval / 1000;
                if (STEERING_IDLE_CENTER_IN_DEGREES > Math.Abs(Chassis.SteeringAngle))
                    Chassis.SteeringAngle = 0;
            }

            GasPedal = inputs.Contains(InputValue.Foward);
            BreakPedal = inputs.Contains(InputValue.Backward);

            if (GasPedal && !BreakPedal)
                Chassis.Speed = PowerTrain.Accelerate();
            if (!GasPedal && BreakPedal)
                Chassis.Speed = PowerTrain.Break();

            else if (!GasPedal && !BreakPedal)
            {
                if (Chassis.Speed < 0)
                    Chassis.Speed = PowerTrain.Idle();
                else if (Chassis.Speed >= 0)
                    Chassis.Speed = PowerTrain.Idle();
            }

            float displacement = Chassis.Speed * Scheduler.LoopInterval / 1000;

            nextPosition.DirectionInDegrees += Chassis.RotationAngle;

            nextPosition.Point.X += (float)(Math.Cos(nextPosition.DirectionInRadians) * displacement);
            nextPosition.Point.Y += (float)(Math.Sin(nextPosition.DirectionInRadians) * displacement);

            return nextPosition;
        }

        internal void Restart()
        {
            Chassis = new CarChassis(Chassis.WheelBase);
            PowerTrain = new();
        }

    }
}
