namespace VinewatchX.Forms
{
    partial class xDebug
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
            this.xConsole = new System.Windows.Forms.ListBox();
            this.autoScrollCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // xConsole
            // 
            this.xConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xConsole.BackColor = System.Drawing.Color.Black;
            this.xConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xConsole.ForeColor = System.Drawing.Color.White;
            this.xConsole.Location = new System.Drawing.Point(12, 31);
            this.xConsole.Name = "xConsole";
            this.xConsole.ScrollAlwaysVisible = true;
            this.xConsole.Size = new System.Drawing.Size(572, 403);
            this.xConsole.TabIndex = 0;
            // 
            // autoScrollCheckbox
            // 
            this.autoScrollCheckbox.AutoSize = true;
            this.autoScrollCheckbox.Checked = true;
            this.autoScrollCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScrollCheckbox.ForeColor = System.Drawing.Color.White;
            this.autoScrollCheckbox.Location = new System.Drawing.Point(12, 8);
            this.autoScrollCheckbox.Name = "autoScrollCheckbox";
            this.autoScrollCheckbox.Size = new System.Drawing.Size(77, 17);
            this.autoScrollCheckbox.TabIndex = 1;
            this.autoScrollCheckbox.Text = "Auto-Scroll";
            this.autoScrollCheckbox.UseVisualStyleBackColor = true;
            // 
            // xDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(596, 450);
            this.Controls.Add(this.autoScrollCheckbox);
            this.Controls.Add(this.xConsole);
            this.Name = "xDebug";
            this.Text = "xConsole";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.xDebug_FormClosing);
            this.Load += new System.EventHandler(this.xDebug_Load);
            this.VisibleChanged += new System.EventHandler(this.xDebug_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox xConsole;
        private System.Windows.Forms.CheckBox autoScrollCheckbox;
    }
}