namespace Enviroment.View
{
    partial class TwoDWorld
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwoDWorld));
            this.runButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.restart = new System.Windows.Forms.Button();
            this.greenCar = new MovingObjects.Car.Car();
            this.blueCar = new MovingObjects.Car.Car();
            this.stepButton = new System.Windows.Forms.Button();
            this.blueCompass = new Enviroment.View.Compass();
            this.greenCompass = new Enviroment.View.Compass();
            this.blueCockpit = new System.Windows.Forms.Panel();
            this.gearBlue = new System.Windows.Forms.Label();
            this.bluePedals = new Enviroment.View.Pedals();
            this.blueCurrentGear = new System.Windows.Forms.TextBox();
            this.blueSteeringWheel = new Enviroment.View.SteeringWheel();
            this.blueTachometer = new Enviroment.View.Tachometer();
            this.blueEngineMarker = new Enviroment.View.Speedometer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gearGreen = new System.Windows.Forms.Label();
            this.greenPedals = new Enviroment.View.Pedals();
            this.greenCurrentGear = new System.Windows.Forms.TextBox();
            this.greenSteeringWheel = new Enviroment.View.SteeringWheel();
            this.greenTachometer = new Enviroment.View.Tachometer();
            this.greenEngineMarker = new Enviroment.View.Speedometer();
            this.about = new System.Windows.Forms.Button();
            this.score = new Game.View.GameScore();
            ((System.ComponentModel.ISupportInitialize)(this.greenCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCar)).BeginInit();
            this.blueCockpit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(646, 662);
            this.runButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(82, 22);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Start";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.Transparent;
            this.closeButton.BackgroundImage = global::Properties.Resources.CloseX;
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.Location = new System.Drawing.Point(1328, 11);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(26, 26);
            this.closeButton.TabIndex = 1;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(646, 715);
            this.restart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(82, 22);
            this.restart.TabIndex = 4;
            this.restart.Text = "&Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // greenCar
            // 
            this.greenCar.BackColor = System.Drawing.Color.Transparent;
            this.greenCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.greenCar.GameControl = null;
            this.greenCar.Location = new System.Drawing.Point(46, 541);
            this.greenCar.Name = "greenCar";
            this.greenCar.Picture = null;
            this.greenCar.Position = null;
            this.greenCar.Size = new System.Drawing.Size(60, 60);
            this.greenCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenCar.TabIndex = 9;
            this.greenCar.TabStop = false;
            // 
            // blueCar
            // 
            this.blueCar.BackColor = System.Drawing.Color.Transparent;
            this.blueCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.blueCar.GameControl = null;
            this.blueCar.Location = new System.Drawing.Point(46, 37);
            this.blueCar.Name = "blueCar";
            this.blueCar.Picture = null;
            this.blueCar.Position = null;
            this.blueCar.Size = new System.Drawing.Size(60, 60);
            this.blueCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blueCar.TabIndex = 10;
            this.blueCar.TabStop = false;
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(646, 742);
            this.stepButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(82, 22);
            this.stepButton.TabIndex = 12;
            this.stepButton.Text = "&Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Visible = false;
            this.stepButton.Click += new System.EventHandler(this.StepButton_Click);
            // 
            // blueCompass
            // 
            this.blueCompass.Location = new System.Drawing.Point(411, -1);
            this.blueCompass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.blueCompass.Name = "blueCompass";
            this.blueCompass.Size = new System.Drawing.Size(136, 47);
            this.blueCompass.TabIndex = 13;
            // 
            // greenCompass
            // 
            this.greenCompass.Location = new System.Drawing.Point(411, -2);
            this.greenCompass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.greenCompass.Name = "greenCompass";
            this.greenCompass.Size = new System.Drawing.Size(140, 49);
            this.greenCompass.TabIndex = 14;
            // 
            // blueCockpit
            // 
            this.blueCockpit.BackColor = System.Drawing.Color.LightSteelBlue;
            this.blueCockpit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blueCockpit.Controls.Add(this.gearBlue);
            this.blueCockpit.Controls.Add(this.bluePedals);
            this.blueCockpit.Controls.Add(this.blueCurrentGear);
            this.blueCockpit.Controls.Add(this.blueSteeringWheel);
            this.blueCockpit.Controls.Add(this.blueTachometer);
            this.blueCockpit.Controls.Add(this.blueEngineMarker);
            this.blueCockpit.Controls.Add(this.blueCompass);
            this.blueCockpit.Location = new System.Drawing.Point(12, 641);
            this.blueCockpit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.blueCockpit.Name = "blueCockpit";
            this.blueCockpit.Size = new System.Drawing.Size(550, 125);
            this.blueCockpit.TabIndex = 15;
            // 
            // gearBlue
            // 
            this.gearBlue.AutoSize = true;
            this.gearBlue.Location = new System.Drawing.Point(216, 97);
            this.gearBlue.Name = "gearBlue";
            this.gearBlue.Size = new System.Drawing.Size(31, 15);
            this.gearBlue.TabIndex = 20;
            this.gearBlue.Text = "Gear";
            this.gearBlue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bluePedals
            // 
            this.bluePedals.Location = new System.Drawing.Point(316, 50);
            this.bluePedals.Name = "bluePedals";
            this.bluePedals.Size = new System.Drawing.Size(94, 72);
            this.bluePedals.TabIndex = 17;
            // 
            // blueCurrentGear
            // 
            this.blueCurrentGear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blueCurrentGear.Location = new System.Drawing.Point(218, 74);
            this.blueCurrentGear.Name = "blueCurrentGear";
            this.blueCurrentGear.Size = new System.Drawing.Size(25, 23);
            this.blueCurrentGear.TabIndex = 19;
            this.blueCurrentGear.Text = "N";
            this.blueCurrentGear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // blueSteeringWheel
            // 
            this.blueSteeringWheel.BackColor = System.Drawing.Color.Transparent;
            this.blueSteeringWheel.Location = new System.Drawing.Point(12, 12);
            this.blueSteeringWheel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.blueSteeringWheel.Name = "blueSteeringWheel";
            this.blueSteeringWheel.Size = new System.Drawing.Size(114, 103);
            this.blueSteeringWheel.TabIndex = 18;
            // 
            // blueTachometer
            // 
            this.blueTachometer.Location = new System.Drawing.Point(228, 5);
            this.blueTachometer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.blueTachometer.Name = "blueTachometer";
            this.blueTachometer.Size = new System.Drawing.Size(77, 110);
            this.blueTachometer.TabIndex = 17;
            // 
            // blueEngineMarker
            // 
            this.blueEngineMarker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.blueEngineMarker.Location = new System.Drawing.Point(140, 4);
            this.blueEngineMarker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.blueEngineMarker.Name = "blueEngineMarker";
            this.blueEngineMarker.Size = new System.Drawing.Size(82, 91);
            this.blueEngineMarker.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.gearGreen);
            this.panel1.Controls.Add(this.greenPedals);
            this.panel1.Controls.Add(this.greenCurrentGear);
            this.panel1.Controls.Add(this.greenSteeringWheel);
            this.panel1.Controls.Add(this.greenTachometer);
            this.panel1.Controls.Add(this.greenEngineMarker);
            this.panel1.Controls.Add(this.greenCompass);
            this.panel1.Location = new System.Drawing.Point(805, 641);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 125);
            this.panel1.TabIndex = 16;
            // 
            // gearGreen
            // 
            this.gearGreen.AutoSize = true;
            this.gearGreen.Location = new System.Drawing.Point(216, 97);
            this.gearGreen.Name = "gearGreen";
            this.gearGreen.Size = new System.Drawing.Size(31, 15);
            this.gearGreen.TabIndex = 21;
            this.gearGreen.Text = "Gear";
            // 
            // greenPedals
            // 
            this.greenPedals.Location = new System.Drawing.Point(315, 50);
            this.greenPedals.Name = "greenPedals";
            this.greenPedals.Size = new System.Drawing.Size(94, 72);
            this.greenPedals.TabIndex = 20;
            // 
            // greenCurrentGear
            // 
            this.greenCurrentGear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenCurrentGear.Location = new System.Drawing.Point(218, 74);
            this.greenCurrentGear.Name = "greenCurrentGear";
            this.greenCurrentGear.Size = new System.Drawing.Size(25, 23);
            this.greenCurrentGear.TabIndex = 20;
            this.greenCurrentGear.Text = "N";
            this.greenCurrentGear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // greenSteeringWheel
            // 
            this.greenSteeringWheel.BackColor = System.Drawing.Color.Transparent;
            this.greenSteeringWheel.Location = new System.Drawing.Point(12, 12);
            this.greenSteeringWheel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.greenSteeringWheel.Name = "greenSteeringWheel";
            this.greenSteeringWheel.Size = new System.Drawing.Size(114, 103);
            this.greenSteeringWheel.TabIndex = 19;
            // 
            // greenTachometer
            // 
            this.greenTachometer.Location = new System.Drawing.Point(232, 8);
            this.greenTachometer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.greenTachometer.Name = "greenTachometer";
            this.greenTachometer.Size = new System.Drawing.Size(77, 107);
            this.greenTachometer.TabIndex = 18;
            // 
            // greenEngineMarker
            // 
            this.greenEngineMarker.Location = new System.Drawing.Point(139, 5);
            this.greenEngineMarker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.greenEngineMarker.Name = "greenEngineMarker";
            this.greenEngineMarker.Size = new System.Drawing.Size(82, 92);
            this.greenEngineMarker.TabIndex = 18;
            // 
            // about
            // 
            this.about.BackColor = System.Drawing.Color.Transparent;
            this.about.BackgroundImage = global::Properties.Resources.about;
            this.about.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.about.Location = new System.Drawing.Point(675, 687);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(25, 25);
            this.about.TabIndex = 17;
            this.about.UseVisualStyleBackColor = false;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // score
            // 
            this.score.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.score.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.score.Game = null;
            this.score.Location = new System.Drawing.Point(569, 541);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(236, 57);
            this.score.TabIndex = 18;
            this.score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.score.Visible = false;
            // 
            // TwoDWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Properties.Resources.editedMap;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.score);
            this.Controls.Add(this.about);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.blueCockpit);
            this.Controls.Add(this.blueCar);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.greenCar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TwoDWorld";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2D Car (simple) Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TwoDWorld_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.TwoDWorld_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TwoDWorld_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.greenCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueCar)).EndInit();
            this.blueCockpit.ResumeLayout(false);
            this.blueCockpit.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button runButton;
        private Button closeButton;
        private Button restart;
        private MovingObjects.Car.Car greenCar;
        private MovingObjects.Car.Car blueCar;
        private Button stepButton;
        private Enviroment.View.Compass blueCompass;
        private Enviroment.View.Compass greenCompass;
        private Panel blueCockpit;
        private Panel panel1;
        private Enviroment.View.Speedometer blueEngineMarker;
        private Enviroment.View.Speedometer greenEngineMarker;
        private Enviroment.View.Tachometer blueTachometer;
        private Enviroment.View.Tachometer greenTachometer;
        private Enviroment.View.SteeringWheel blueSteeringWheel;
        private Enviroment.View.SteeringWheel greenSteeringWheel;
        private TextBox blueCurrentGear;
        private TextBox greenCurrentGear;
        private Enviroment.View.Pedals bluePedals;
        private Enviroment.View.Pedals greenPedals;
        private Button about;
        private Label gearBlue;
        private Label gearGreen;
        private Game.View.GameScore score;
    }
}