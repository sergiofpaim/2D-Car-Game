namespace GameEngine.Physics
{
    public class Location
    {
        private float direction = 0;

        public Location() {}
        public Location(float x, float y)
        {
            Point.X = x;
            Point.Y = y; 
        }
        public Location(float x, float y, float direction)
        {
            Point.X = x;
            Point.Y = y; 
            DirectionInDegrees = direction;  
        }

        public CartesianPoint Point { get; set; } = new();

        public float DirectionInDegrees
        {
            get => direction;
            set
            {
                if (value >= 360)
                    direction = value % 360;  
                else if (value < 0)
                    direction = value % 360 + 360;
                else
                    direction = value;       
            }

        }

        public Location Clone()
        {
            return new(Point.X, Point.Y, direction);
        }

        public float DirectionInRadians => (float) (Math.PI * direction / 180);
    }
}
