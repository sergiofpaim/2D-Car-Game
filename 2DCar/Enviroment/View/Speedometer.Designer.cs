namespace Enviroment.View
{
    partial class Speedometer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.speedMark = new System.Windows.Forms.PictureBox();
            this.speedBox = new System.Windows.Forms.TextBox();
            this.speedometerCar = new System.Windows.Forms.PictureBox();
            this.kmPerHour = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.speedMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedometerCar)).BeginInit();
            this.SuspendLayout();
            // 
            // speedMark
            // 
            this.speedMark.BackColor = System.Drawing.Color.Transparent;
            this.speedMark.BackgroundImage = global::Properties.Resources.SpeedometerMark;
            this.speedMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.speedMark.Location = new System.Drawing.Point(14, 20);
            this.speedMark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speedMark.Name = "speedMark";
            this.speedMark.Size = new System.Drawing.Size(50, 40);
            this.speedMark.TabIndex = 1;
            this.speedMark.TabStop = false;
            // 
            // speedBox
            // 
            this.speedBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speedBox.Location = new System.Drawing.Point(24, 53);
            this.speedBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(31, 23);
            this.speedBox.TabIndex = 2;
            this.speedBox.Text = "0";
            this.speedBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // speedometerCar
            // 
            this.speedometerCar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.speedometerCar.Image = global::Properties.Resources.Speedometer;
            this.speedometerCar.Location = new System.Drawing.Point(0, 6);
            this.speedometerCar.Name = "speedometerCar";
            this.speedometerCar.Size = new System.Drawing.Size(80, 80);
            this.speedometerCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.speedometerCar.TabIndex = 3;
            this.speedometerCar.TabStop = false;
            // 
            // kmPerHour
            // 
            this.kmPerHour.AutoSize = true;
            this.kmPerHour.Location = new System.Drawing.Point(20, 77);
            this.kmPerHour.Name = "kmPerHour";
            this.kmPerHour.Size = new System.Drawing.Size(39, 15);
            this.kmPerHour.TabIndex = 4;
            this.kmPerHour.Text = "Km/H";
            // 
            // Speedometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kmPerHour);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.speedMark);
            this.Controls.Add(this.speedometerCar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Speedometer";
            this.Size = new System.Drawing.Size(81, 92);
            ((System.ComponentModel.ISupportInitialize)(this.speedMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedometerCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox speedMark;
        private TextBox speedBox;
        private PictureBox speedometerCar;
        private Label kmPerHour;
    }
}
