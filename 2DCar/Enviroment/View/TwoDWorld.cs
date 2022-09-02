using Game;
using MovingObjects.Car;
using StaticObjects;
using GameEngine.Enviroment;
using GameEngine.Interfaces;
using GameEngine.Physics;
using GameEngine.Utilities;

namespace Enviroment.View
{
    public partial class TwoDWorld : Form, IUISchedule
    {
        #region Properties and Constants
        public readonly static int X_ZERO_POINT = 683;
        public readonly static int Y_ZERO_POINT = 319;

        public readonly static float MPS_TO_KMH = 3.6F;
        public readonly static float PIXELS_PER_METER = 4;
        public static float MPS_TO_PPS => MPS_TO_KMH * PIXELS_PER_METER;

        private GameControl GameCntrl { get; set; }

        private CarLocation CarA { get; set; }
        private CarLocation CarB { get; set; }
        
        private Obstacle TopLimit { get; set; }
        private Obstacle BottomLimit { get; set; }

        private Obstacle LeftLimit { get; set; }
        private Obstacle RightLimit { get; set; }

        private Obstacle Mountain { get; set; }
        private Obstacle Rock1 { get; set; }
        private Obstacle Rock2 { get; set; }
        private Obstacle Rock3 { get; set; }
        #endregion

        #region Form Setup
        public TwoDWorld()
        {
            InitializeComponent();
            InitializeGameObjects();
            SetUIControls();
        }

        internal static float CartesianXFromX(int x)
        {
            return (-X_ZERO_POINT + x) / MPS_TO_PPS;
        }

        internal static float CartesianYFromY(int y)
        {
            return (Y_ZERO_POINT - y) / MPS_TO_PPS;
        }

        internal static int XFromCartesianX(float x)
        {
            return (int)Math.Round(X_ZERO_POINT + x * MPS_TO_PPS, 0);
        }

        internal static int YFromCartesianY(float y)
        {
            return (int)Math.Round(Y_ZERO_POINT - y * MPS_TO_PPS, 0);
        }

