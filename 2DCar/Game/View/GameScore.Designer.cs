namespace CarGame.Game.View
{
    partial class GameScore
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
            this.score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameScore
            // 
            this.Controls.Add(this.score);
            this.Name = "GameScore";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.score.AutoSize = true;
            this.score.Location = new System.Drawing.Point(22, 31);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(0, 15);
            this.score.TabIndex = 0;
            this.score.Visible = false;

        }

        #endregion

        private Label score;
    }
}
