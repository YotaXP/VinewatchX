namespace VinewatchX.Forms
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.altChannelServiceCombobox = new System.Windows.Forms.ComboBox();
            this.saveStreamerParametersButton = new System.Windows.Forms.Button();
            this.altChannelNameTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monitorAltChannelCheckbox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.streamerAliasesTextbox = new System.Windows.Forms.TextBox();
            this.resetDefaultSoundButton = new System.Windows.Forms.Button();
            this.streamerListAddButton = new System.Windows.Forms.Button();
            this.streamerListChangeNameButton = new System.Windows.Forms.Button();
            this.createStreamerWarningLabel2 = new System.Windows.Forms.Label();
            this.createStreamerWarningLabel1 = new System.Windows.Forms.Label();
            this.selectionInfoLabel = new System.Windows.Forms.Label();
            this.streamerListDeleteButton = new System.Windows.Forms.Button();
            this.streamerListPlayButton = new System.Windows.Forms.Button();
            this.streamerListBoxInteractButton = new System.Windows.Forms.Button();
            this.optionsFormStreamerListBox = new System.Windows.Forms.ListBox();
            this.streamPollSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.debugButton = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.changeBalloonTipTimeoutButton = new System.Windows.Forms.Button();
            this.balloonTipTimeoutlabel = new System.Windows.Forms.Label();
            this.streamCheckLabel4 = new System.Windows.Forms.Label();
            this.changePollRateButton = new System.Windows.Forms.Button();
            this.streamCheckPollRateLabel = new System.Windows.Forms.Label();
            this.streamCheckLabel2 = new System.Windows.Forms.Label();
            this.programSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.startVinewatchMinimizedCheckbox = new System.Windows.Forms.CheckBox();
            this.samplePlayingRadioButton = new System.Windows.Forms.RadioButton();
            this.ttsRadioButton = new System.Windows.Forms.RadioButton();
            this.runVinewatchStartupCheckbox = new System.Windows.Forms.CheckBox();
            this.changeIconButton = new System.Windows.Forms.Button();
            this.iconDisplayPictureBox = new System.Windows.Forms.PictureBox();
            this.iconLabel1 = new System.Windows.Forms.Label();
            this.importSettingsButton = new System.Windows.Forms.Button();
            this.exportSettingsButton = new System.Windows.Forms.Button();
            this.supressionRadioButton = new System.Windows.Forms.CheckBox();
            this.notifyTestButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resetToDefaultConfigButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.streamPollSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.programSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconDisplayPictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.resetDefaultSoundButton);
            this.groupBox1.Controls.Add(this.streamerListAddButton);
            this.groupBox1.Controls.Add(this.streamerListChangeNameButton);
            this.groupBox1.Controls.Add(this.createStreamerWarningLabel2);
            this.groupBox1.Controls.Add(this.createStreamerWarningLabel1);
            this.groupBox1.Controls.Add(this.selectionInfoLabel);
            this.groupBox1.Controls.Add(this.streamerListDeleteButton);
            this.groupBox1.Controls.Add(this.streamerListPlayButton);
            this.groupBox1.Controls.Add(this.streamerListBoxInteractButton);
            this.groupBox1.Controls.Add(this.optionsFormStreamerListBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Streamer Sounds and Parameters";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.altChannelServiceCombobox);
            this.groupBox3.Controls.Add(this.saveStreamerParametersButton);
            this.groupBox3.Controls.Add(this.altChannelNameTextbox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.monitorAltChannelCheckbox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.streamerAliasesTextbox);
            this.groupBox3.Location = new System.Drawing.Point(117, 131);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 118);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parameters";
            // 
            // altChannelServiceCombobox
            // 
            this.altChannelServiceCombobox.FormattingEnabled = true;
            this.altChannelServiceCombobox.Items.AddRange(new object[] {
            "Twitch",
            "Hitbox"});
            this.altChannelServiceCombobox.Location = new System.Drawing.Point(74, 60);
            this.altChannelServiceCombobox.Name = "altChannelServiceCombobox";
            this.altChannelServiceCombobox.Size = new System.Drawing.Size(132, 21);
            this.altChannelServiceCombobox.TabIndex = 16;
            // 
            // saveStreamerParametersButton
            // 
            this.saveStreamerParametersButton.Location = new System.Drawing.Point(238, 87);
            this.saveStreamerParametersButton.Name = "saveStreamerParametersButton";
            this.saveStreamerParametersButton.Size = new System.Drawing.Size(113, 22);
            this.saveStreamerParametersButton.TabIndex = 10;
            this.saveStreamerParametersButton.Text = "Save parameters";
            this.saveStreamerParametersButton.UseVisualStyleBackColor = true;
            this.saveStreamerParametersButton.Click += new System.EventHandler(this.saveStreamerParametersButton_Click);
            // 
            // altChannelNameTextbox
            // 
            this.altChannelNameTextbox.Location = new System.Drawing.Point(74, 87);
            this.altChannelNameTextbox.Name = "altChannelNameTextbox";
            this.altChannelNameTextbox.Size = new System.Drawing.Size(132, 20);
            this.altChannelNameTextbox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Alt channel ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Alt service";
            // 
            // monitorAltChannelCheckbox
            // 
            this.monitorAltChannelCheckbox.AutoSize = true;
            this.monitorAltChannelCheckbox.Location = new System.Drawing.Point(239, 68);
            this.monitorAltChannelCheckbox.Name = "monitorAltChannelCheckbox";
            this.monitorAltChannelCheckbox.Size = new System.Drawing.Size(117, 17);
            this.monitorAltChannelCheckbox.TabIndex = 11;
            this.monitorAltChannelCheckbox.Text = "Monitor Alt channel";
            this.monitorAltChannelCheckbox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Streamer aliases (separated by character ; )";
            // 
            // streamerAliasesTextbox
            // 
            this.streamerAliasesTextbox.Location = new System.Drawing.Point(9, 34);
            this.streamerAliasesTextbox.Name = "streamerAliasesTextbox";
            this.streamerAliasesTextbox.Size = new System.Drawing.Size(342, 20);
            this.streamerAliasesTextbox.TabIndex = 0;
            // 
            // resetDefaultSoundButton
            // 
            this.resetDefaultSoundButton.Location = new System.Drawing.Point(362, 65);
            this.resetDefaultSoundButton.Name = "resetDefaultSoundButton";
            this.resetDefaultSoundButton.Size = new System.Drawing.Size(115, 23);
            this.resetDefaultSoundButton.TabIndex = 8;
            this.resetDefaultSoundButton.Text = "Reset Default Sound";
            this.resetDefaultSoundButton.UseVisualStyleBackColor = true;
            this.resetDefaultSoundButton.Click += new System.EventHandler(this.resetDefaultSoundButton_Click);
            // 
            // streamerListAddButton
            // 
            this.streamerListAddButton.Location = new System.Drawing.Point(117, 36);
            this.streamerListAddButton.Name = "streamerListAddButton";
            this.streamerListAddButton.Size = new System.Drawing.Size(115, 23);
            this.streamerListAddButton.TabIndex = 7;
            this.streamerListAddButton.Text = "Add Streamer";
            this.streamerListAddButton.UseVisualStyleBackColor = true;
            this.streamerListAddButton.Click += new System.EventHandler(this.streamerListAddButton_Click);
            // 
            // streamerListChangeNameButton
            // 
            this.streamerListChangeNameButton.Location = new System.Drawing.Point(240, 36);
            this.streamerListChangeNameButton.Name = "streamerListChangeNameButton";
            this.streamerListChangeNameButton.Size = new System.Drawing.Size(115, 23);
            this.streamerListChangeNameButton.TabIndex = 5;
            this.streamerListChangeNameButton.Text = "Edit Selected";
            this.streamerListChangeNameButton.UseVisualStyleBackColor = true;
            this.streamerListChangeNameButton.Click += new System.EventHandler(this.streamerListChangeNameButton_Click);
            // 
            // createStreamerWarningLabel2
            // 
            this.createStreamerWarningLabel2.AutoSize = true;
            this.createStreamerWarningLabel2.Location = new System.Drawing.Point(113, 109);
            this.createStreamerWarningLabel2.Name = "createStreamerWarningLabel2";
            this.createStreamerWarningLabel2.Size = new System.Drawing.Size(300, 13);
            this.createStreamerWarningLabel2.TabIndex = 4;
            this.createStreamerWarningLabel2.Text = "  e.g. If the stream title contains \'Vinny\', Vinny\'s sound will play.";
            // 
            // createStreamerWarningLabel1
            // 
            this.createStreamerWarningLabel1.AutoSize = true;
            this.createStreamerWarningLabel1.Location = new System.Drawing.Point(113, 96);
            this.createStreamerWarningLabel1.Name = "createStreamerWarningLabel1";
            this.createStreamerWarningLabel1.Size = new System.Drawing.Size(364, 13);
            this.createStreamerWarningLabel1.TabIndex = 4;
            this.createStreamerWarningLabel1.Text = "The streamer\'s name as it is entered here is the search string for their sound.";
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
            this.streamerListDeleteButton.Location = new System.Drawing.Point(362, 36);
            this.streamerListDeleteButton.Name = "streamerListDeleteButton";
            this.streamerListDeleteButton.Size = new System.Drawing.Size(115, 23);
            this.streamerListDeleteButton.TabIndex = 2;
            this.streamerListDeleteButton.Text = "Delete Selected";
            this.streamerListDeleteButton.UseVisualStyleBackColor = true;
            this.streamerListDeleteButton.Click += new System.EventHandler(this.streamerListDeleteButton_Click);
            // 
            // streamerListPlayButton
            // 
            this.streamerListPlayButton.Location = new System.Drawing.Point(240, 65);
            this.streamerListPlayButton.Name = "streamerListPlayButton";
            this.streamerListPlayButton.Size = new System.Drawing.Size(115, 23);
            this.streamerListPlayButton.TabIndex = 2;
            this.streamerListPlayButton.Text = "Play Sound";
            this.streamerListPlayButton.UseVisualStyleBackColor = true;
            this.streamerListPlayButton.Click += new System.EventHandler(this.streamerListPlayButton_Click);
            // 
            // streamerListBoxInteractButton
            // 
            this.streamerListBoxInteractButton.Location = new System.Drawing.Point(117, 65);
            this.streamerListBoxInteractButton.Name = "streamerListBoxInteractButton";
            this.streamerListBoxInteractButton.Size = new System.Drawing.Size(115, 23);
            this.streamerListBoxInteractButton.TabIndex = 1;
            this.streamerListBoxInteractButton.Text = "Change Sound";
            this.streamerListBoxInteractButton.UseVisualStyleBackColor = true;
            this.streamerListBoxInteractButton.Click += new System.EventHandler(this.streamerListBoxInteractButton_Click);
            // 
            // optionsFormStreamerListBox
            // 
            this.optionsFormStreamerListBox.FormattingEnabled = true;
            this.optionsFormStreamerListBox.Location = new System.Drawing.Point(7, 24);
            this.optionsFormStreamerListBox.Name = "optionsFormStreamerListBox";
            this.optionsFormStreamerListBox.Size = new System.Drawing.Size(100, 225);
            this.optionsFormStreamerListBox.TabIndex = 0;
            this.optionsFormStreamerListBox.SelectedIndexChanged += new System.EventHandler(this.optionsFormStreamerListBox_SelectedIndexChanged);
            // 
            // streamPollSettingsGroupBox
            // 
            this.streamPollSettingsGroupBox.Controls.Add(this.panel1);
            this.streamPollSettingsGroupBox.Controls.Add(this.debugButton);
            this.streamPollSettingsGroupBox.Controls.Add(this.pictureBox1);
            this.streamPollSettingsGroupBox.Controls.Add(this.changeBalloonTipTimeoutButton);
            this.streamPollSettingsGroupBox.Controls.Add(this.balloonTipTimeoutlabel);
            this.streamPollSettingsGroupBox.Controls.Add(this.streamCheckLabel4);
            this.streamPollSettingsGroupBox.Controls.Add(this.changePollRateButton);
            this.streamPollSettingsGroupBox.Controls.Add(this.streamCheckPollRateLabel);
            this.streamPollSettingsGroupBox.Controls.Add(this.streamCheckLabel2);
            this.streamPollSettingsGroupBox.Location = new System.Drawing.Point(13, 287);
            this.streamPollSettingsGroupBox.Name = "streamPollSettingsGroupBox";
            this.streamPollSettingsGroupBox.Size = new System.Drawing.Size(489, 145);
            this.streamPollSettingsGroupBox.TabIndex = 1;
            this.streamPollSettingsGroupBox.TabStop = false;
            this.streamPollSettingsGroupBox.Text = "Stream Poll Settings";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(281, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(31, 23);
            this.panel1.TabIndex = 14;
            // 
            // debugButton
            // 
            this.debugButton.Location = new System.Drawing.Point(318, 109);
            this.debugButton.Name = "debugButton";
            this.debugButton.Size = new System.Drawing.Size(31, 23);
            this.debugButton.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VinewatchX.Properties.Resources.fantasy;
            this.pictureBox1.Location = new System.Drawing.Point(355, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // changeBalloonTipTimeoutButton
            // 
            this.changeBalloonTipTimeoutButton.Location = new System.Drawing.Point(32, 103);
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
            this.balloonTipTimeoutlabel.Location = new System.Drawing.Point(196, 86);
            this.balloonTipTimeoutlabel.Name = "balloonTipTimeoutlabel";
            this.balloonTipTimeoutlabel.Size = new System.Drawing.Size(59, 13);
            this.balloonTipTimeoutlabel.TabIndex = 8;
            this.balloonTipTimeoutlabel.Text = "setOnLoad";
            // 
            // streamCheckLabel4
            // 
            this.streamCheckLabel4.AutoSize = true;
            this.streamCheckLabel4.Location = new System.Drawing.Point(9, 86);
            this.streamCheckLabel4.Name = "streamCheckLabel4";
            this.streamCheckLabel4.Size = new System.Drawing.Size(172, 13);
            this.streamCheckLabel4.TabIndex = 7;
            this.streamCheckLabel4.Text = "The current Balloon Tip Timeout is:";
            // 
            // changePollRateButton
            // 
            this.changePollRateButton.Location = new System.Drawing.Point(32, 47);
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
            this.streamCheckPollRateLabel.Location = new System.Drawing.Point(196, 29);
            this.streamCheckPollRateLabel.Name = "streamCheckPollRateLabel";
            this.streamCheckPollRateLabel.Size = new System.Drawing.Size(59, 13);
            this.streamCheckPollRateLabel.TabIndex = 4;
            this.streamCheckPollRateLabel.Text = "setOnLoad";
            // 
            // streamCheckLabel2
            // 
            this.streamCheckLabel2.AutoSize = true;
            this.streamCheckLabel2.Location = new System.Drawing.Point(6, 29);
            this.streamCheckLabel2.Name = "streamCheckLabel2";
            this.streamCheckLabel2.Size = new System.Drawing.Size(129, 13);
            this.streamCheckLabel2.TabIndex = 3;
            this.streamCheckLabel2.Text = "The current polling rate is:";
            // 
            // programSettingsGroupBox
            // 
            this.programSettingsGroupBox.Controls.Add(this.startVinewatchMinimizedCheckbox);
            this.programSettingsGroupBox.Controls.Add(this.samplePlayingRadioButton);
            this.programSettingsGroupBox.Controls.Add(this.ttsRadioButton);
            this.programSettingsGroupBox.Controls.Add(this.runVinewatchStartupCheckbox);
            this.programSettingsGroupBox.Controls.Add(this.changeIconButton);
            this.programSettingsGroupBox.Controls.Add(this.iconDisplayPictureBox);
            this.programSettingsGroupBox.Controls.Add(this.iconLabel1);
            this.programSettingsGroupBox.Controls.Add(this.importSettingsButton);
            this.programSettingsGroupBox.Controls.Add(this.exportSettingsButton);
            this.programSettingsGroupBox.Location = new System.Drawing.Point(509, 11);
            this.programSettingsGroupBox.Name = "programSettingsGroupBox";
            this.programSettingsGroupBox.Size = new System.Drawing.Size(191, 266);
            this.programSettingsGroupBox.TabIndex = 2;
            this.programSettingsGroupBox.TabStop = false;
            this.programSettingsGroupBox.Text = "Program Settings";
            // 
            // startVinewatchMinimizedCheckbox
            // 
            this.startVinewatchMinimizedCheckbox.AutoSize = true;
            this.startVinewatchMinimizedCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startVinewatchMinimizedCheckbox.Location = new System.Drawing.Point(7, 244);
            this.startVinewatchMinimizedCheckbox.Name = "startVinewatchMinimizedCheckbox";
            this.startVinewatchMinimizedCheckbox.Size = new System.Drawing.Size(156, 17);
            this.startVinewatchMinimizedCheckbox.TabIndex = 21;
            this.startVinewatchMinimizedCheckbox.Text = "Start VinewatchX minimized";
            this.startVinewatchMinimizedCheckbox.UseVisualStyleBackColor = true;
            // 
            // samplePlayingRadioButton
            // 
            this.samplePlayingRadioButton.AutoSize = true;
            this.samplePlayingRadioButton.Checked = true;
            this.samplePlayingRadioButton.Location = new System.Drawing.Point(7, 182);
            this.samplePlayingRadioButton.Name = "samplePlayingRadioButton";
            this.samplePlayingRadioButton.Size = new System.Drawing.Size(127, 17);
            this.samplePlayingRadioButton.TabIndex = 20;
            this.samplePlayingRadioButton.TabStop = true;
            this.samplePlayingRadioButton.Text = "Sample Playing Mode";
            this.samplePlayingRadioButton.UseVisualStyleBackColor = true;
            // 
            // ttsRadioButton
            // 
            this.ttsRadioButton.AutoSize = true;
            this.ttsRadioButton.Location = new System.Drawing.Point(7, 201);
            this.ttsRadioButton.Name = "ttsRadioButton";
            this.ttsRadioButton.Size = new System.Drawing.Size(132, 17);
            this.ttsRadioButton.TabIndex = 19;
            this.ttsRadioButton.Text = "Text-To-Speech Mode";
            this.ttsRadioButton.UseVisualStyleBackColor = true;
            // 
            // runVinewatchStartupCheckbox
            // 
            this.runVinewatchStartupCheckbox.AutoSize = true;
            this.runVinewatchStartupCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runVinewatchStartupCheckbox.Location = new System.Drawing.Point(7, 223);
            this.runVinewatchStartupCheckbox.Name = "runVinewatchStartupCheckbox";
            this.runVinewatchStartupCheckbox.Size = new System.Drawing.Size(155, 17);
            this.runVinewatchStartupCheckbox.TabIndex = 18;
            this.runVinewatchStartupCheckbox.Text = "Run VinewatchX at Startup";
            this.runVinewatchStartupCheckbox.UseVisualStyleBackColor = true;
            this.runVinewatchStartupCheckbox.Click += new System.EventHandler(this.runVinewatchStartupCheckbox_Click);
            // 
            // changeIconButton
            // 
            this.changeIconButton.Location = new System.Drawing.Point(6, 18);
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
            this.iconDisplayPictureBox.Location = new System.Drawing.Point(77, 49);
            this.iconDisplayPictureBox.Name = "iconDisplayPictureBox";
            this.iconDisplayPictureBox.Size = new System.Drawing.Size(108, 95);
            this.iconDisplayPictureBox.TabIndex = 1;
            this.iconDisplayPictureBox.TabStop = false;
            // 
            // iconLabel1
            // 
            this.iconLabel1.AutoSize = true;
            this.iconLabel1.Location = new System.Drawing.Point(6, 49);
            this.iconLabel1.Name = "iconLabel1";
            this.iconLabel1.Size = new System.Drawing.Size(68, 13);
            this.iconLabel1.TabIndex = 0;
            this.iconLabel1.Text = "Current Icon:";
            // 
            // importSettingsButton
            // 
            this.importSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importSettingsButton.Location = new System.Drawing.Point(6, 151);
            this.importSettingsButton.Name = "importSettingsButton";
            this.importSettingsButton.Size = new System.Drawing.Size(86, 23);
            this.importSettingsButton.TabIndex = 4;
            this.importSettingsButton.Text = "Import Settings";
            this.importSettingsButton.UseVisualStyleBackColor = true;
            this.importSettingsButton.Click += new System.EventHandler(this.importSettingsButton_Click);
            // 
            // exportSettingsButton
            // 
            this.exportSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportSettingsButton.Location = new System.Drawing.Point(92, 151);
            this.exportSettingsButton.Name = "exportSettingsButton";
            this.exportSettingsButton.Size = new System.Drawing.Size(94, 23);
            this.exportSettingsButton.TabIndex = 3;
            this.exportSettingsButton.Text = "Export Settings";
            this.exportSettingsButton.UseVisualStyleBackColor = true;
            this.exportSettingsButton.Click += new System.EventHandler(this.exportSettingsButton_Click);
            // 
            // supressionRadioButton
            // 
            this.supressionRadioButton.AutoSize = true;
            this.supressionRadioButton.Checked = true;
            this.supressionRadioButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.supressionRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supressionRadioButton.Location = new System.Drawing.Point(11, 48);
            this.supressionRadioButton.Name = "supressionRadioButton";
            this.supressionRadioButton.Size = new System.Drawing.Size(151, 17);
            this.supressionRadioButton.TabIndex = 15;
            this.supressionRadioButton.Text = "Supress Connection Errors";
            this.supressionRadioButton.UseVisualStyleBackColor = true;
            // 
            // notifyTestButton
            // 
            this.notifyTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifyTestButton.Location = new System.Drawing.Point(9, 19);
            this.notifyTestButton.Name = "notifyTestButton";
            this.notifyTestButton.Size = new System.Drawing.Size(143, 23);
            this.notifyTestButton.TabIndex = 5;
            this.notifyTestButton.Text = "Test Notifications";
            this.notifyTestButton.UseVisualStyleBackColor = true;
            this.notifyTestButton.Click += new System.EventHandler(this.notifyTestButton_Click);
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(612, 409);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 23);
            this.okButton.TabIndex = 18;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.resetToDefaultConfigButton);
            this.groupBox2.Controls.Add(this.notifyTestButton);
            this.groupBox2.Controls.Add(this.supressionRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(509, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 107);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Debug Tools";
            // 
            // resetToDefaultConfigButton
            // 
            this.resetToDefaultConfigButton.Location = new System.Drawing.Point(11, 70);
            this.resetToDefaultConfigButton.Name = "resetToDefaultConfigButton";
            this.resetToDefaultConfigButton.Size = new System.Drawing.Size(141, 23);
            this.resetToDefaultConfigButton.TabIndex = 9;
            this.resetToDefaultConfigButton.Text = "Reset to Default Config";
            this.resetToDefaultConfigButton.UseVisualStyleBackColor = true;
            this.resetToDefaultConfigButton.Click += new System.EventHandler(this.resetToDefaultConfigButton_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 443);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.programSettingsGroupBox);
            this.Controls.Add(this.streamPollSettingsGroupBox);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OptionsForm_FormClosed);
            this.Load += new System.EventHandler(this.OptionsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.streamPollSettingsGroupBox.ResumeLayout(false);
            this.streamPollSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.programSettingsGroupBox.ResumeLayout(false);
            this.programSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconDisplayPictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button streamerListAddButton;
        private System.Windows.Forms.GroupBox streamPollSettingsGroupBox;
        private System.Windows.Forms.Label streamCheckPollRateLabel;
        private System.Windows.Forms.Label streamCheckLabel2;
        private System.Windows.Forms.Button changePollRateButton;
        private System.Windows.Forms.Label balloonTipTimeoutlabel;
        private System.Windows.Forms.Label streamCheckLabel4;
        private System.Windows.Forms.Button changeBalloonTipTimeoutButton;
        private System.Windows.Forms.GroupBox programSettingsGroupBox;
        private System.Windows.Forms.PictureBox iconDisplayPictureBox;
        private System.Windows.Forms.Label iconLabel1;
        private System.Windows.Forms.Button changeIconButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button importSettingsButton;
        private System.Windows.Forms.Button exportSettingsButton;
        private System.Windows.Forms.Button notifyTestButton;
        internal System.Windows.Forms.CheckBox supressionRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel debugButton;
        private System.Windows.Forms.Button okButton;
        internal System.Windows.Forms.CheckBox runVinewatchStartupCheckbox;
        private System.Windows.Forms.RadioButton samplePlayingRadioButton;
        internal System.Windows.Forms.RadioButton ttsRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.CheckBox startVinewatchMinimizedCheckbox;
        private System.Windows.Forms.Button resetDefaultSoundButton;
        private System.Windows.Forms.Button resetToDefaultConfigButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox altChannelNameTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox monitorAltChannelCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox streamerAliasesTextbox;
        private System.Windows.Forms.Button saveStreamerParametersButton;
        private System.Windows.Forms.ComboBox altChannelServiceCombobox;

    }
}