        private void InitializeGameObjects()
        {
            GameCntrl = new();

            CarA = new("blue car", ControlType.A, new Location(CartesianXFromX(blueCar.Location.X + blueCar.Width / 2), CartesianYFromY(blueCar.Location.Y + blueCar.Width / 2), 0));
            CarB = new("green car", ControlType.B, new Location(CartesianXFromX(greenCar.Location.X + greenCar.Width / 2), CartesianYFromY(greenCar.Location.Y + greenCar.Width / 2), 0));

            LeftLimit = new("left", new() {
                                            new(CartesianXFromX(9), CartesianYFromY(9)),
                                            new(CartesianXFromX(3), CartesianYFromY(9)),
                                            new(CartesianXFromX(3), CartesianYFromY(621)),
                                            new(CartesianXFromX(9), CartesianYFromY(621))
                                          });

            RightLimit = new("right", new() {
                                            new(CartesianXFromX(1355), CartesianYFromY(9)),
                                            new(CartesianXFromX(1363), CartesianYFromY(9)),
                                            new(CartesianXFromX(1363), CartesianYFromY(621)),
                                            new(CartesianXFromX(1355), CartesianYFromY(621))
                                            });

            TopLimit = new("top", new() {
                                            new(CartesianXFromX(3), CartesianYFromY(17)),
                                            new(CartesianXFromX(1360), CartesianYFromY(17)),
                                            new(CartesianXFromX(1360), CartesianYFromY(9)),
                                            new(CartesianXFromX(3), CartesianYFromY(9))
                                        });

            BottomLimit = new("bottom", new() {
                                            new(CartesianXFromX(3), CartesianYFromY(621)),
                                            new(CartesianXFromX(1360), CartesianYFromY(621)),
                                            new(CartesianXFromX(1360), CartesianYFromY(629)),
                                            new(CartesianXFromX(3), CartesianYFromY(629))
                                              });

            Mountain = new("mountain", new() {
                                                new(CartesianXFromX(724), CartesianYFromY(171)),
                                                new(CartesianXFromX(724), CartesianYFromY(215)),
                                                new(CartesianXFromX(705), CartesianYFromY(229)),
                                                new(CartesianXFromX(713), CartesianYFromY(234)),
                                                new(CartesianXFromX(692), CartesianYFromY(259)),
                                                new(CartesianXFromX(699), CartesianYFromY(258)),
                                                new(CartesianXFromX(690), CartesianYFromY(340)),
                                                new(CartesianXFromX(696), CartesianYFromY(467)),
                                                new(CartesianXFromX(649), CartesianYFromY(454)),
                                                new(CartesianXFromX(649), CartesianYFromY(402)),
                                                new(CartesianXFromX(624), CartesianYFromY(393)),
                                                new(CartesianXFromX(660), CartesianYFromY(374)),
                                                new(CartesianXFromX(652), CartesianYFromY(359)),
                                                new(CartesianXFromX(620), CartesianYFromY(338)),
                                                new(CartesianXFromX(662), CartesianYFromY(319)),
                                                new(CartesianXFromX(665), CartesianYFromY(281)),
                                                new(CartesianXFromX(632), CartesianYFromY(261)),
                                                new(CartesianXFromX(642), CartesianYFromY(250)),
                                                new(CartesianXFromX(641), CartesianYFromY(235)),
                                                new(CartesianXFromX(663), CartesianYFromY(230)),
                                                new(CartesianXFromX(663), CartesianYFromY(212)),
                                                new(CartesianXFromX(724), CartesianYFromY(171))
                                              });

            Rock1 = new("rock1", new() {
                                           new(CartesianXFromX(67), CartesianYFromY(157)),
                                           new(CartesianXFromX(75), CartesianYFromY(159)),
                                           new(CartesianXFromX(68), CartesianYFromY(174)),
                                           new(CartesianXFromX(59), CartesianYFromY(172)),
                                           new(CartesianXFromX(67), CartesianYFromY(157)),
                                           new(CartesianXFromX(59), CartesianYFromY(172))
                                       });

            Rock2 = new("rock2", new() {
                                           new(CartesianXFromX(1174), CartesianYFromY(358)),
                                           new(CartesianXFromX(1179), CartesianYFromY(337)),
                                           new(CartesianXFromX(1190), CartesianYFromY(344)),
                                           new(CartesianXFromX(1185), CartesianYFromY(359)),
                                           new(CartesianXFromX(1174), CartesianYFromY(358)),
                                       });

            Rock3 = new("rock3", new() {
                                           new(CartesianXFromX(1177), CartesianYFromY(590)),
                                           new(CartesianXFromX(1184), CartesianYFromY(575)),
                                           new(CartesianXFromX(1193), CartesianYFromY(579)),
                                           new(CartesianXFromX(1187), CartesianYFromY(592)),
                                           new(CartesianXFromX(1177), CartesianYFromY(590)),
                                       });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Size = new Size(1366, 768);

            Scheduler.Register(CarA);
            Scheduler.Register(CarB);

            Scheduler.Register(TopLimit);
            Scheduler.Register(BottomLimit);
            Scheduler.Register(Mountain);

            Scheduler.Register(GameCntrl);

            Scheduler.Register(this);
        }

        private void TwoDWorld_Shown(object sender, EventArgs e)
        {
            GameInstructions();
        }

        private void SetUIControls()
        {
            blueCar.Position = CarA;
            blueCar.Picture = new Bitmap("Resources/BlueCar.png");
            blueCar.EngineChannel = SoundChannelType.Left;
            greenCar.Position = CarB;
            greenCar.Picture = new Bitmap("Resources/GreenCar.png");
            greenCar.EngineChannel = SoundChannelType.Right;

            blueCompass.SetCarCompass(blueCar);
            greenCompass.SetCarCompass(greenCar);

            blueSteeringWheel.SetSteeringWheel(blueCar);
            greenSteeringWheel.SetSteeringWheel(greenCar);

            blueEngineMarker.SetSpeedometer(blueCar);
            greenEngineMarker.SetSpeedometer(greenCar);

            blueTachometer.SetTachometer(blueCar);
            greenTachometer.SetTachometer(greenCar);

            bluePedals.SetPedals(blueCar);
            greenPedals.SetPedals(greenCar);

            blueCar.Overlap(greenCar, blueCar);

            score.Game = GameCntrl;
        }
        #endregion

        #region Events
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (Controls["runButton"].Text == "Start")
            {
                Controls["runButton"].Text = "Stop";
                Controls["stepButton"].Visible = false;
                Scheduler.Start();
                SoundEngine.Play();

            }
            else
            {
                Controls["runButton"].Text = "Start";
                Controls["stepButton"].Visible = true;
                Scheduler.Stop();
                SoundEngine.Stop();
            }

