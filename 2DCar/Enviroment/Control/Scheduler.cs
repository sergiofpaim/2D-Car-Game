using CarGame.Interfaces;
using CarGame.Physics;
using System.Timers;
using Timer = System.Timers.Timer;

namespace CarGame.Enviroment
{
    public static class Scheduler
    {
        //Set true to step up the scheduler to make it easy to debug
        public static bool Debugging = false;

        private const int MIN_LOOP_INTERVAL = 20;
        private const int MAX_LOOP_INTERVAL = 500;

        private static readonly Timer timer = new();

        private static float loopInterval = 62.5F;
        private static bool initialized = false;

        private static readonly List<ISchedule> movingObjects = new();
        private static IUISchedule ui;
        private static IGame game;
        private static bool running = false;

        public static float LoopInterval { get => loopInterval; }

        public static void Init()
        {
            if (initialized)
                throw new Exception("Schedule is already initialized");
            else 
                initialized = true;

            timer.Interval = loopInterval;
            timer.AutoReset = true;
            timer.Elapsed += RunOnce;
        }

        public static void Init(float loopIntervalInMs)
        {
            if (loopIntervalInMs < MIN_LOOP_INTERVAL || loopIntervalInMs > MAX_LOOP_INTERVAL)
                throw new Exception($"The scheduler's {nameof(loopIntervalInMs)} must be between {MIN_LOOP_INTERVAL} and {MAX_LOOP_INTERVAL}");
            loopInterval = loopIntervalInMs;

            Init();
        }

        public static void Start()
        {
            CheckInitialization();
               
            timer.Start();
            running = true;
        }

        public static void Stop()
        {
            CheckInitialization();
            running = false;
            timer.Stop();
        }

        public static bool Register(ISchedule movingObject)
        {
            CheckInitialization();

            if (movingObject is null)
                return false;

            if (movingObjects.Any(mo => mo.Id == movingObject.Id))
            {
                return false;
            }
            else 
            {
                movingObjects.Add(movingObject);
                return true;
            } 
        }

        internal static void Restart()
        {
            foreach (var obj in movingObjects)
            {
                obj.Restart();
            }

            game.Restart();

            ThreadSafeInvoker.Restart(ui);

            Start();
        }

        internal static void Step()
        {
            RunOnce(true);
        }

        public static void Register(IUISchedule ui)
        {
            CheckInitialization();

            Scheduler.ui = ui;                
        }

        public static void Register(IGame game)
        {
            CheckInitialization();

            Scheduler.game = game;                
        }

        public static bool UnregisterMovingObject(ISchedule movingObject)
        {
            CheckInitialization();

            if (!movingObjects.Any(mo => mo.Id == movingObject.Id))
            {
                return false;
            }
            else 
            {
                movingObjects.RemoveAll(mo => mo.Id == movingObject.Id);
                return true;
            } 
        }

        public static void UnregisterViewObject()
        {
            CheckInitialization();

            ui = null;
        }

        private static void RunOnce(object source, ElapsedEventArgs e)
        {
            RunOnce(false);
        }

        private static void RunOnce(bool byStep)
        {
            if (running || byStep)
            {
                foreach (var obj in movingObjects)
                    obj.Run(byStep);

                if (!Debugging || byStep)
                {
                    var collisions = CollisionDetector.Detect();
                    if (collisions?.Count() > 0)
                        game.AckCollision(collisions);

                    game.Run(byStep);
                }
                ThreadSafeInvoker.Run(ui, byStep);
            }
        }

        private static void CheckInitialization() 
        {
            if (!initialized)
                throw new Exception("Schedule must be initialized before use");
        }
    }
}
