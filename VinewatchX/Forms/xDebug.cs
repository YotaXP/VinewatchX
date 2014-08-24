using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VinewatchX.Forms
{
    public partial class xDebug : Form
    {
        public static xDebug x = new xDebug();
        public volatile static Queue<string> linesToAdd = new Queue<string>();
        public Timer RefreshTimer = new Timer();

        public xDebug()
        {
            InitializeComponent();
            x = this;
            RefreshTimer.Interval = 250;
            RefreshTimer.Tick += new EventHandler(Refresh_Tick);
        }

        public static void WriteLine(string message)
        {
            Debug.WriteLine(message);
            linesToAdd.Enqueue(message);
        }

        private void xDebug_Load(object sender, EventArgs e)
        {

        }
        
        public void Refresh_Tick(object sender, EventArgs e)
        {
            while (linesToAdd.Count > 0)
            {
                string line = linesToAdd.Dequeue();
                xConsole.Items.Add(line);
            }

            while (linesToAdd.Count > 1000)
            {
                xConsole.Items.RemoveAt(0);
            }

            if (autoScrollCheckbox.Checked)
            {
                int visibleItems = xConsole.ClientSize.Height / xConsole.ItemHeight;
                xConsole.TopIndex = Math.Max(xConsole.Items.Count - visibleItems + 1, 0);
            }
        }

        private void xDebug_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                RefreshTimer.Start();
            else
                RefreshTimer.Stop();
        }

        private void xDebug_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason != CloseReason.FormOwnerClosing && !MainForm.ForceClose)
            {
                this.Hide();
                e.Cancel = true;
                return;
            }

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            if (!MainForm.ForceClose)
                e.Cancel = true;

        }

    }
}
