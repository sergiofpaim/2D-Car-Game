using GameEngine.Physics;

namespace GameEngine.Interfaces
{
    public interface IMovingObject
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
        /// Trajectory composed by min point from last position and max point from current position in the moving direction line
        /// </summary>
        Side ActiveSide { get; }
        /// <summary>
        /// Handles the collision events against moving or static objects
        /// </summary>
        /// <param name="movingObjects">List of moving objects that were collided by the object</param>
        /// <param name="staticObjects">List of static objects that were collided by the object</param>
        void HandleCollisionOnto(List<IMovingObject> movingObjects, List<IStaticObject> staticObjects);
        /// <summary>
        /// Handles the collision events against moving or static objects
        /// </summary>
        /// <param name="movingObject">Moving object that collided onto the object</param>
        void HandleCollisionBy(IMovingObject movingObject);
        /// <summary>
        /// Indication if the object has collided onto any other moving object
        /// </summary>
        bool CollidedOntoMoving { get; }
        /// <summary>
        /// Indication if the object has collided onto any static object
        /// </summary>
        bool CollidedOntoStatic{ get; }
        /// <summary>
        /// Indication if the object has been collided by any other object
        /// </summary>
        bool CollidedBy { get; }
    }
}
