namespace StopWatch_Custom
{
    partial class StopWatch_Custom
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
            this.timerLbl = new System.Windows.Forms.Label();
            this.stopPicBox = new System.Windows.Forms.PictureBox();
            this.startPicBox = new System.Windows.Forms.PictureBox();
            this.resetPicBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.stopPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timerLbl
            // 
            this.timerLbl.AutoSize = true;
            this.timerLbl.BackColor = System.Drawing.Color.Black;
            this.timerLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.timerLbl.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLbl.ForeColor = System.Drawing.Color.Lime;
            this.timerLbl.Location = new System.Drawing.Point(165, 8);
            this.timerLbl.Name = "timerLbl";
            this.timerLbl.Size = new System.Drawing.Size(145, 38);
            this.timerLbl.TabIndex = 4;
            this.timerLbl.Text = "00:00:00";
            // 
            // stopPicBox
            // 
            this.stopPicBox.BackgroundImage = global::StopWatch_Custom.Properties.Resources.Stop;
            this.stopPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stopPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopPicBox.Location = new System.Drawing.Point(111, 3);
            this.stopPicBox.Name = "stopPicBox";
            this.stopPicBox.Size = new System.Drawing.Size(47, 47);
            this.stopPicBox.TabIndex = 7;
            this.stopPicBox.TabStop = false;
            this.stopPicBox.Click += new System.EventHandler(this.stopPicBox_Click);
            // 
            // startPicBox
            // 
            this.startPicBox.BackgroundImage = global::StopWatch_Custom.Properties.Resources.Start;
            this.startPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startPicBox.Location = new System.Drawing.Point(61, 3);
            this.startPicBox.Name = "startPicBox";
            this.startPicBox.Size = new System.Drawing.Size(47, 47);
            this.startPicBox.TabIndex = 6;
            this.startPicBox.TabStop = false;
            this.startPicBox.Click += new System.EventHandler(this.startPicBox_Click);
            // 
            // resetPicBox
            // 
            this.resetPicBox.BackgroundImage = global::StopWatch_Custom.Properties.Resources.Restart;
            this.resetPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.resetPicBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetPicBox.Location = new System.Drawing.Point(11, 3);
            this.resetPicBox.Name = "resetPicBox";
            this.resetPicBox.Size = new System.Drawing.Size(47, 47);
            this.resetPicBox.TabIndex = 5;
            this.resetPicBox.TabStop = false;
            this.resetPicBox.Click += new System.EventHandler(this.resetPicBox_Click);
            // 
            // StopWatch_Custom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stopPicBox);
            this.Controls.Add(this.startPicBox);
            this.Controls.Add(this.resetPicBox);
            this.Controls.Add(this.timerLbl);
            this.Name = "StopWatch_Custom";
            this.Size = new System.Drawing.Size(320, 54);
            ((System.ComponentModel.ISupportInitialize)(this.stopPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resetPicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox stopPicBox;
        private System.Windows.Forms.PictureBox startPicBox;
        private System.Windows.Forms.PictureBox resetPicBox;
        private System.Windows.Forms.Label timerLbl;
    }
}
