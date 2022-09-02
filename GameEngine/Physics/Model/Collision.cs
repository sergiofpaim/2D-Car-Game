using GameEngine.Interfaces;

namespace GameEngine.Physics
{
    internal class Collision
    {
        public IMovingObject Colliding { get; set; }
        public List<IMovingObject> MovingCollided { get; set; }
        public List<IStaticObject> StaticCollided { get; set; }
    }
}
