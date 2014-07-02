namespace VinewatchX
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.streamerListAddButton = new System.Windows.Forms.Button();
            this.streamerListRefreshButton = new System.Windows.Forms.Button();
            this.streamerListChangeNameButton = new System.Windows.Forms.Button();
            this.createStreamerWarningLabel2 = new System.Windows.Forms.Label();
            this.createStreamerWarningLabel1 = new System.Windows.Forms.Label();
            this.selectionInfoLabel = new System.Windows.Forms.Label();
            this.streamerListDeleteButton = new System.Windows.Forms.Button();
            this.streamerListPlayButton = new System.Windows.Forms.Button();
            this.streamerListBoxInteractButton = new System.Windows.Forms.Button();
            this.optionsFormStreamerListBox = new System.Windows.Forms.ListBox();
            this.streamPollSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.changeBalloonTipTimeoutButton = new System.Windows.Forms.Button();
            this.balloonTipTimeoutlabel = new System.Windows.Forms.Label();
            this.streamCheckLabel4 = new System.Windows.Forms.Label();
            this.streamCheckLabel3 = new System.Windows.Forms.Label();
            this.changePollRateButton = new System.Windows.Forms.Button();
            this.streamCheckPollRateLabel = new System.Windows.Forms.Label();
            this.streamCheckLabel2 = new System.Windows.Forms.Label();
            this.changePollURLButton = new System.Windows.Forms.Button();
            this.streamCheckURLLabel = new System.Windows.Forms.Label();
            this.streamCheckLabel1 = new System.Windows.Forms.Label();
            this.programSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.changeIconButton = new System.Windows.Forms.Button();
            this.iconDisplayPictureBox = new System.Windows.Forms.PictureBox();
            this.iconLabel1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.streamPollSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.programSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconDisplayPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.streamerListAddButton);
            this.groupBox1.Controls.Add(this.streamerListRefreshButton);
            this.groupBox1.Controls.Add(this.streamerListChangeNameButton);
            this.groupBox1.Controls.Add(this.createStreamerWarningLabel2);
            this.groupBox1.Controls.Add(this.createStreamerWarningLabel1);
            this.groupBox1.Controls.Add(this.selectionInfoLabel);
            this.groupBox1.Controls.Add(this.streamerListDeleteButton);
            this.groupBox1.Controls.Add(this.streamerListPlayButton);
            this.groupBox1.Controls.Add(this.streamerListBoxInteractButton);
            this.groupBox1.Controls.Add(this.optionsFormStreamerListBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Streamer Sounds";
            // 
            // streamerListAddButton
            // 
            this.streamerListAddButton.Location = new System.Drawing.Point(325, 65);
            this.streamerListAddButton.Name = "streamerListAddButton";
            this.streamerListAddButton.Size = new System.Drawing.Size(100, 23);
            this.streamerListAddButton.TabIndex = 7;
            this.streamerListAddButton.Text = "Add Streamer";
            this.streamerListAddButton.UseVisualStyleBackColor = true;
            this.streamerListAddButton.Click += new System.EventHandler(this.streamerListAddButton_Click);
            // 
            // streamerListRefreshButton
            // 
            this.streamerListRefreshButton.Location = new System.Drawing.Point(325, 36);
            this.streamerListRefreshButton.Name = "streamerListRefreshButton";
            this.streamerListRefreshButton.Size = new System.Drawing.Size(100, 23);
            this.streamerListRefreshButton.TabIndex = 6;
            this.streamerListRefreshButton.Text = "Refresh List";
            this.streamerListRefreshButton.UseVisualStyleBackColor = true;
            this.streamerListRefreshButton.Click += new System.EventHandler(this.streamerListRefreshButton_Click);
            // 
            // streamerListChangeNameButton
            // 
            this.streamerListChangeNameButton.Location = new System.Drawing.Point(219, 65);
            this.streamerListChangeNameButton.Name = "streamerListChangeNameButton";
            this.streamerListChangeNameButton.Size = new System.Drawing.Size(100, 23);
            this.streamerListChangeNameButton.TabIndex = 5;
            this.streamerListChangeNameButton.Text = "Edit Selected";
            this.streamerListChangeNameButton.UseVisualStyleBackColor = true;
            this.streamerListChangeNameButton.Click += new System.EventHandler(this.streamerListChangeNameButton_Click);
            // 
            // createStreamerWarningLabel2
            // 
            this.createStreamerWarningLabel2.AutoSize = true;
            this.createStreamerWarningLabel2.Location = new System.Drawing.Point(113, 104);
            this.createStreamerWarningLabel2.Name = "createStreamerWarningLabel2";
            this.createStreamerWarningLabel2.Size = new System.Drawing.Size(300, 13);
            this.createStreamerWarningLabel2.TabIndex = 4;
            this.createStreamerWarningLabel2.Text = "  e.g. If the stream title contains \'Vinny\', Vinny\'s sound will play.";
            // 
            // createStreamerWarningLabel1
            // 
            this.createStreamerWarningLabel1.AutoSize = true;
            this.createStreamerWarningLabel1.Location = new System.Drawing.Point(113, 91);
            this.createStreamerWarningLabel1.Name = "createStreamerWarningLabel1";
            this.createStreamerWarningLabel1.Size = new System.Drawing.Size(367, 13);
            this.createStreamerWarningLabel1.TabIndex = 4;
            this.createStreamerWarningLabel1.Text = "The streamer\'s name as it is entered here is the  search string for their sound.";
            // 
            // selectionInfoLabel
            // 
            this.selectionInfoLabel.AutoSize = true;
            this.selectionInfoLabel.Location = new System.Drawing.Point(113, 20);
            this.selectionInfoLabel.Name = "selectionInfoLabel";
            this.selectionInfoLabel.Size = new System.Drawing.Size(89, 13);
            this.selectionInfoLabel.TabIndex = 3;
            this.selectionInfoLabel.Text = "Select a streamer";
            // 
            // streamerListDeleteButton
            // 
            this.streamerListDeleteButton.Location = new System.Drawing.Point(219, 36);
            this.streamerListDeleteButton.Name = "streamerListDeleteButton";
            this.streamerListDeleteButton.Size = new System.Drawing.Size(100, 23);
            this.streamerListDeleteButton.TabIndex = 2;
            this.streamerListDeleteButton.Text = "Delete Selected";
            this.streamerListDeleteButton.UseVisualStyleBackColor = true;
            this.streamerListDeleteButton.Click += new System.EventHandler(this.streamerListDeleteButton_Click);
            // 
            // streamerListPlayButton
            // 
            this.streamerListPlayButton.Location = new System.Drawing.Point(113, 65);
            this.streamerListPlayButton.Name = "streamerListPlayButton";
            this.streamerListPlayButton.Size = new System.Drawing.Size(100, 23);
            this.streamerListPlayButton.TabIndex = 2;
            this.streamerListPlayButton.Text = "Play Sound";
            this.streamerListPlayButton.UseVisualStyleBackColor = true;
            this.streamerListPlayButton.Click += new System.EventHandler(this.streamerListPlayButton_Click);
            // 
            // streamerListBoxInteractButton
            // 
            this.streamerListBoxInteractButton.Location = new System.Drawing.Point(113, 36);
            this.streamerListBoxInteractButton.Name = "streamerListBoxInteractButton";
            this.streamerListBoxInteractButton.Size = new System.Drawing.Size(100, 23);
            this.streamerListBoxInteractButton.TabIndex = 1;
            this.streamerListBoxInteractButton.Text = "Change Sound";
            this.streamerListBoxInteractButton.UseVisualStyleBackColor = true;
            this.streamerListBoxInteractButton.Click += new System.EventHandler(this.streamerListBoxInteractButton_Click);
            // 
            // optionsFormStreamerListBox
            // 
            this.optionsFormStreamerListBox.FormattingEnabled = true;
            this.optionsFormStreamerListBox.Location = new System.Drawing.Point(7, 20);
            this.optionsFormStreamerListBox.Name = "optionsFormStreamerListBox";
            this.optionsFormStreamerListBox.Size = new System.Drawing.Size(100, 225);
            this.optionsFormStreamerListBox.TabIndex = 0;
            this.optionsFormStreamerListBox.SelectedIndexChanged += new System.EventHandler(this.optionsFormStreamerListBox_SelectedIndexChanged);
            // 
            // streamPollSettingsGroupBox
            // 
            this.streamPollSettingsGroupBox.Controls.Add(this.pictureBox1);
            this.streamPollSettingsGroupBox.Controls.Add(this.changeBalloonTipTimeoutButton);
            this.streamPollSettingsGroupBox.Controls.Add(this.balloonTipTimeoutlabel);
            this.streamPollSettingsGroupBox.Controls.Add(this.streamCheckLabel4);
            this.streamPollSettingsGroupBox.Controls.Add(this.streamCheckLabel3);
            this.streamPollSettingsGroupBox.Controls.Add(this.changePollRateButton);
            this.streamPollSettingsGroupBox.Controls.Add(this.streamCheckPollRateLabel);
            this.streamPollSettingsGroupBox.Controls.Add(this.streamCheckLabel2);
            this.streamPollSettingsGroupBox.Controls.Add(this.changePollURLButton);
            this.streamPollSettingsGroupBox.Controls.Add(this.streamCheckURLLabel);
            this.streamPollSettingsGroupBox.Controls.Add(this.streamCheckLabel1);
            this.streamPollSettingsGroupBox.Location = new System.Drawing.Point(13, 276);
            this.streamPollSettingsGroupBox.Name = "streamPollSettingsGroupBox";
            this.streamPollSettingsGroupBox.Size = new System.Drawing.Size(489, 272);
            this.streamPollSettingsGroupBox.TabIndex = 1;
            this.streamPollSettingsGroupBox.TabStop = false;
            this.streamPollSettingsGroupBox.Text = "Stream Poll Settings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VinewatchX.Properties.Resources._1324240144374;
            this.pictureBox1.Location = new System.Drawing.Point(355, 151);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // changeBalloonTipTimeoutButton
            // 
            this.changeBalloonTipTimeoutButton.Location = new System.Drawing.Point(29, 227);
            this.changeBalloonTipTimeoutButton.Name = "changeBalloonTipTimeoutButton";
            this.changeBalloonTipTimeoutButton.Size = new System.Drawing.Size(118, 23);
            this.changeBalloonTipTimeoutButton.TabIndex = 9;
            this.changeBalloonTipTimeoutButton.Text = "Change Timeout";
            this.changeBalloonTipTimeoutButton.UseVisualStyleBackColor = true;
            this.changeBalloonTipTimeoutButton.Click += new System.EventHandler(this.changeBalloonTipTimeoutButton_Click);
            // 
            // balloonTipTimeoutlabel
            // 
            this.balloonTipTimeoutlabel.AutoSize = true;
            this.balloonTipTimeoutlabel.Location = new System.Drawing.Point(193, 210);
            this.balloonTipTimeoutlabel.Name = "balloonTipTimeoutlabel";
            this.balloonTipTimeoutlabel.Size = new System.Drawing.Size(59, 13);
            this.balloonTipTimeoutlabel.TabIndex = 8;
            this.balloonTipTimeoutlabel.Text = "setOnLoad";
            // 
            // streamCheckLabel4
            // 
            this.streamCheckLabel4.AutoSize = true;
            this.streamCheckLabel4.Location = new System.Drawing.Point(6, 210);
            this.streamCheckLabel4.Name = "streamCheckLabel4";
            this.streamCheckLabel4.Size = new System.Drawing.Size(172, 13);
            this.streamCheckLabel4.TabIndex = 7;
            this.streamCheckLabel4.Text = "The current Balloon Tip Timeout is:";
            // 
            // streamCheckLabel3
            // 
            this.streamCheckLabel3.AutoSize = true;
            this.streamCheckLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.streamCheckLabel3.Location = new System.Drawing.Point(26, 24);
            this.streamCheckLabel3.Name = "streamCheckLabel3";
            this.streamCheckLabel3.Size = new System.Drawing.Size(220, 13);
            this.streamCheckLabel3.TabIndex = 6;
            this.streamCheckLabel3.Text = "TwitchTV JSON refreshes every 60 seconds!";
            // 
            // changePollRateButton
            // 
            this.changePollRateButton.Location = new System.Drawing.Point(29, 155);
            this.changePollRateButton.Name = "changePollRateButton";
            this.changePollRateButton.Size = new System.Drawing.Size(118, 23);
            this.changePollRateButton.TabIndex = 5;
            this.changePollRateButton.Text = "Change Poll Rate";
            this.changePollRateButton.UseVisualStyleBackColor = true;
            this.changePollRateButton.Click += new System.EventHandler(this.changePollRateButton_Click);
            // 
            // streamCheckPollRateLabel
            // 
            this.streamCheckPollRateLabel.AutoSize = true;
            this.streamCheckPollRateLabel.Location = new System.Drawing.Point(193, 137);
            this.streamCheckPollRateLabel.Name = "streamCheckPollRateLabel";
            this.streamCheckPollRateLabel.Size = new System.Drawing.Size(59, 13);
            this.streamCheckPollRateLabel.TabIndex = 4;
            this.streamCheckPollRateLabel.Text = "setOnLoad";
            // 
            // streamCheckLabel2
            // 
            this.streamCheckLabel2.AutoSize = true;
            this.streamCheckLabel2.Location = new System.Drawing.Point(3, 137);
            this.streamCheckLabel2.Name = "streamCheckLabel2";
            this.streamCheckLabel2.Size = new System.Drawing.Size(129, 13);
            this.streamCheckLabel2.TabIndex = 3;
            this.streamCheckLabel2.Text = "The current polling rate is:";
            // 
            // changePollURLButton
            // 
            this.changePollURLButton.Location = new System.Drawing.Point(29, 82);
            this.changePollURLButton.Name = "changePollURLButton";
            this.changePollURLButton.Size = new System.Drawing.Size(118, 23);
            this.changePollURLButton.TabIndex = 2;
            this.changePollURLButton.Text = "Change URL";
            this.changePollURLButton.UseVisualStyleBackColor = true;
            this.changePollURLButton.Click += new System.EventHandler(this.changePollURLButton_Click);
            // 
            // streamCheckURLLabel
            // 
            this.streamCheckURLLabel.AutoSize = true;
            this.streamCheckURLLabel.Location = new System.Drawing.Point(193, 66);
            this.streamCheckURLLabel.Name = "streamCheckURLLabel";
            this.streamCheckURLLabel.Size = new System.Drawing.Size(59, 13);
            this.streamCheckURLLabel.TabIndex = 1;
            this.streamCheckURLLabel.Text = "setOnLoad";
            // 
            // streamCheckLabel1
            // 
            this.streamCheckLabel1.AutoSize = true;
            this.streamCheckLabel1.Location = new System.Drawing.Point(6, 66);
            this.streamCheckLabel1.Name = "streamCheckLabel1";
            this.streamCheckLabel1.Size = new System.Drawing.Size(181, 13);
            this.streamCheckLabel1.TabIndex = 0;
            this.streamCheckLabel1.Text = "The current stream checking URL is:";
            // 
            // programSettingsGroupBox
            // 
            this.programSettingsGroupBox.Controls.Add(this.changeIconButton);
            this.programSettingsGroupBox.Controls.Add(this.iconDisplayPictureBox);
            this.programSettingsGroupBox.Controls.Add(this.iconLabel1);
            this.programSettingsGroupBox.Location = new System.Drawing.Point(509, 13);
            this.programSettingsGroupBox.Name = "programSettingsGroupBox";
            this.programSettingsGroupBox.Size = new System.Drawing.Size(191, 535);
            this.programSettingsGroupBox.TabIndex = 2;
            this.programSettingsGroupBox.TabStop = false;
            this.programSettingsGroupBox.Text = "Program Settings";
            // 
            // changeIconButton
            // 
            this.changeIconButton.Location = new System.Drawing.Point(6, 20);
            this.changeIconButton.Name = "changeIconButton";
            this.changeIconButton.Size = new System.Drawing.Size(108, 23);
            this.changeIconButton.TabIndex = 2;
            this.changeIconButton.Text = "Change Icon";
            this.changeIconButton.UseVisualStyleBackColor = true;
            this.changeIconButton.Click += new System.EventHandler(this.changeIconButton_Click);
            // 
            // iconDisplayPictureBox
            // 
            this.iconDisplayPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconDisplayPictureBox.Location = new System.Drawing.Point(77, 46);
            this.iconDisplayPictureBox.Name = "iconDisplayPictureBox";
            this.iconDisplayPictureBox.Size = new System.Drawing.Size(108, 95);
            this.iconDisplayPictureBox.TabIndex = 1;
            this.iconDisplayPictureBox.TabStop = false;
            // 
            // iconLabel1
            // 
            this.iconLabel1.AutoSize = true;
            this.iconLabel1.Location = new System.Drawing.Point(6, 46);
            this.iconLabel1.Name = "iconLabel1";
            this.iconLabel1.Size = new System.Drawing.Size(68, 13);
            this.iconLabel1.TabIndex = 0;
            this.iconLabel1.Text = "Current Icon:";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 560);
            this.Controls.Add(this.programSettingsGroupBox);
            this.Controls.Add(this.streamPollSettingsGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OptionsForm_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.streamPollSettingsGroupBox.ResumeLayout(false);
            this.streamPollSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.programSettingsGroupBox.ResumeLayout(false);
            this.programSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconDisplayPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox optionsFormStreamerListBox;
        private System.Windows.Forms.Button streamerListBoxInteractButton;
        private System.Windows.Forms.Button streamerListPlayButton;
        private System.Windows.Forms.Label selectionInfoLabel;
        private System.Windows.Forms.Label createStreamerWarningLabel1;
        private System.Windows.Forms.Label createStreamerWarningLabel2;
        private System.Windows.Forms.Button streamerListDeleteButton;
        private System.Windows.Forms.Button streamerListChangeNameButton;
        private System.Windows.Forms.Button streamerListRefreshButton;
        private System.Windows.Forms.Button streamerListAddButton;
        private System.Windows.Forms.GroupBox streamPollSettingsGroupBox;
        private System.Windows.Forms.Label streamCheckURLLabel;
        private System.Windows.Forms.Label streamCheckLabel1;
        private System.Windows.Forms.Label streamCheckPollRateLabel;
        private System.Windows.Forms.Label streamCheckLabel2;
        private System.Windows.Forms.Button changePollURLButton;
        private System.Windows.Forms.Button changePollRateButton;
        private System.Windows.Forms.Label streamCheckLabel3;
        private System.Windows.Forms.Label balloonTipTimeoutlabel;
        private System.Windows.Forms.Label streamCheckLabel4;
        private System.Windows.Forms.Button changeBalloonTipTimeoutButton;
        private System.Windows.Forms.GroupBox programSettingsGroupBox;
        private System.Windows.Forms.PictureBox iconDisplayPictureBox;
        private System.Windows.Forms.Label iconLabel1;
        private System.Windows.Forms.Button changeIconButton;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}