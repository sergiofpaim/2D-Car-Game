namespace Enviroment.View
{
    partial class Pedals
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
            this.acceleratorBox = new System.Windows.Forms.PictureBox();
            this.breakBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.acceleratorBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakBox)).BeginInit();
            this.SuspendLayout();
            // 
            // acceleratorBox
            // 
            this.acceleratorBox.Image = global::Properties.Resources.Accelerator;
            this.acceleratorBox.Location = new System.Drawing.Point(44, 0);
            this.acceleratorBox.Name = "acceleratorBox";
            this.acceleratorBox.Size = new System.Drawing.Size(37, 70);
            this.acceleratorBox.TabIndex = 0;
            this.acceleratorBox.TabStop = false;
            // 
            // breakBox
            // 
            this.breakBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.breakBox.Image = global::Properties.Resources.Break;
            this.breakBox.Location = new System.Drawing.Point(3, 1);
            this.breakBox.Name = "breakBox";
            this.breakBox.Size = new System.Drawing.Size(35, 73);
            this.breakBox.TabIndex = 1;
            this.breakBox.TabStop = false;
            // 
            // Pedals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.breakBox);
            this.Controls.Add(this.acceleratorBox);
            this.Name = "Pedals";
            this.Size = new System.Drawing.Size(97, 71);
            ((System.ComponentModel.ISupportInitialize)(this.acceleratorBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.breakBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox acceleratorBox;
        private PictureBox breakBox;
    }
}
