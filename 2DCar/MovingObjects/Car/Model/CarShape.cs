using GameEngine.Interfaces;
using GameEngine.Physics;

namespace MovingObjects.Car
{
    internal class CarShape
    {
        private readonly float bumpersSize;

        public CartesianPoint FrontLeft { get; private set; }
        public CartesianPoint RearLeft { get; private set; }
        public CartesianPoint RearRight { get; private set; }
        public CartesianPoint FrontRight { get; private set; }
        public List<ICartesianPoint> Points => new() { FrontLeft, RearLeft, RearRight, FrontRight, FrontLeft };

        public List<ICartesianPoint> FrontSides => Points;

        public CarShape(float directionInRadians, float wheelBase, float lenghtInMeters, float widthInMeters)
        {
            bumpersSize = (lenghtInMeters - wheelBase) / 2;

            //Considering a direction 0 (to the right)
            float rearBumper = - bumpersSize;
            float frontBumper = wheelBase + bumpersSize;
            float leftSide = widthInMeters / 2;
            float rightSide = - widthInMeters / 2;

            FrontLeft = RotateBy(new(frontBumper, leftSide), directionInRadians);
            RearLeft = RotateBy(new(rearBumper, leftSide), directionInRadians);
            RearRight = RotateBy(new(rearBumper, rightSide), directionInRadians);
            FrontRight = RotateBy(new(frontBumper, rightSide), directionInRadians);

        }

        private static CartesianPoint RotateBy(CartesianPoint point, float radians)
        {
            float X = point.X;
            float Y = point.Y;  

            point.X = (float)(Math.Cos(-radians) * X - Math.Sin(-radians) * Y);
            point.Y = (float)(Math.Sin(-radians) * X + Math.Cos(-radians) * Y);

            return point;
        }
    }
}
