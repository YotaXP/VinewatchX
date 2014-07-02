using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace VinewatchX
{
    public partial class StartWithWindowsPrompt : Form
    {
        public StartWithWindowsPrompt()
        {
            InitializeComponent();
        }

        private void enableStartUpButton_Click(object sender, EventArgs e)
        {
            RegisterInStartup(true);
            this.Close();
        }

        private void disableStartUpButton_Click(object sender, EventArgs e)
        {
            RegisterInStartup(false);
            this.Close();
        }

        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("ApplicationName", Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue("ApplicationName");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startWithWindowsPrompt_Load(object sender, EventArgs e)
        {

        }
    }
}
