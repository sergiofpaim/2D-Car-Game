using GameEngine.Physics;

namespace GameEngine.Interfaces
{
    public interface IStaticObject
    {
        /// <summary>
        /// The id of the object
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// List of points to be passively collision checked by other moving objects
        /// </summary>
        List<ICartesianPoint> Shape { get; }
        /// <summary>
        /// Handles the collision events against moving or static objects
        /// </summary>
        /// <param name="movingObject">Moving object that collided onto the object</param>
        void HandleCollisionBy(IMovingObject movingObject);
        /// <summary>
        /// Indication if the object has been collided by any other object
        /// </summary>
        bool CollidedBy { get; }
    }
}