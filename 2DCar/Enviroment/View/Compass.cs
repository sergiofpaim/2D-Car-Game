using GameEngine.Interfaces;
using MovingObjects.Car;
using GameEngine.Physics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enviroment.View
{
    public partial class Compass : UserControl, IUISchedule
    {
        private const int ZERO_DEGREE_POSITION = 48;
        private const int DISPLAY_SIZE = 25;
        private const int CHARS_PER_360 = 48;
        private const string DIRECTIONS = "N • • ¦ • • E • • ¦ • • S • • ¦ • • W • • ¦ • • N • • ¦ • • E • • ¦ • • S";
        private float directionToRender = -1;
        private Location carLocation;

        public Compass()
        {
            InitializeComponent();
        }

        public void Run(bool byStep)
        {
            if (directionToRender != carLocation.DirectionInDegrees + 0.25)
            {
                directionToRender = carLocation.DirectionInDegrees;
                directions.Text = DIRECTIONS.Substring(ZERO_DEGREE_POSITION
                                                       - (int)Math.Ceiling(directionToRender
                                                                           * CHARS_PER_360
                                                                           / 360),
                                                       DISPLAY_SIZE);
            }
        }

        public void Restart()
        {
            Run(false);
        }

        internal void SetCarCompass(Car car)
        {
            carLocation = car.Position.Location;
        }

        public void Stop() { }
    }
}
