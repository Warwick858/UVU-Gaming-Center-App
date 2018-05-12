namespace UVU_Gaming_Center_App
{
    partial class MessageDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.noBtn = new System.Windows.Forms.Button();
            this.yesBtn = new System.Windows.Forms.Button();
            this.msgDLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // noBtn
            // 
            this.noBtn.AutoSize = true;
            this.noBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noBtn.Location = new System.Drawing.Point(260, 174);
            this.noBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.noBtn.Name = "noBtn";
            this.noBtn.Size = new System.Drawing.Size(115, 34);
            this.noBtn.TabIndex = 7;
            this.noBtn.Text = "NO";
            this.noBtn.UseVisualStyleBackColor = true;
            this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
            // 
            // yesBtn
            // 
            this.yesBtn.AutoSize = true;
            this.yesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesBtn.Location = new System.Drawing.Point(52, 174);
            this.yesBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.Size = new System.Drawing.Size(115, 34);
            this.yesBtn.TabIndex = 6;
            this.yesBtn.Text = "YES";
            this.yesBtn.UseVisualStyleBackColor = true;
            this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
            // 
            // msgDLbl
            // 
            this.msgDLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgDLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgDLbl.Location = new System.Drawing.Point(0, 0);
            this.msgDLbl.Name = "msgDLbl";
            this.msgDLbl.Size = new System.Drawing.Size(428, 230);
            this.msgDLbl.TabIndex = 5;
            this.msgDLbl.Text = "ARE YOU SURE YOU WANT\r\nTO CLOSE THIS PLAYER?";
            this.msgDLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 230);
            this.Controls.Add(this.noBtn);
            this.Controls.Add(this.yesBtn);
            this.Controls.Add(this.msgDLbl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button noBtn;
        public System.Windows.Forms.Button yesBtn;
        private System.Windows.Forms.Label msgDLbl;
    }
}