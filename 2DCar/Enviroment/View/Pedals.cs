using GameEngine.Interfaces;
using MovingObjects.Car;

namespace Enviroment.View
{
    public partial class Pedals : UserControl, IUISchedule
    {
        CarMovement carMovement;

        public Pedals()
        {
            InitializeComponent();
        }

        public void Run(bool byStep)
        {
            if (carMovement.GasPedal)
                acceleratorBox.Image = Properties.Resources.ActivatedAccelerator;
            else
                acceleratorBox.Image = Properties.Resources.Accelerator;

            if (carMovement.BreakPedal)
                breakBox.Image = Properties.Resources.ActivatedBreak;
            else
                breakBox.Image = Properties.Resources.Break;
        }

        public void Restart()
        {
            Run(false);
        }

        internal void SetPedals(Car car)
        {
            carMovement = car.Position.Movement;
        }

        public void Stop() {}
    }
}
