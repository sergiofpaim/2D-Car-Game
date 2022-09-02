using GameEngine.Interfaces;

namespace GameEngine.Physics
{
    public class CartesianPoint : ICartesianPoint
    {
        public CartesianPoint() : this(0, 0)
        {
        }

        public CartesianPoint(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; set; } = 0;
        public float Y { get; set; } = 0;


		public float Magnitude
		{
			get { return (float)Math.Sqrt(X * X + Y * Y); }
		}

		public void Normalize()
		{
			float magnitude = Magnitude;
			X = X / magnitude;
			Y = Y / magnitude;
		}

		public CartesianPoint GetNormalized()
		{
			float magnitude = Magnitude;

			return new CartesianPoint(X / magnitude, Y / magnitude);
		}

		public float DotProduct(CartesianPoint CartesianPoint)
		{
			return this.X * CartesianPoint.X + this.Y * CartesianPoint.Y;
		}

		public float DistanceTo(CartesianPoint CartesianPoint)
		{
			return (float)Math.Sqrt(Math.Pow(CartesianPoint.X - this.X, 2) + Math.Pow(CartesianPoint.Y - this.Y, 2));
		}

		public static implicit operator Point(CartesianPoint p)
		{
			return new Point((int)p.X, (int)p.Y);
		}

		public static implicit operator PointF(CartesianPoint p)
		{
			return new PointF(p.X, p.Y);
		}

		public static CartesianPoint operator +(CartesianPoint a, CartesianPoint b)
		{
			return new CartesianPoint(a.X + b.X, a.Y + b.Y);
		}

		public static CartesianPoint operator -(CartesianPoint a)
		{
			return new CartesianPoint(-a.X, -a.Y);
		}

		public static CartesianPoint operator -(CartesianPoint a, CartesianPoint b)
		{
			return new CartesianPoint(a.X - b.X, a.Y - b.Y);
		}

		public static CartesianPoint operator *(CartesianPoint a, float b)
		{
			return new CartesianPoint(a.X * b, a.Y * b);
		}

		public static CartesianPoint operator *(CartesianPoint a, int b)
		{
			return new CartesianPoint(a.X * b, a.Y * b);
		}

		public static CartesianPoint operator *(CartesianPoint a, double b)
		{
			return new CartesianPoint((float)(a.X * b), (float)(a.Y * b));
		}

		public override bool Equals(object obj)
		{
			CartesianPoint v = (CartesianPoint)obj;

			return X == v.X && Y == v.Y;
		}

		public bool Equals(CartesianPoint v)
		{
			return X == v.X && Y == v.Y;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}

		public static bool operator ==(CartesianPoint a, CartesianPoint b)
		{
			return a.X == b.X && a.Y == b.Y;
		}

		public static bool operator !=(CartesianPoint a, CartesianPoint b)
		{
			return a.X != b.X || a.Y != b.Y;
		}

		public override string ToString()
		{
			return X + ", " + Y;
		}

		public string ToString(bool rounded)
		{
			if (rounded)
			{
				return (int)Math.Round(X) + ", " + (int)Math.Round(Y);
			}
			else
			{
				return ToString();
			}
		}
	}
}