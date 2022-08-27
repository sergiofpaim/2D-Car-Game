using CarGame.Enviroment;
using CarGame.Interfaces;
using CarGame.Physics;
using System.Linq;

namespace CarGame.StaticObjects
{
    public class Obstacle : ISchedule, IStaticObject
    {
        public string Id { get; private set; }

        public Obstacle(string id, List<CartesianPoint> shape)
        {
            Id = id;
            Shape = shape.Select(s => s as ICartesianPoint).ToList();
            CollisionDetector.Register(this);
        }

        public List<ICartesianPoint> Shape { get; private set; }
        public bool CollidedBy { get; private set; } = false;

        public void Restart()
        {
            CollidedBy = false;
        }

        public void Run(bool byStep)
        {
            
        }

        string by;

        public void HandleCollisionBy(IMovingObject movingObject)
        {
            by = $"Moving: {movingObject.Id}";
            
            CollidedBy = true;
        }

        public override string ToString()
        {
            return $"Id: {Id} By: ({by})";
        }
    }
}