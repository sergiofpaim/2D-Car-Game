namespace Enviroment.View
{
    partial class SteeringWheel
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
            this.carSteeringWheel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.carSteeringWheel)).BeginInit();
            this.SuspendLayout();
            // 
            // carSteeringWheel
            // 
            this.carSteeringWheel.Image = global::Properties.Resources.SteeringWheel;
            this.carSteeringWheel.Location = new System.Drawing.Point(0, 0);
            this.carSteeringWheel.Name = "carSteeringWheel";
            this.carSteeringWheel.Size = new System.Drawing.Size(103, 103);
            this.carSteeringWheel.TabIndex = 0;
            this.carSteeringWheel.TabStop = false;
            // 
            // SteeringWheel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.carSteeringWheel);
            this.Name = "SteeringWheel";
            this.Size = new System.Drawing.Size(103, 103);
            ((System.ComponentModel.ISupportInitialize)(this.carSteeringWheel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox carSteeringWheel;
    }
}
