namespace UVU_Gaming_Center_App
{
    partial class Guest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Guest));
            this.guestCtrlCmboBox = new System.Windows.Forms.ComboBox();
            this.guestNameTxtBox = new System.Windows.Forms.TextBox();
            this.guestCtrlLbl = new System.Windows.Forms.Label();
            this.guestNameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guestCtrlCmboBox
            // 
            this.guestCtrlCmboBox.FormattingEnabled = true;
            this.guestCtrlCmboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.guestCtrlCmboBox.Location = new System.Drawing.Point(81, 64);
            this.guestCtrlCmboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guestCtrlCmboBox.Name = "guestCtrlCmboBox";
            this.guestCtrlCmboBox.Size = new System.Drawing.Size(121, 24);
            this.guestCtrlCmboBox.TabIndex = 7;
            this.guestCtrlCmboBox.Text = "controllers...";
            // 
            // guestNameTxtBox
            // 
            this.guestNameTxtBox.Location = new System.Drawing.Point(81, 20);
            this.guestNameTxtBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guestNameTxtBox.Name = "guestNameTxtBox";
            this.guestNameTxtBox.Size = new System.Drawing.Size(121, 22);
            this.guestNameTxtBox.TabIndex = 6;
            // 
            // guestCtrlLbl
            // 
            this.guestCtrlLbl.AutoSize = true;
            this.guestCtrlLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestCtrlLbl.Location = new System.Drawing.Point(27, 64);
            this.guestCtrlLbl.Name = "guestCtrlLbl";
            this.guestCtrlLbl.Size = new System.Drawing.Size(46, 20);
            this.guestCtrlLbl.TabIndex = 5;
            this.guestCtrlLbl.Text = "Ctrl:";
            // 
            // guestNameLbl
            // 
            this.guestNameLbl.AutoSize = true;
            this.guestNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestNameLbl.Location = new System.Drawing.Point(11, 19);
            this.guestNameLbl.Name = "guestNameLbl";
            this.guestNameLbl.Size = new System.Drawing.Size(63, 20);
            this.guestNameLbl.TabIndex = 4;
            this.guestNameLbl.Text = "Name:";
            // 
            // Guest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 106);
            this.Controls.Add(this.guestCtrlCmboBox);
            this.Controls.Add(this.guestNameTxtBox);
            this.Controls.Add(this.guestCtrlLbl);
            this.Controls.Add(this.guestNameLbl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Guest";
            this.Text = "Guest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox guestCtrlCmboBox;
        public System.Windows.Forms.TextBox guestNameTxtBox;
        private System.Windows.Forms.Label guestCtrlLbl;
        private System.Windows.Forms.Label guestNameLbl;
    }
}