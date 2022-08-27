using CarGame.Game;
using CarGame.Interfaces;
using CarGame.MovingObjects.Car.View;
using CarGame.Utilities;

namespace CarGame.MovingObjects.Car
{
    public partial class Car : PictureBox, IUISchedule
    {
        private float imageAngle = 0;
        private const int MAX_GAP = 1;
        public float lastAngle = 0;

        private bool hasOverlap = false;

        private Car overlapperReal;
        private Car overlappedReal;
        private Car overlappedClone;
        private Image picture;
        private SoundChannelType engineChannel;
        IEngineSound engine;

        public Car()
        {
            BackColor = Color.Transparent;
        }

        public Image Picture
        {
            get => picture;
            set
            {
                picture = value;
                Image = value;
            }
        }

        public CarLocation Position { get; set; }

        public SoundChannelType EngineChannel
        {
            get => engineChannel;
            set
            {
                engineChannel = value;

                if (engine is not null)
                    engine.Stop();

                engine = new CarEngineSound(value, "Resources/carEngine.wav", CarPowerTrain.IDLE_RPM, CarPowerTrain.MAX_RPM);
                engine.Start();
            }
        }

        public GameControl GameControl { get; set; }

        public void Run(bool byStep)
        {
            int x = TwoDWorld.XFromCartesianX(Position.Location.Point.X) - Width / 2;
            int y = TwoDWorld.YFromCartesianY(Position.Location.Point.Y) - Width / 2;

            if (Math.Abs(lastAngle - Position.Location.DirectionInDegrees) >= MAX_GAP)
            {
                lastAngle = Position.Location.DirectionInDegrees;

                imageAngle = lastAngle;
                Image = ImageHelper.Rotate(Picture, imageAngle);
            }
            Location = new Point(x, y);

            if (Position.CollidedBy || Position.CollidedOntoStatic)
            {
                Image = new Bitmap("Resources/ExplodedCar.png");
                CarCrashSound.Play();
            }

            PaintOverlapped();

            if (engine is not null)
            {
                var rpm = Position.Movement.PowerTrain.RPM;
                if (rpm >= CarPowerTrain.IDLE_RPM)
                    engine.Rpm = rpm;
            }
        }

        public void Stop()
        {
            engine?.Stop();
        }

        internal void Overlap(Car overlapped, Car overlapper)
        {
            overlapperReal = overlapper;
            overlappedReal = overlapped;
            overlappedClone = new()
            {
                Image = overlappedReal.Image,
                BackColor = overlappedReal.BackColor,
                BackgroundImageLayout = overlappedReal.BackgroundImageLayout,
                Position = overlappedReal.Position,
                Picture = overlappedReal.Picture,
                Location = overlappedReal.Location,
                Margin = overlappedReal.Margin,
                Name = overlappedReal.Name,
                Size = overlappedReal.Size,
                SizeMode = overlappedReal.SizeMode,
                TabIndex = overlappedReal.TabIndex,
                TabStop = overlappedReal.TabStop
            };
            Controls.Add(overlappedClone);
            hasOverlap = true;
        }

        private void ClearOverlap()
        {
            overlapperReal = null;
            overlappedReal = null;
            overlappedClone = null;

            Controls.Clear();
            hasOverlap = false;
        }

        internal void PaintOverlapped()
        {
            if (hasOverlap)
            {
                if (Math.Abs(overlappedReal.Location.X - overlapperReal.Location.X) <= overlapperReal.Height &&
                    Math.Abs(overlappedReal.Location.Y - overlapperReal.Location.Y) <= overlapperReal.Width)
                {
                    overlappedClone.Location = new Point(-Math.Abs(Location.X) + Math.Abs(overlappedReal.Location.X),
                                                         -Math.Abs(Location.Y) + Math.Abs(overlappedReal.Location.Y));
                    overlappedClone.Image = overlappedReal.Image;

                    overlappedReal.Refresh();
                    Refresh();
                }
            }
        }

        public void Restart()
        {
            ClearOverlap();
            engine?.Start();
            Run(false);
        }
    }
}
