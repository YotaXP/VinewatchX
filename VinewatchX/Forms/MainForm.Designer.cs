namespace VinewatchX.Forms
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
            this.components = new System.ComponentModel.Container();
            this.notificationIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notificationIconContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWithWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitVinewatchXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.exportSettingsButton = new System.Windows.Forms.Button();
            this.importSettingsButton = new System.Windows.Forms.Button();
            this.minToTrayButton = new System.Windows.Forms.Button();
            this.notifyTestButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.lastReportDescLabel = new System.Windows.Forms.Label();
            this.lastReportLabel = new System.Windows.Forms.Label();
            this.pictureBoxArt = new System.Windows.Forms.LinkLabel();
            this.aboutLabel = new System.Windows.Forms.LinkLabel();
            this.vinesauceDotcomLinkLabel = new System.Windows.Forms.LinkLabel();
            this.debugButton = new System.Windows.Forms.Panel();
            this.supressionRadioButton = new System.Windows.Forms.CheckBox();
            this.muteRadioButton = new System.Windows.Forms.CheckBox();
            this.goToVinesaucecomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationIconContextStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notificationIcon
            // 
            this.notificationIcon.ContextMenuStrip = this.notificationIconContextStrip;
            this.notificationIcon.Text = "VinewatchX";
            this.notificationIcon.Visible = true;
            this.notificationIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notificationIcon_MouseDoubleClick);
            // 
            // notificationIconContextStrip
            // 
            this.notificationIconContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsFileToolStripMenuItem,
            this.startWithWindowsToolStripMenuItem,
            this.goToVinesaucecomToolStripMenuItem,
            this.exitVinewatchXToolStripMenuItem});
            this.notificationIconContextStrip.Name = "notificationIconContextStrip";
            this.notificationIconContextStrip.Size = new System.Drawing.Size(177, 92);
            // 
            // settingsFileToolStripMenuItem
            // 
            this.settingsFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.settingsFileToolStripMenuItem.Name = "settingsFileToolStripMenuItem";
            this.settingsFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.settingsFileToolStripMenuItem.Text = "Settings File ...";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.importToolStripMenuItem.Text = "Import ...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exportToolStripMenuItem.Text = "Export ...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // startWithWindowsToolStripMenuItem
            // 
            this.startWithWindowsToolStripMenuItem.Name = "startWithWindowsToolStripMenuItem";
            this.startWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.startWithWindowsToolStripMenuItem.Text = "Run at Start-Up ...";
            this.startWithWindowsToolStripMenuItem.Click += new System.EventHandler(this.startWithWindowsToolStripMenuItem_Click);
            // 
            // exitVinewatchXToolStripMenuItem
            // 
            this.exitVinewatchXToolStripMenuItem.Name = "exitVinewatchXToolStripMenuItem";
            this.exitVinewatchXToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exitVinewatchXToolStripMenuItem.Text = "Exit VinewatchX";
            this.exitVinewatchXToolStripMenuItem.Click += new System.EventHandler(this.exitVinewatchXToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Options";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // exportSettingsButton
            // 
            this.exportSettingsButton.Location = new System.Drawing.Point(155, 365);
            this.exportSettingsButton.Name = "exportSettingsButton";
            this.exportSettingsButton.Size = new System.Drawing.Size(95, 23);
            this.exportSettingsButton.TabIndex = 1;
            this.exportSettingsButton.Text = "Export Settings";
            this.exportSettingsButton.UseVisualStyleBackColor = true;
            this.exportSettingsButton.Click += new System.EventHandler(this.exportSettingsButton_Click);
            // 
            // importSettingsButton
            // 
            this.importSettingsButton.Location = new System.Drawing.Point(54, 365);
            this.importSettingsButton.Name = "importSettingsButton";
            this.importSettingsButton.Size = new System.Drawing.Size(95, 23);
            this.importSettingsButton.TabIndex = 2;
            this.importSettingsButton.Text = "Import Settings";
            this.importSettingsButton.UseVisualStyleBackColor = true;
            this.importSettingsButton.Click += new System.EventHandler(this.importSettingsButton_Click);
            // 
            // minToTrayButton
            // 
            this.minToTrayButton.Location = new System.Drawing.Point(54, 394);
            this.minToTrayButton.Name = "minToTrayButton";
            this.minToTrayButton.Size = new System.Drawing.Size(196, 23);
            this.minToTrayButton.TabIndex = 3;
            this.minToTrayButton.Text = "Minimize To Tray";
            this.minToTrayButton.UseVisualStyleBackColor = true;
            this.minToTrayButton.Click += new System.EventHandler(this.minToTrayButton_Click);
            // 
            // notifyTestButton
            // 
            this.notifyTestButton.Location = new System.Drawing.Point(155, 336);
            this.notifyTestButton.Name = "notifyTestButton";
            this.notifyTestButton.Size = new System.Drawing.Size(95, 23);
            this.notifyTestButton.TabIndex = 4;
            this.notifyTestButton.Text = "Test Notify";
            this.notifyTestButton.UseVisualStyleBackColor = true;
            this.notifyTestButton.Click += new System.EventHandler(this.notifyTestButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::VinewatchX.Properties.Resources.OvYVTBc;
            this.pictureBox1.Location = new System.Drawing.Point(13, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 270);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // versionLabel
            // 
            this.versionLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(10, 476);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(59, 13);
            this.versionLabel.TabIndex = 6;
            this.versionLabel.Text = "setOnLoad";
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // lastReportDescLabel
            // 
            this.lastReportDescLabel.AutoSize = true;
            this.lastReportDescLabel.Location = new System.Drawing.Point(10, 425);
            this.lastReportDescLabel.Name = "lastReportDescLabel";
            this.lastReportDescLabel.Size = new System.Drawing.Size(65, 13);
            this.lastReportDescLabel.TabIndex = 7;
            this.lastReportDescLabel.Text = "Last Report:";
            // 
            // lastReportLabel
            // 
            this.lastReportLabel.AutoSize = true;
            this.lastReportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastReportLabel.Location = new System.Drawing.Point(21, 443);
            this.lastReportLabel.MaximumSize = new System.Drawing.Size(250, 0);
            this.lastReportLabel.Name = "lastReportLabel";
            this.lastReportLabel.Size = new System.Drawing.Size(125, 13);
            this.lastReportLabel.TabIndex = 8;
            this.lastReportLabel.Text = "Checking poller thread ...";
            // 
            // pictureBoxArt
            // 
            this.pictureBoxArt.ActiveLinkColor = System.Drawing.Color.Green;
            this.pictureBoxArt.AutoSize = true;
            this.pictureBoxArt.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pictureBoxArt.Location = new System.Drawing.Point(12, 312);
            this.pictureBoxArt.Name = "pictureBoxArt";
            this.pictureBoxArt.Size = new System.Drawing.Size(72, 13);
            this.pictureBoxArt.TabIndex = 9;
            this.pictureBoxArt.TabStop = true;
            this.pictureBoxArt.Text = "Art by Matayu";
            this.pictureBoxArt.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pictureBoxArt_LinkClicked);
            // 
            // aboutLabel
            // 
            this.aboutLabel.ActiveLinkColor = System.Drawing.Color.Green;
            this.aboutLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.aboutLabel.Location = new System.Drawing.Point(260, 476);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(35, 13);
            this.aboutLabel.TabIndex = 10;
            this.aboutLabel.TabStop = true;
            this.aboutLabel.Text = "About";
            this.aboutLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLabel_LinkClicked);
            // 
            // vinesauceDotcomLinkLabel
            // 
            this.vinesauceDotcomLinkLabel.AutoSize = true;
            this.vinesauceDotcomLinkLabel.BackColor = System.Drawing.SystemColors.Control;
            this.vinesauceDotcomLinkLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vinesauceDotcomLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.vinesauceDotcomLinkLabel.Location = new System.Drawing.Point(50, 9);
            this.vinesauceDotcomLinkLabel.Name = "vinesauceDotcomLinkLabel";
            this.vinesauceDotcomLinkLabel.Size = new System.Drawing.Size(210, 21);
            this.vinesauceDotcomLinkLabel.TabIndex = 11;
            this.vinesauceDotcomLinkLabel.TabStop = true;
            this.vinesauceDotcomLinkLabel.Text = "Click here to go to Vinesauce";
            this.vinesauceDotcomLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.vinesauceDotcomLinkLabel.VisitedLinkColor = System.Drawing.Color.Green;
            this.vinesauceDotcomLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.vinesauceDotcomLinkLabel_LinkClicked);
            // 
            // debugButton
            // 
            this.debugButton.Location = new System.Drawing.Point(13, 9);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(31, 18);
            this.debugButton.TabIndex = 13;
            this.debugButton.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // supressionRadioButton
            // 
            this.supressionRadioButton.AutoSize = true;
            this.supressionRadioButton.Checked = true;
            this.supressionRadioButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.supressionRadioButton.Location = new System.Drawing.Point(90, 312);
            this.supressionRadioButton.Name = "supressionRadioButton";
            this.supressionRadioButton.Size = new System.Drawing.Size(151, 17);
            this.supressionRadioButton.TabIndex = 14;
            this.supressionRadioButton.Text = "Supress Connection Errors";
            this.supressionRadioButton.UseVisualStyleBackColor = true;
            this.supressionRadioButton.CheckedChanged += new System.EventHandler(this.supressionRadioButton_CheckedChanged);
            // 
            // muteRadioButton
            // 
            this.muteRadioButton.AutoSize = true;
            this.muteRadioButton.Location = new System.Drawing.Point(248, 312);
            this.muteRadioButton.Name = "muteRadioButton";
            this.muteRadioButton.Size = new System.Drawing.Size(50, 17);
            this.muteRadioButton.TabIndex = 15;
            this.muteRadioButton.Text = "Mute";
            this.muteRadioButton.UseVisualStyleBackColor = true;
            this.muteRadioButton.CheckedChanged += new System.EventHandler(this.muteRadioButton_CheckedChanged);
            // 
            // goToVinesaucecomToolStripMenuItem
            // 
            this.goToVinesaucecomToolStripMenuItem.Name = "goToVinesaucecomToolStripMenuItem";
            this.goToVinesaucecomToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.goToVinesaucecomToolStripMenuItem.Text = "Go to Vinesauce.com";
            this.goToVinesaucecomToolStripMenuItem.Click += new System.EventHandler(this.goToVinesaucecomToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 498);
            this.Controls.Add(this.muteRadioButton);
            this.Controls.Add(this.supressionRadioButton);
            this.Controls.Add(this.debugButton);
            this.Controls.Add(this.importSettingsButton);
            this.Controls.Add(this.pictureBoxArt);
            this.Controls.Add(this.vinesauceDotcomLinkLabel);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.notifyTestButton);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.minToTrayButton);
            this.Controls.Add(this.exportSettingsButton);
            this.Controls.Add(this.lastReportDescLabel);
            this.Controls.Add(this.lastReportLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "VinewatchX";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.notificationIconContextStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button exportSettingsButton;
        private System.Windows.Forms.Button importSettingsButton;
        private System.Windows.Forms.Button minToTrayButton;
        private System.Windows.Forms.ContextMenuStrip notificationIconContextStrip;
        private System.Windows.Forms.Button notifyTestButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label lastReportDescLabel;
        public System.Windows.Forms.Label lastReportLabel;
        public System.Windows.Forms.NotifyIcon notificationIcon;
        private System.Windows.Forms.LinkLabel pictureBoxArt;
        private System.Windows.Forms.LinkLabel aboutLabel;
        private System.Windows.Forms.LinkLabel vinesauceDotcomLinkLabel;
        private System.Windows.Forms.ToolStripMenuItem exitVinewatchXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWithWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.Panel debugButton;
        internal System.Windows.Forms.CheckBox supressionRadioButton;
        internal System.Windows.Forms.CheckBox muteRadioButton;
        private System.Windows.Forms.ToolStripMenuItem goToVinesaucecomToolStripMenuItem;

    }
}

