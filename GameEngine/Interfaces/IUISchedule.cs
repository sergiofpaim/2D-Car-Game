namespace GameEngine.Interfaces
{
    public interface IUISchedule
    {
        void Run(bool byStep);
        void Stop();
        void Restart();
    }
}
