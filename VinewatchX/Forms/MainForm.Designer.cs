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
            this.openVinesaucePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToVinesaucecomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitVinewatchXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsButton = new System.Windows.Forms.Button();
            this.minToTrayButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.versionLabel = new System.Windows.Forms.Label();
            this.pictureBoxArt = new System.Windows.Forms.LinkLabel();
            this.aboutLabel = new System.Windows.Forms.LinkLabel();
            this.vinesauceDotcomLinkLabel = new System.Windows.Forms.LinkLabel();
            this.muteRadioButton = new System.Windows.Forms.CheckBox();
            this.lastReportLabel = new System.Windows.Forms.Label();
            this.linkLabelForums = new System.Windows.Forms.LinkLabel();
            this.linkLabelBooru = new System.Windows.Forms.LinkLabel();
            this.openPlayerButton = new System.Windows.Forms.Button();
            this.vinnyEastereggPanel = new System.Windows.Forms.Panel();
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
            this.openVinesaucePlayerToolStripMenuItem,
            this.goToVinesaucecomToolStripMenuItem,
            this.exitVinewatchXToolStripMenuItem});
            this.notificationIconContextStrip.Name = "notificationIconContextStrip";
            this.notificationIconContextStrip.Size = new System.Drawing.Size(196, 114);
            // 
            // settingsFileToolStripMenuItem
            // 
            this.settingsFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.settingsFileToolStripMenuItem.Name = "settingsFileToolStripMenuItem";
            this.settingsFileToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.settingsFileToolStripMenuItem.Text = "Settings File ...";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.importToolStripMenuItem.Text = "Import ...";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.exportToolStripMenuItem.Text = "Export ...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // startWithWindowsToolStripMenuItem
            // 
            this.startWithWindowsToolStripMenuItem.Name = "startWithWindowsToolStripMenuItem";
            this.startWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.startWithWindowsToolStripMenuItem.Text = "Run at Start-Up ...";
            this.startWithWindowsToolStripMenuItem.Click += new System.EventHandler(this.startWithWindowsToolStripMenuItem_Click);
            // 
            // openVinesaucePlayerToolStripMenuItem
            // 
            this.openVinesaucePlayerToolStripMenuItem.Name = "openVinesaucePlayerToolStripMenuItem";
            this.openVinesaucePlayerToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openVinesaucePlayerToolStripMenuItem.Text = "Open Vinesauce Player";
            this.openVinesaucePlayerToolStripMenuItem.Click += new System.EventHandler(this.openVinesaucePlayerToolStripMenuItem_Click);
            // 
            // goToVinesaucecomToolStripMenuItem
            // 
            this.goToVinesaucecomToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goToVinesaucecomToolStripMenuItem.Name = "goToVinesaucecomToolStripMenuItem";
            this.goToVinesaucecomToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.goToVinesaucecomToolStripMenuItem.Text = "Go to Vinesauce.com";
            this.goToVinesaucecomToolStripMenuItem.Click += new System.EventHandler(this.goToVinesaucecomToolStripMenuItem_Click);
            // 
            // exitVinewatchXToolStripMenuItem
            // 
            this.exitVinewatchXToolStripMenuItem.Name = "exitVinewatchXToolStripMenuItem";
            this.exitVinewatchXToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exitVinewatchXToolStripMenuItem.Text = "Exit VinewatchX";
            this.exitVinewatchXToolStripMenuItem.Click += new System.EventHandler(this.exitVinewatchXToolStripMenuItem_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsButton.Location = new System.Drawing.Point(343, 468);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(95, 23);
            this.optionsButton.TabIndex = 0;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // minToTrayButton
            // 
            this.minToTrayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minToTrayButton.Location = new System.Drawing.Point(230, 468);
            this.minToTrayButton.Name = "minToTrayButton";
            this.minToTrayButton.Size = new System.Drawing.Size(107, 23);
            this.minToTrayButton.TabIndex = 3;
            this.minToTrayButton.Text = "Minimize To Tray";
            this.minToTrayButton.UseVisualStyleBackColor = true;
            this.minToTrayButton.Click += new System.EventHandler(this.minToTrayButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::VinewatchX.Properties.Resources.rideneverends;
            this.pictureBox1.Location = new System.Drawing.Point(127, 158);
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
            this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Location = new System.Drawing.Point(92, 501);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(59, 13);
            this.versionLabel.TabIndex = 6;
            this.versionLabel.Text = "setOnLoad";
            this.versionLabel.Click += new System.EventHandler(this.versionLabel_Click);
            // 
            // pictureBoxArt
            // 
            this.pictureBoxArt.ActiveLinkColor = System.Drawing.Color.Green;
            this.pictureBoxArt.AutoSize = true;
            this.pictureBoxArt.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxArt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBoxArt.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pictureBoxArt.Location = new System.Drawing.Point(338, 432);
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
            this.aboutLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.aboutLabel.Location = new System.Drawing.Point(406, 501);
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
            this.vinesauceDotcomLinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.vinesauceDotcomLinkLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vinesauceDotcomLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.vinesauceDotcomLinkLabel.Location = new System.Drawing.Point(13, 110);
            this.vinesauceDotcomLinkLabel.Name = "vinesauceDotcomLinkLabel";
            this.vinesauceDotcomLinkLabel.Size = new System.Drawing.Size(210, 21);
            this.vinesauceDotcomLinkLabel.TabIndex = 11;
            this.vinesauceDotcomLinkLabel.TabStop = true;
            this.vinesauceDotcomLinkLabel.Text = "Click here to go to Vinesauce";
            this.vinesauceDotcomLinkLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.vinesauceDotcomLinkLabel.VisitedLinkColor = System.Drawing.Color.Green;
            this.vinesauceDotcomLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.vinesauceDotcomLinkLabel_LinkClicked);
            // 
            // muteRadioButton
            // 
            this.muteRadioButton.AutoSize = true;
            this.muteRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.muteRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muteRadioButton.ForeColor = System.Drawing.Color.White;
            this.muteRadioButton.Location = new System.Drawing.Point(344, 501);
            this.muteRadioButton.Name = "muteRadioButton";
            this.muteRadioButton.Size = new System.Drawing.Size(50, 17);
            this.muteRadioButton.TabIndex = 15;
            this.muteRadioButton.Text = "Mute";
            this.muteRadioButton.UseVisualStyleBackColor = false;
            // 
            // lastReportLabel
            // 
            this.lastReportLabel.BackColor = System.Drawing.Color.Transparent;
            this.lastReportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastReportLabel.ForeColor = System.Drawing.Color.White;
            this.lastReportLabel.Location = new System.Drawing.Point(4, 72);
            this.lastReportLabel.MaximumSize = new System.Drawing.Size(600, 39);
            this.lastReportLabel.Name = "lastReportLabel";
            this.lastReportLabel.Size = new System.Drawing.Size(531, 22);
            this.lastReportLabel.TabIndex = 8;
            this.lastReportLabel.Text = "Checking poller thread ...";
            this.lastReportLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelForums
            // 
            this.linkLabelForums.AutoSize = true;
            this.linkLabelForums.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelForums.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelForums.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabelForums.Location = new System.Drawing.Point(239, 111);
            this.linkLabelForums.Name = "linkLabelForums";
            this.linkLabelForums.Size = new System.Drawing.Size(137, 21);
            this.linkLabelForums.TabIndex = 17;
            this.linkLabelForums.TabStop = true;
            this.linkLabelForums.Text = "Vinesauce Forums";
            this.linkLabelForums.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelForums_LinkClicked);
            // 
            // linkLabelBooru
            // 
            this.linkLabelBooru.AutoSize = true;
            this.linkLabelBooru.BackColor = System.Drawing.Color.Transparent;
            this.linkLabelBooru.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.linkLabelBooru.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.linkLabelBooru.Location = new System.Drawing.Point(390, 111);
            this.linkLabelBooru.Name = "linkLabelBooru";
            this.linkLabelBooru.Size = new System.Drawing.Size(126, 21);
            this.linkLabelBooru.TabIndex = 18;
            this.linkLabelBooru.TabStop = true;
            this.linkLabelBooru.Text = "Vinesauce Booru";
            this.linkLabelBooru.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelBooru_LinkClicked);
            // 
            // openPlayerButton
            // 
            this.openPlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openPlayerButton.Location = new System.Drawing.Point(94, 468);
            this.openPlayerButton.Name = "openPlayerButton";
            this.openPlayerButton.Size = new System.Drawing.Size(130, 23);
            this.openPlayerButton.TabIndex = 19;
            this.openPlayerButton.Text = "Open Vinesauce Player";
            this.openPlayerButton.UseVisualStyleBackColor = true;
            this.openPlayerButton.Click += new System.EventHandler(this.openPlayerButton_Click);
            // 
            // vinnyEastereggPanel
            // 
            this.vinnyEastereggPanel.BackColor = System.Drawing.Color.Transparent;
            this.vinnyEastereggPanel.Location = new System.Drawing.Point(43, 21);
            this.vinnyEastereggPanel.Name = "vinnyEastereggPanel";
            this.vinnyEastereggPanel.Size = new System.Drawing.Size(37, 37);
            this.vinnyEastereggPanel.TabIndex = 20;
            this.vinnyEastereggPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.vinnyEastereggPanel_MouseClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::VinewatchX.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(536, 536);
            this.Controls.Add(this.vinnyEastereggPanel);
            this.Controls.Add(this.openPlayerButton);
            this.Controls.Add(this.linkLabelBooru);
            this.Controls.Add(this.linkLabelForums);
            this.Controls.Add(this.muteRadioButton);
            this.Controls.Add(this.pictureBoxArt);
            this.Controls.Add(this.vinesauceDotcomLinkLabel);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.minToTrayButton);
            this.Controls.Add(this.lastReportLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "VinewatchX";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.notificationIconContextStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button minToTrayButton;
        private System.Windows.Forms.ContextMenuStrip notificationIconContextStrip;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label versionLabel;
        public System.Windows.Forms.NotifyIcon notificationIcon;
        private System.Windows.Forms.LinkLabel pictureBoxArt;
        private System.Windows.Forms.LinkLabel aboutLabel;
        private System.Windows.Forms.LinkLabel vinesauceDotcomLinkLabel;
        private System.Windows.Forms.ToolStripMenuItem exitVinewatchXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWithWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        internal System.Windows.Forms.CheckBox muteRadioButton;
        private System.Windows.Forms.ToolStripMenuItem goToVinesaucecomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVinesaucePlayerToolStripMenuItem;
        public System.Windows.Forms.Label lastReportLabel;
        private System.Windows.Forms.LinkLabel linkLabelForums;
        private System.Windows.Forms.LinkLabel linkLabelBooru;
        private System.Windows.Forms.Button openPlayerButton;
        private System.Windows.Forms.Panel vinnyEastereggPanel;

    }
}

