namespace Arduheater_GUI.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Statusbar = new System.Windows.Forms.StatusStrip();
            this.LedTX = new System.Windows.Forms.ToolStripStatusLabel();
            this.LedRX = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Menubar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SerialSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payPalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputChart4 = new Arduheater_GUI.OutputChart();
            this.outputChart3 = new Arduheater_GUI.OutputChart();
            this.outputChart2 = new Arduheater_GUI.OutputChart();
            this.outputChart1 = new Arduheater_GUI.OutputChart();
            this.environmentChart1 = new Arduheater_GUI.EnvironmentChart();
            this.Statusbar.SuspendLayout();
            this.Menubar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Statusbar
            // 
            this.Statusbar.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.Statusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LedTX,
            this.LedRX,
            this.StatusLabel});
            this.Statusbar.Location = new System.Drawing.Point(0, 617);
            this.Statusbar.Name = "Statusbar";
            this.Statusbar.Size = new System.Drawing.Size(784, 22);
            this.Statusbar.TabIndex = 27;
            // 
            // LedTX
            // 
            this.LedTX.ActiveLinkColor = System.Drawing.Color.DarkRed;
            this.LedTX.BackColor = System.Drawing.Color.DarkGreen;
            this.LedTX.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LedTX.ForeColor = System.Drawing.Color.White;
            this.LedTX.Name = "LedTX";
            this.LedTX.Size = new System.Drawing.Size(21, 17);
            this.LedTX.Text = "TX";
            // 
            // LedRX
            // 
            this.LedRX.BackColor = System.Drawing.Color.Maroon;
            this.LedRX.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LedRX.ForeColor = System.Drawing.Color.White;
            this.LedRX.Name = "LedRX";
            this.LedRX.Size = new System.Drawing.Size(21, 17);
            this.LedRX.Text = "RX";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(42, 17);
            this.StatusLabel.Text = "Ready.";
            // 
            // Menubar
            // 
            this.Menubar.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Arduheater_GUI.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Menubar.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.Menubar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.supportToolStripMenuItem});
            this.Menubar.Location = global::Arduheater_GUI.Properties.Settings.Default.Location;
            this.Menubar.Name = "Menubar";
            this.Menubar.Size = new System.Drawing.Size(784, 24);
            this.Menubar.TabIndex = 28;
            this.Menubar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.sendToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.connectToolStripMenuItem.Text = "&Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // sendToolStripMenuItem
            // 
            this.sendToolStripMenuItem.Enabled = false;
            this.sendToolStripMenuItem.Name = "sendToolStripMenuItem";
            this.sendToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendToolStripMenuItem.Text = "Send";
            this.sendToolStripMenuItem.Click += new System.EventHandler(this.SendToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SerialSetupToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.viewToolStripMenuItem.Text = "&Setup";
            // 
            // SerialSetupToolStripMenuItem
            // 
            this.SerialSetupToolStripMenuItem.Name = "SerialSetupToolStripMenuItem";
            this.SerialSetupToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.SerialSetupToolStripMenuItem.Text = "&Serial port";
            this.SerialSetupToolStripMenuItem.Click += new System.EventHandler(this.SerialSetupToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.githubToolStripMenuItem,
            this.twitterToolStripMenuItem,
            this.payPalToolStripMenuItem,
            this.toolStripMenuItem2,
            this.checkForUpdatesToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 6);
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("githubToolStripMenuItem.Image")));
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.githubToolStripMenuItem.Text = "&Github";
            this.githubToolStripMenuItem.Click += new System.EventHandler(this.Open_URL_From_Menu_Item);
            // 
            // twitterToolStripMenuItem
            // 
            this.twitterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("twitterToolStripMenuItem.Image")));
            this.twitterToolStripMenuItem.Name = "twitterToolStripMenuItem";
            this.twitterToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.twitterToolStripMenuItem.Text = "&Twitter";
            this.twitterToolStripMenuItem.Click += new System.EventHandler(this.Open_URL_From_Menu_Item);
            // 
            // payPalToolStripMenuItem
            // 
            this.payPalToolStripMenuItem.Image = global::Arduheater_GUI.Properties.Resources.paypal;
            this.payPalToolStripMenuItem.Name = "payPalToolStripMenuItem";
            this.payPalToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.payPalToolStripMenuItem.Text = "&PayPal";
            this.payPalToolStripMenuItem.Click += new System.EventHandler(this.Open_URL_From_Menu_Item);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "&Check for Updates";
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.supportToolStripMenuItem.Text = "&Support";
            this.supportToolStripMenuItem.Click += new System.EventHandler(this.Open_URL_From_Menu_Item);
            // 
            // outputChart4
            // 
            this.outputChart4.BackColor = System.Drawing.SystemColors.Control;
            this.outputChart4.Location = new System.Drawing.Point(395, 465);
            this.outputChart4.Name = "outputChart4";
            this.outputChart4.OutputIndex = 4;
            this.outputChart4.Size = new System.Drawing.Size(377, 145);
            this.outputChart4.TabIndex = 26;
            this.outputChart4.Title = "Output chart";
            this.outputChart4.EditButtonClick += new System.EventHandler(this.EditButtonClick);
            this.outputChart4.PowerButtonClick += new System.EventHandler(this.PowerButtonClick);
            // 
            // outputChart3
            // 
            this.outputChart3.BackColor = System.Drawing.SystemColors.Control;
            this.outputChart3.Location = new System.Drawing.Point(12, 465);
            this.outputChart3.Name = "outputChart3";
            this.outputChart3.OutputIndex = 3;
            this.outputChart3.Size = new System.Drawing.Size(377, 145);
            this.outputChart3.TabIndex = 25;
            this.outputChart3.Title = "Output chart";
            this.outputChart3.EditButtonClick += new System.EventHandler(this.EditButtonClick);
            this.outputChart3.PowerButtonClick += new System.EventHandler(this.PowerButtonClick);
            // 
            // outputChart2
            // 
            this.outputChart2.BackColor = System.Drawing.SystemColors.Control;
            this.outputChart2.Location = new System.Drawing.Point(395, 314);
            this.outputChart2.Name = "outputChart2";
            this.outputChart2.OutputIndex = 2;
            this.outputChart2.Size = new System.Drawing.Size(377, 145);
            this.outputChart2.TabIndex = 24;
            this.outputChart2.Title = "Output chart";
            this.outputChart2.EditButtonClick += new System.EventHandler(this.EditButtonClick);
            this.outputChart2.PowerButtonClick += new System.EventHandler(this.PowerButtonClick);
            // 
            // outputChart1
            // 
            this.outputChart1.BackColor = System.Drawing.SystemColors.Control;
            this.outputChart1.Location = new System.Drawing.Point(12, 314);
            this.outputChart1.Name = "outputChart1";
            this.outputChart1.OutputIndex = 1;
            this.outputChart1.Size = new System.Drawing.Size(377, 145);
            this.outputChart1.TabIndex = 23;
            this.outputChart1.Title = "Output chart";
            this.outputChart1.EditButtonClick += new System.EventHandler(this.EditButtonClick);
            this.outputChart1.PowerButtonClick += new System.EventHandler(this.PowerButtonClick);
            // 
            // environmentChart1
            // 
            this.environmentChart1.BackColor = System.Drawing.SystemColors.Control;
            this.environmentChart1.Location = new System.Drawing.Point(12, 30);
            this.environmentChart1.Name = "environmentChart1";
            this.environmentChart1.Size = new System.Drawing.Size(760, 278);
            this.environmentChart1.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 639);
            this.Controls.Add(this.Statusbar);
            this.Controls.Add(this.Menubar);
            this.Controls.Add(this.outputChart4);
            this.Controls.Add(this.outputChart3);
            this.Controls.Add(this.outputChart2);
            this.Controls.Add(this.outputChart1);
            this.Controls.Add(this.environmentChart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Menubar;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 1045);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arduheater GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Statusbar.ResumeLayout(false);
            this.Statusbar.PerformLayout();
            this.Menubar.ResumeLayout(false);
            this.Menubar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private EnvironmentChart environmentChart1;
        private OutputChart outputChart1;
        private OutputChart outputChart2;
        private OutputChart outputChart3;
        private OutputChart outputChart4;
        private System.Windows.Forms.StatusStrip Statusbar;
        private System.Windows.Forms.MenuStrip Menubar;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SerialSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel LedTX;
        private System.Windows.Forms.ToolStripStatusLabel LedRX;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payPalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
    }
}

