using CarGame.Enviroment;
using CarGame.Interfaces;
using CarGame.Physics;
using System.Linq;

namespace CarGame.MovingObjects.Car
{
    public class CarLocation : ISchedule, IMovingObject
    {
        public readonly float WhellBaseInMeters = 1F;
        public readonly float LenghtInMeters = 1.7F;
        public readonly float WidthInMeters = 1.1F;

        private Location previousLocation;
        private Location currentLocation;
        private readonly Location startingLocation;
        private readonly CarMovement movement;

        private CarShape currentShape;

        public string Id { get; private set; }
        public CarLocation(string id, ControlType controlType, Location startAt)
        {
            Id = id;
            startingLocation = startAt;
            currentLocation = startingLocation.Clone();

            movement = new(controlType, WhellBaseInMeters);

            CalculateShapeFor(startAt);
            CollisionDetector.Register(this);
        }

        public CarMovement Movement { get => movement; }
        public Location Location { get => currentLocation; }
        public Location PreviousLocation { get => previousLocation; }

        public List<ICartesianPoint> Shape => currentShape.Points.Select(p => (p as CartesianPoint) + Location.Point as ICartesianPoint)
                                                                 .ToList();

        public Side ActiveSide
        {
            get
            {
                Side activeSides = new();
                if (movement.Chassis.Speed >= 0)
                {
                    activeSides.A = currentShape.FrontRight + Location.Point;
                    activeSides.B = currentShape.FrontLeft + Location.Point;
                }
                else 
                {
                    activeSides.A = currentShape.RearRight + Location.Point;
                    activeSides.B = currentShape.RearLeft + Location.Point;
                }
                return activeSides;
            }
        }

        public bool CollidedOntoMoving { get; private set; } = false;

        public bool CollidedOntoStatic { get; private set; } = false;

        public bool CollidedBy { get; private set; } = false;

        public void Restart()
        {
            currentLocation = startingLocation.Clone();
            previousLocation = currentLocation;

            CollidedBy = false;
            CollidedOntoMoving = false;
            CollidedOntoStatic = false;

            CalculateShapeFor(currentLocation);
            movement.Restart();
        }

        public void Run(bool byStep)
        {
            previousLocation = currentLocation;
            currentLocation = movement.NextPosition(currentLocation);
            CalculateShapeFor(currentLocation);
        }

        private void CalculateShapeFor(Location position)
        {
            currentShape = new CarShape(-position.DirectionInRadians, WhellBaseInMeters, LenghtInMeters, WidthInMeters);
        }

        public void HandleCollisionOnto(List<IMovingObject> movingObjects, List<IStaticObject> staticObjects)
        {
            if (movingObjects.Count > 0)
                CollidedOntoMoving = true;

            if (staticObjects.Count > 0)
                CollidedOntoStatic = true;
        }

        public void HandleCollisionBy(IMovingObject movingObject)
        {
            CollidedBy = true;
        }
    }
}