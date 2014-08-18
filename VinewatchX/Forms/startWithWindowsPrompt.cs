using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace VinewatchX.Forms
{
    public partial class StartWithWindowsPrompt : Form
    {
        MainForm parentForm;

        public StartWithWindowsPrompt(MainForm _parentForm)
        {
            InitializeComponent();
            parentForm = _parentForm;
        }

        private void enableStartUpButton_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterInStartup(true);
            }
            catch { }

            parentForm.opt.runVinewatchStartupCheckbox.Checked = true;
            this.Close();
        }

        private void disableStartUpButton_Click(object sender, EventArgs e)
        {
            try
            {
                RegisterInStartup(false);
            }
            catch { }

            parentForm.opt.runVinewatchStartupCheckbox.Checked = false;
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
