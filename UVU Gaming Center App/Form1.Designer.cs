namespace UVU_Gaming_Center_App
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Booking = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sLWCWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamingDiagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youTubePlaylistsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statsFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rackBtn = new System.Windows.Forms.Button();
            this.dateMenuLbl = new System.Windows.Forms.Label();
            this.ttlPlayersMenuLbl = new System.Windows.Forms.Label();
            this.timeMenuLbl = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lineUpBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.reservationsToolStripMenuItem,
            this.resourcesToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.addToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1274, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F8)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            this.windowsToolStripMenuItem.Click += new System.EventHandler(this.windowsToolStripMenuItem_Click);
            // 
            // reservationsToolStripMenuItem
            // 
            this.reservationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Booking,
            this.createToolStripMenuItem});
            this.reservationsToolStripMenuItem.Name = "reservationsToolStripMenuItem";
            this.reservationsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.reservationsToolStripMenuItem.Text = "Reservations";
            // 
            // Booking
            // 
            this.Booking.Name = "Booking";
            this.Booking.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.Booking.Size = new System.Drawing.Size(191, 22);
            this.Booking.Text = "Booking";
            this.Booking.Click += new System.EventHandler(this.bookingToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.signageToolStripMenuItem,
            this.invoiceToolStripMenuItem,
            this.receiptToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // signageToolStripMenuItem
            // 
            this.signageToolStripMenuItem.Name = "signageToolStripMenuItem";
            this.signageToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.signageToolStripMenuItem.Text = "Signage";
            this.signageToolStripMenuItem.Click += new System.EventHandler(this.signageToolStripMenuItem_Click);
            // 
            // invoiceToolStripMenuItem
            // 
            this.invoiceToolStripMenuItem.Name = "invoiceToolStripMenuItem";
            this.invoiceToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.invoiceToolStripMenuItem.Text = "Confirmation";
            this.invoiceToolStripMenuItem.Click += new System.EventHandler(this.confirmationToolStripMenuItem_Click);
            // 
            // receiptToolStripMenuItem
            // 
            this.receiptToolStripMenuItem.Name = "receiptToolStripMenuItem";
            this.receiptToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.receiptToolStripMenuItem.Text = "Receipt";
            this.receiptToolStripMenuItem.Click += new System.EventHandler(this.receiptToolStripMenuItem_Click);
            // 
            // resourcesToolStripMenuItem
            // 
            this.resourcesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sLWCWebsiteToolStripMenuItem,
            this.gamingDiagramToolStripMenuItem,
            this.youTubePlaylistsToolStripMenuItem});
            this.resourcesToolStripMenuItem.Name = "resourcesToolStripMenuItem";
            this.resourcesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.resourcesToolStripMenuItem.Text = "Resources";
            // 
            // sLWCWebsiteToolStripMenuItem
            // 
            this.sLWCWebsiteToolStripMenuItem.Name = "sLWCWebsiteToolStripMenuItem";
            this.sLWCWebsiteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.W)));
            this.sLWCWebsiteToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.sLWCWebsiteToolStripMenuItem.Text = "SLWC Website";
            this.sLWCWebsiteToolStripMenuItem.Click += new System.EventHandler(this.sLWCWebsiteToolStripMenuItem_Click);
            // 
            // gamingDiagramToolStripMenuItem
            // 
            this.gamingDiagramToolStripMenuItem.Name = "gamingDiagramToolStripMenuItem";
            this.gamingDiagramToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.gamingDiagramToolStripMenuItem.Text = "Gaming Diagram";
            this.gamingDiagramToolStripMenuItem.Click += new System.EventHandler(this.gamingDiagramToolStripMenuItem_Click);
            // 
            // youTubePlaylistsToolStripMenuItem
            // 
            this.youTubePlaylistsToolStripMenuItem.Name = "youTubePlaylistsToolStripMenuItem";
            this.youTubePlaylistsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Y)));
            this.youTubePlaylistsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.youTubePlaylistsToolStripMenuItem.Text = "YouTube Playlists";
            this.youTubePlaylistsToolStripMenuItem.Click += new System.EventHandler(this.youTubePlaylistsToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statsFormToolStripMenuItem});
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            // 
            // statsFormToolStripMenuItem
            // 
            this.statsFormToolStripMenuItem.Name = "statsFormToolStripMenuItem";
            this.statsFormToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.statsFormToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.statsFormToolStripMenuItem.Text = "Stats Form";
            this.statsFormToolStripMenuItem.Click += new System.EventHandler(this.statsFormToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.playerToolStripMenuItem.Text = "Player";
            this.playerToolStripMenuItem.Click += new System.EventHandler(this.playerToolStripMenuItem_Click);
            // 
            // rackBtn
            // 
            this.rackBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rackBtn.BackColor = System.Drawing.Color.White;
            this.rackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rackBtn.ForeColor = System.Drawing.Color.Black;
            this.rackBtn.Location = new System.Drawing.Point(503, 1);
            this.rackBtn.Name = "rackBtn";
            this.rackBtn.Size = new System.Drawing.Size(72, 20);
            this.rackBtn.TabIndex = 14;
            this.rackBtn.Text = "Rack em\'";
            this.rackBtn.UseVisualStyleBackColor = false;
            this.rackBtn.Click += new System.EventHandler(this.rackBtn_Click);
            // 
            // dateMenuLbl
            // 
            this.dateMenuLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateMenuLbl.AutoSize = true;
            this.dateMenuLbl.Location = new System.Drawing.Point(1055, 5);
            this.dateMenuLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dateMenuLbl.Name = "dateMenuLbl";
            this.dateMenuLbl.Size = new System.Drawing.Size(28, 13);
            this.dateMenuLbl.TabIndex = 13;
            this.dateMenuLbl.Text = "date";
            // 
            // ttlPlayersMenuLbl
            // 
            this.ttlPlayersMenuLbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ttlPlayersMenuLbl.AutoSize = true;
            this.ttlPlayersMenuLbl.Location = new System.Drawing.Point(550, 5);
            this.ttlPlayersMenuLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ttlPlayersMenuLbl.Name = "ttlPlayersMenuLbl";
            this.ttlPlayersMenuLbl.Size = new System.Drawing.Size(71, 13);
            this.ttlPlayersMenuLbl.TabIndex = 12;
            this.ttlPlayersMenuLbl.Text = "Total Players:";
            this.ttlPlayersMenuLbl.Visible = false;
            // 
            // timeMenuLbl
            // 
            this.timeMenuLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeMenuLbl.AutoSize = true;
            this.timeMenuLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.timeMenuLbl.Location = new System.Drawing.Point(1202, 5);
            this.timeMenuLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeMenuLbl.Name = "timeMenuLbl";
            this.timeMenuLbl.Size = new System.Drawing.Size(26, 13);
            this.timeMenuLbl.TabIndex = 11;
            this.timeMenuLbl.Text = "time";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lineUpBtn
            // 
            this.lineUpBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lineUpBtn.BackColor = System.Drawing.Color.White;
            this.lineUpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lineUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineUpBtn.ForeColor = System.Drawing.Color.Black;
            this.lineUpBtn.Location = new System.Drawing.Point(617, 1);
            this.lineUpBtn.Name = "lineUpBtn";
            this.lineUpBtn.Size = new System.Drawing.Size(72, 20);
            this.lineUpBtn.TabIndex = 16;
            this.lineUpBtn.Text = "Line-Up";
            this.lineUpBtn.UseVisualStyleBackColor = false;
            this.lineUpBtn.Click += new System.EventHandler(this.lineUpBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 732);
            this.Controls.Add(this.lineUpBtn);
            this.Controls.Add(this.rackBtn);
            this.Controls.Add(this.dateMenuLbl);
            this.Controls.Add(this.ttlPlayersMenuLbl);
            this.Controls.Add(this.timeMenuLbl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "UVU Gaming Center";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Booking;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sLWCWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamingDiagramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem youTubePlaylistsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statsFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.Button rackBtn;
        private System.Windows.Forms.Label dateMenuLbl;
        private System.Windows.Forms.Label ttlPlayersMenuLbl;
        private System.Windows.Forms.Label timeMenuLbl;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button lineUpBtn;
    }
}

