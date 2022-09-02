namespace Enviroment.View
{
    partial class Compass
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
            this.bottomNeedle = new System.Windows.Forms.PictureBox();
            this.topNeedle = new System.Windows.Forms.PictureBox();
            this.display = new System.Windows.Forms.Panel();
            this.directions = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bottomNeedle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topNeedle)).BeginInit();
            this.display.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomNeedle
            // 
            this.bottomNeedle.Image = global::Properties.Resources.CompassNeedleBottom;
            this.bottomNeedle.Location = new System.Drawing.Point(56, 22);
            this.bottomNeedle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bottomNeedle.Name = "bottomNeedle";
            this.bottomNeedle.Size = new System.Drawing.Size(18, 8);
            this.bottomNeedle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bottomNeedle.TabIndex = 1;
            this.bottomNeedle.TabStop = false;
            // 
            // topNeedle
            // 
            this.topNeedle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.topNeedle.Image = global::Properties.Resources.CompassNeedleTop;
            this.topNeedle.Location = new System.Drawing.Point(60, 17);
            this.topNeedle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.topNeedle.Name = "topNeedle";
            this.topNeedle.Size = new System.Drawing.Size(18, 8);
            this.topNeedle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.topNeedle.TabIndex = 2;
            this.topNeedle.TabStop = false;
            // 
            // display
            // 
            this.display.BackColor = System.Drawing.Color.White;
            this.display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.display.Controls.Add(this.directions);
            this.display.Controls.Add(this.bottomNeedle);
            this.display.Location = new System.Drawing.Point(3, 16);
            this.display.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(132, 32);
            this.display.TabIndex = 3;
            // 
            // directions
            // 
            this.directions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.directions.Location = new System.Drawing.Point(4, 7);
            this.directions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.directions.Name = "directions";
            this.directions.Size = new System.Drawing.Size(119, 16);
            this.directions.TabIndex = 4;
            this.directions.Text = " N • • ¦ • • L • • ¦ • • S • • ¦ • •  ";
            this.directions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(38, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(56, 15);
            this.title.TabIndex = 4;
            this.title.Text = "Compass";
            // 
            // Compass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.topNeedle);
            this.Controls.Add(this.title);
            this.Controls.Add(this.display);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Compass";
            this.Size = new System.Drawing.Size(138, 51);
            ((System.ComponentModel.ISupportInitialize)(this.bottomNeedle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topNeedle)).EndInit();
            this.display.ResumeLayout(false);
            this.display.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox bottomNeedle;
        private PictureBox topNeedle;
        private Panel display;
        private TextBox directions;
        private Label title;
    }
}
