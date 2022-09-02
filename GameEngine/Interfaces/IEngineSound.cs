namespace GameEngine.Interfaces
{
    public interface IEngineSound
    {
        void Start();
        void Stop();
        public float Rpm { get ; set; }
    }
}