            Thread.Yield();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Scheduler.Restart();
            SoundEngine.Play();
            SetUIControls();
        }

        private void StepButton_Click(object sender, EventArgs e)
        {
            Scheduler.Step();
        }

        private void TwoDWorld_FormClosing(object sender, FormClosingEventArgs e)
        {
            Scheduler.Stop();
            SoundEngine.Stop();
        }

        #endregion

        #region Game Execution
        public void Run(bool byStep)
        {
            SuspendLayout();

            greenCar.Run(byStep);
            blueCar.Run(byStep);
            Thread.Yield();

            greenCompass.Run(byStep);
            greenSteeringWheel.Run(byStep);
            greenEngineMarker.Run(byStep);
            greenTachometer.Run(byStep);
            greenPedals.Run(byStep);

            blueCompass.Run(byStep);
            blueSteeringWheel.Run(byStep);
            blueEngineMarker.Run(byStep);
            blueTachometer.Run(byStep);
            bluePedals.Run(byStep);

            blueCurrentGear.Text = $"{CarA.Movement.PowerTrain.CurrentGear}";
            greenCurrentGear.Text = $"{CarB.Movement.PowerTrain.CurrentGear}";

            RenderCollisionsToDebug(byStep);

            ResumeLayout();

            if (GameCntrl.Over)
                Stop();
        }

        public void Stop()
        {
            blueCar.Stop();
            greenCar.Stop();

            score.Display();
        }

        public void Restart()
        {
            SuspendLayout();

            greenCar.Restart();
            blueCar.Restart();
            Thread.Yield();

            greenCompass.Restart();
            greenSteeringWheel.Restart();
            greenEngineMarker.Restart();
            greenTachometer.Restart();
            greenPedals.Restart();

            blueCompass.Restart();
            blueSteeringWheel.Restart();
            blueEngineMarker.Restart();
            blueTachometer.Restart();
            bluePedals.Restart();

            blueCurrentGear.Text = $"{CarA.Movement.PowerTrain.CurrentGear}";
            greenCurrentGear.Text = $"{CarB.Movement.PowerTrain.CurrentGear}";

            blueCar.Overlap(greenCar, blueCar);

            score.Restart();

            ResumeLayout();
        }

        #endregion

        private void about_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"2D Car Game 1.0\n\n" +
                            $"By Sérgio Filho Paim, under the guidance " +
                            $"of Sérgio Paim (2022)\n\n" +
                            $"Source code: https://github.com/sergiofpaim/2D-Car-Game",
                            $"About this game");
        }

        private void GameInstructions()
        {
            MessageBox.Show($"                        INSTRUCTIONS\n\n\n\n" +
                            $"Avoid rocks and mountains.\n\n" +
                            $"Hit the other car to win!\n\n" +
                            $"Use W, A, S, D keys to drive the blue car,\n" +
                            $"and the arrows to drive the green car",
                            $"Game Rules");
        }

        #region Debug

        private void TwoDWorld_Paint(object sender, PaintEventArgs e)
        {
            if (!Scheduler.Debugging)
                return;

            DrawCollisionObject(e, Mountain);
            DrawCollisionObject(e, Rock1);
            DrawCollisionObject(e, Rock2);
            DrawCollisionObject(e, Rock3);
            DrawCollisionObject(e, LeftLimit);
            DrawCollisionObject(e, RightLimit);
            DrawCollisionObject(e, TopLimit);
            DrawCollisionObject(e, BottomLimit);
        }

        private static void DrawCollisionObject(PaintEventArgs e, Obstacle collidingObject)
        {
            if (collidingObject is not null)
                e.Graphics.DrawPolygon(new Pen(Color.Red), collidingObject.Shape.Select(p => new PointF(XFromCartesianX(p.X),
                                                                                                        YFromCartesianY(p.Y))).ToArray());
        }

        private void RenderCollisionsToDebug(bool byStep)
        {
            if (!Scheduler.Debugging || !byStep)
                return;

            var g = this.CreateGraphics();

            g.DrawPolygon(new Pen(Color.Blue), CarA.Shape.Select(p => new PointF(XFromCartesianX(p.X),
                                                                                             YFromCartesianY(p.Y))).ToArray());
            g.DrawPolygon(new Pen(Color.Blue), CarB.Shape.Select(p => new PointF(XFromCartesianX(p.X),
                                                                                             YFromCartesianY(p.Y))).ToArray());
        }
        #endregion
    }
}