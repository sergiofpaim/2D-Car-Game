namespace CarGame.Interfaces
{
    public interface ISchedule
    {
        /// <summary>
        /// The id of the object
        /// </summary>
        public string Id { get; }
        void Run(bool byStep);
        void Restart();
    }
}
