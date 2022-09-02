namespace Enviroment.View
{
    partial class Tachometer
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
            this.tachometerNumbers = new System.Windows.Forms.PictureBox();
            this.tachometerMark = new System.Windows.Forms.PictureBox();
            this.tachometerBox = new System.Windows.Forms.TextBox();
            this.rpm = new System.Windows.Forms.Label();
            this.rpmLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tachometerNumbers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tachometerMark)).BeginInit();
            this.SuspendLayout();
            // 
            // tachometerNumbers
            // 
            this.tachometerNumbers.Image = global::Properties.Resources.Tachometer;
            this.tachometerNumbers.Location = new System.Drawing.Point(0, 0);
            this.tachometerNumbers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tachometerNumbers.Name = "tachometerNumbers";
            this.tachometerNumbers.Size = new System.Drawing.Size(80, 79);
            this.tachometerNumbers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.tachometerNumbers.TabIndex = 0;
            this.tachometerNumbers.TabStop = false;
            // 
            // tachometerMark
            // 
            this.tachometerMark.BackgroundImage = global::Properties.Resources.SpeedometerMark;
            this.tachometerMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tachometerMark.Location = new System.Drawing.Point(25, 22);
            this.tachometerMark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tachometerMark.Name = "tachometerMark";
            this.tachometerMark.Size = new System.Drawing.Size(35, 35);
            this.tachometerMark.TabIndex = 1;
            this.tachometerMark.TabStop = false;
            // 
            // tachometerBox
            // 
            this.tachometerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tachometerBox.Location = new System.Drawing.Point(35, 51);
            this.tachometerBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tachometerBox.Name = "tachometerBox";
            this.tachometerBox.Size = new System.Drawing.Size(31, 23);
            this.tachometerBox.TabIndex = 2;
            this.tachometerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rpm
            // 
            this.rpm.AutoSize = true;
            this.rpm.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rpm.Location = new System.Drawing.Point(36, 74);
            this.rpm.Name = "rpm";
            this.rpm.Size = new System.Drawing.Size(39, 13);
            this.rpm.TabIndex = 3;
            this.rpm.Text = "x 1000";
            // 
            // rpmLabel
            // 
            this.rpmLabel.AutoSize = true;
            this.rpmLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rpmLabel.Location = new System.Drawing.Point(35, 88);
            this.rpmLabel.Name = "label1";
            this.rpmLabel.Size = new System.Drawing.Size(30, 13);
            this.rpmLabel.TabIndex = 4;
            this.rpmLabel.Text = "RPM";
            // 
            // Tachometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rpmLabel);
            this.Controls.Add(this.rpm);
            this.Controls.Add(this.tachometerBox);
            this.Controls.Add(this.tachometerMark);
            this.Controls.Add(this.tachometerNumbers);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Tachometer";
            this.Size = new System.Drawing.Size(81, 101);
            ((System.ComponentModel.ISupportInitialize)(this.tachometerNumbers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tachometerMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox tachometerNumbers;
        private PictureBox tachometerMark;
        private TextBox tachometerBox;
        private Label rpm;
        private Label rpmLabel;
    }
}
