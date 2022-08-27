using CarGame.Enviroment;
using CarGame.Interfaces;

namespace CarGame.Game
{
    public class GameControl : IGame
    {
        public bool Over { get; internal set; }
        public string Winner { get; internal set; }

        public GameControl()
        {
            Init();
        }

        public void AckCollision(List<(IMovingObject moving, bool collisioned)> collisions)
        {
            var countMoving = collisions.Count(c => c.collisioned && 
                                                    c.moving.CollidedOntoMoving &&
                                                   !c.moving.CollidedBy);

            var countStatic = collisions.Count(c => c.collisioned &&
                                                    c.moving.CollidedOntoStatic &&
                                                   !c.moving.CollidedBy);

            var tied = collisions.Count(c => c.moving.CollidedOntoMoving && c.moving.CollidedBy ||
                                             c.moving.CollidedOntoStatic && !c.moving.CollidedBy);

            if (countMoving > 0 || countStatic > 0 || tied > 1)
            {
                Over = true;
                if (countMoving == 1)
                    Winner = $"{collisions.FirstOrDefault(c => c.collisioned && c.moving.CollidedOntoMoving && !c.moving.CollidedBy).moving.Id}";

                if (countStatic == 1)
                    Winner = $"{collisions.FirstOrDefault(m => !m.collisioned && !m.moving.CollidedOntoMoving && !m.moving.CollidedOntoStatic && !m.moving.CollidedBy).moving.Id}";

                if (tied > 1)
                    Winner = string.Empty;

                CloseGame();
            }
        }

        public void CloseGame()
        {
            Scheduler.Stop();
        }

        public void Restart()
        {
            Init();
        }

        public void Run(bool byStep) { }

        private void Init()
        {
            Over = false;
            Winner = string.Empty;
        }
    }
}
