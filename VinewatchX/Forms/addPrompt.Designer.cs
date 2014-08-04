namespace VinewatchX.Forms
{
    partial class AddPrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPrompt));
            this.addPromptNameTextbox = new System.Windows.Forms.TextBox();
            this.addPromptNameLabel = new System.Windows.Forms.Label();
            this.addPomptSoundLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.addPomptCurrentSoundLabel = new System.Windows.Forms.Label();
            this.addPromptConfirmButton = new System.Windows.Forms.Button();
            this.addPromptCancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addPromptNameTextbox
            // 
            this.addPromptNameTextbox.Location = new System.Drawing.Point(12, 29);
            this.addPromptNameTextbox.Name = "addPromptNameTextbox";
            this.addPromptNameTextbox.Size = new System.Drawing.Size(136, 20);
            this.addPromptNameTextbox.TabIndex = 0;
            // 
            // addPromptNameLabel
            // 
            this.addPromptNameLabel.AutoSize = true;
            this.addPromptNameLabel.Location = new System.Drawing.Point(12, 13);
            this.addPromptNameLabel.Name = "addPromptNameLabel";
            this.addPromptNameLabel.Size = new System.Drawing.Size(35, 13);
            this.addPromptNameLabel.TabIndex = 1;
            this.addPromptNameLabel.Text = "Name";
            // 
            // addPomptSoundLabel
            // 
            this.addPomptSoundLabel.AutoSize = true;
            this.addPomptSoundLabel.Location = new System.Drawing.Point(12, 56);
            this.addPomptSoundLabel.Name = "addPomptSoundLabel";
            this.addPomptSoundLabel.Size = new System.Drawing.Size(38, 13);
            this.addPomptSoundLabel.TabIndex = 2;
            this.addPomptSoundLabel.Text = "Sound";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Select Sound";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // addPomptCurrentSoundLabel
            // 
            this.addPomptCurrentSoundLabel.AutoSize = true;
            this.addPomptCurrentSoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPomptCurrentSoundLabel.Location = new System.Drawing.Point(12, 98);
            this.addPomptCurrentSoundLabel.MaximumSize = new System.Drawing.Size(73, 0);
            this.addPomptCurrentSoundLabel.Name = "addPomptCurrentSoundLabel";
            this.addPomptCurrentSoundLabel.Size = new System.Drawing.Size(73, 13);
            this.addPomptCurrentSoundLabel.TabIndex = 4;
            this.addPomptCurrentSoundLabel.Text = "No sound set.";
            // 
            // addPromptConfirmButton
            // 
            this.addPromptConfirmButton.Location = new System.Drawing.Point(12, 142);
            this.addPromptConfirmButton.Name = "addPromptConfirmButton";
            this.addPromptConfirmButton.Size = new System.Drawing.Size(136, 23);
            this.addPromptConfirmButton.TabIndex = 5;
            this.addPromptConfirmButton.Text = "Add";
            this.addPromptConfirmButton.UseVisualStyleBackColor = true;
            this.addPromptConfirmButton.Click += new System.EventHandler(this.addPromptConfirmButton_Click);
            // 
            // addPromptCancelButton
            // 
            this.addPromptCancelButton.Location = new System.Drawing.Point(12, 171);
            this.addPromptCancelButton.Name = "addPromptCancelButton";
            this.addPromptCancelButton.Size = new System.Drawing.Size(136, 23);
            this.addPromptCancelButton.TabIndex = 6;
            this.addPromptCancelButton.Text = "Cancel";
            this.addPromptCancelButton.UseVisualStyleBackColor = true;
            this.addPromptCancelButton.Click += new System.EventHandler(this.addPromptCancelButton_Click);
            // 
            // addPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(161, 206);
            this.Controls.Add(this.addPromptCancelButton);
            this.Controls.Add(this.addPromptConfirmButton);
            this.Controls.Add(this.addPomptCurrentSoundLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.addPomptSoundLabel);
            this.Controls.Add(this.addPromptNameLabel);
            this.Controls.Add(this.addPromptNameTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addPrompt";
            this.Text = "Add Streamer";
            this.Load += new System.EventHandler(this.addPrompt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox addPromptNameTextbox;
        private System.Windows.Forms.Label addPromptNameLabel;
        private System.Windows.Forms.Label addPomptSoundLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label addPomptCurrentSoundLabel;
        private System.Windows.Forms.Button addPromptConfirmButton;
        private System.Windows.Forms.Button addPromptCancelButton;
    }
}