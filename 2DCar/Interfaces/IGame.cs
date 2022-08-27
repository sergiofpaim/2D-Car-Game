namespace CarGame.Interfaces
{
    public interface IGame
    {
        void AckCollision(List<(IMovingObject moving, bool collisioned)> collisions);
        void Run(bool byStep);
        void Restart();
        public bool Over { get; }
        public string Winner { get; }
    }
}
