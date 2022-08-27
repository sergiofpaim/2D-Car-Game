using CarGame.Interfaces;


namespace CarGame.Game.View
{
    public partial class GameScore : Label
    {
        public GameControl Game { get; set; }

        public GameScore()
        {
            InitializeComponent();
        }

        public void Display()
        {
            Visible = true;

            if (string.IsNullOrEmpty(Game.Winner))
                Text = "The game tied!";
            if (Game.Winner != string.Empty)
                Text = $"The {Game.Winner} won!";
        }

        public void Restart()
        {
            Visible = false;
        }
    }
}