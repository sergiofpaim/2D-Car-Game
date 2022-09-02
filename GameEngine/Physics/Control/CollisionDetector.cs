using GameEngine.Interfaces;

namespace GameEngine.Physics
{
    public class CollisionDetector
    {
        public static readonly List<IMovingObject> movingObjs = new();
        public static readonly List<IStaticObject> staticObjs = new();

        public static bool Register(IMovingObject obj)
        {

            if (movingObjs.Contains(obj))
            {
                return false;
            }
            else
            {
                movingObjs.Add(obj);
                return true;
            }
        }
        
        public static bool Unregister(IMovingObject obj)
        {

            if (!movingObjs.Contains(obj))
            {
                return false;
            }
            else
            {
                movingObjs.Remove(obj);
                return true;
            }
        }

        public static bool Register(IStaticObject obj)
        {

            if (staticObjs.Contains(obj))
            {
                return false;
            }
            else
            {
                staticObjs.Add(obj);
                return true;
            }
        }

        public static List<(IMovingObject moving, bool collisioned)> Detect()
        {
            List<Collision> collisions = new();

            for (int i = 0; i < movingObjs.Count; i++)
            {
                Collision collision = new() 
                {  
                    Colliding = movingObjs[i],
                    MovingCollided = new (),
                    StaticCollided = new ()
                };

                var moving = movingObjs[i];
                for (int j = 0; j < movingObjs.Count; j++)
                    if (j != i)
                        if (Polygon.IsCollidingOnto(moving, movingObjs[j]))
                        {
                            if (Polygon.IsInside(moving.ActiveSide.A, movingObjs[j].Shape) ||
                                Polygon.IsInside(moving.ActiveSide.B, movingObjs[j].Shape))
                            collision.MovingCollided.Add(movingObjs[j]);
                        }

                for (int j = 0; j < staticObjs.Count; j++)
                    if (Polygon.IsCollidingOnto(moving, staticObjs[j]))
                        collision.StaticCollided.Add(staticObjs[j]);

                if (collision.MovingCollided.Count > 0 || collision.StaticCollided.Count > 0)
                    collisions.Add(collision);
            }

            foreach (var collision in collisions)
            {
                collision.Colliding.HandleCollisionOnto(collision.MovingCollided, collision.StaticCollided);
                
                foreach (var collided in collision.MovingCollided)
                    collided.HandleCollisionBy(collision.Colliding);

                foreach (var collided in collision.StaticCollided)
                    collided.HandleCollisionBy(collision.Colliding);
            }

            return movingObjs.Select(m => (m, collisions.Any(c => c.Colliding.Id == m.Id))).ToList();
        }
    }
}
