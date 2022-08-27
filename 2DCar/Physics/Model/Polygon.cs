using CarGame.Interfaces;

namespace CarGame.Physics
{
	public class Polygon
	{
		public static bool IsInside(ICartesianPoint point, List<ICartesianPoint> shape)
		{
			var inside = false;
			for (int i = shape.Count - 1, j = 0; j < shape.Count; i = j++)
			{
				var p1 = shape[i];
				var p2 = shape[j];

				if ((p1.Y < point.Y != p2.Y < point.Y) && //at least one point is below the Y threshold and the other is above or equal
					(p1.X >= point.X || p2.X >= point.X)) //optimisation: at least one point must be to the right of the test point
				{
					if (p1.X + (point.Y - p1.Y) / (p2.Y - p1.Y) * (p2.X - p1.X) > point.X)
						inside = !inside;
				}
			}
			return inside;
		}

		public static bool IsCollidingOnto(IMovingObject objectA, IStaticObject objectB)
		{
			for (int i = 0; i < objectA.Shape.Count - 1; i++)
				for (int j = 0; j < objectB.Shape.Count - 1; j++)
					if (CalculateIntersection(objectA.Shape[i],
											  objectA.Shape[i + 1],
											  objectB.Shape[j],
											  objectB.Shape[j + 1]))
						return true;
			return false;
		}

		public static bool IsCollidingOnto(IMovingObject objectA, IMovingObject objectB)
		{
			for (int i = 0; i < objectA.Shape.Count - 1; i++)
				for (int j = 0; j < objectB.Shape.Count - 1; j++)
					if (CalculateIntersection(objectA.Shape[i],
											  objectA.Shape[i + 1],
											  objectB.Shape[j],
											  objectB.Shape[j + 1]))
						return true;
			return false;
		}

		private static bool CalculateIntersection(ICartesianPoint p, ICartesianPoint p2, ICartesianPoint q, ICartesianPoint q2)
		{
			var r = SubtractPoints(p2, p);
			var s = SubtractPoints(q2, q);

			var uNumerator = CrossProduct(SubtractPoints(q, p), r);
			var denominator = CrossProduct(r, s);

			if (denominator == 0)
			{
				if (uNumerator == 0)
				{
					// They are coLlinear

					// Do they touch? (Are any of the points equal?)
					if (EqualPoints(p, q) || EqualPoints(p, q2) || EqualPoints(p2, q) || EqualPoints(p2, q2))
					{
						return true;
					}
					// Do they overlap? (Are all the point differences in either direction the same sign)
					return !AllEqual(q.X - p.X < 0,
								     q.X - p2.X < 0,
									 q2.X - p.X < 0,
									 q2.X - p2.X < 0) ||
						   !AllEqual(q.Y - p.Y < 0,
									 q.Y - p2.Y < 0,
									 q2.Y - p.Y < 0,
									 q2.Y - p2.Y < 0);
				}

				// lines are paralell
				return false;
			}

			var u = uNumerator / denominator;
			var t = CrossProduct(SubtractPoints(q, p), s) / denominator;

			return (t >= 0) && (t <= 1) && (u >= 0) && (u <= 1);
		}

		/// <summary>
		/// Calculate the cross product of the two points.
		/// </summary>
		/// <param name="point1">point object with x and y coordinates</param>
		/// <param name="point2">point object with x and y coordinates</param>
		/// <returns>the cross product result as a float</returns>

		private static float CrossProduct(ICartesianPoint point1, ICartesianPoint point2)
		{
			return point1.X * point2.Y - point1.Y * point2.X;
		}

		/// <summary>
		/// Subtract the second point from the first.
		/// </summary>
		/// <param name="point1">point object with x and y coordinates</param>
		/// <param name="point2">point object with x and y coordinates</param>
		/// <returns>the subtraction result as a point object</returns>

		private static CartesianPoint SubtractPoints(ICartesianPoint point1, ICartesianPoint point2)
		{
			return new()
			{
				X = point1.X - point2.X,
				Y = point1.Y - point2.Y
			};
		}

		/// <summary>
		/// Sees if the points are equal.
		/// </summary>
		/// <param name="point1">point object with x and y coordinates</param>
		/// <param name="point2">point object with x and y coordinates</param>
		/// <returns>if the points are equal</returns>

		private static bool EqualPoints(ICartesianPoint point1, ICartesianPoint point2)
		{
			return (point1.X == point2.X && point1.Y == point2.Y);
		}

		/// <summary>
		/// Sees if all arguments are equal.
		/// </summary>
		/// <param name="args">args arguments that will be compared by '=='.</param>
		/// <returns>if all arguments are equal</returns>

		private static bool AllEqual(params bool[] args)
		{
			var firstValue = args[0];
			for (int i = 1; i < args.Length; i += 1)
				if (args[i] != firstValue)
					return false;

			return true;
		}
	}
}
