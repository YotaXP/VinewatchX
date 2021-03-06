﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Security.AccessControl;
using VinewatchX.Forms;
using System;

namespace VinewatchX
{
    /// <summary>
    /// Object to handle creation, export, import and reading of Vinewatch X configuration.
    /// </summary>
    class VineConf
    {
        private MainForm parentForm = null;

        public VineConf(MainForm referenceForm)
        {
            this.parentForm = referenceForm;
        }

        public void bypassPromptsImportConfig(string targetDir)
        {
            readConfig(targetDir);
        }

        public void exportConfig()
        {
            string path = establishPath();

            if (path == "")
            {
                if (MessageBox.Show("Save to " + MainForm.ExeDir + "?", "No path selected.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    writeConfig(MainForm.ExeDir);
                }
            }
            else
            {
                writeConfig(path);
            }
        }

        public void exportConfig2()
        {
            if (MessageBox.Show("Save to current directory? (" + MainForm.ExeDir + ")", "No path selected.", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                writeConfig(MainForm.ExeDir);
                MessageBox.Show("Done. Saved to " + MainForm.ExeDir + @"vinewatchXConfig.txt");
            }
            else
            {
                string path = establishPath();

                if (path != "")
                {
                    writeConfig(path);
                    MessageBox.Show("Done. Saved to " + path + @"vinewatchXConfig.txt");
                }
                else
                {
                    MessageBox.Show("Aborted. No file saved.");
                }
            }
        }

        public void exportConfig(string directory)
        {
            writeConfig(directory);
        }

        public void importConfig()
        {
            bool manualFolderSelect = true;

            if (File.Exists(MainForm.ExeDir + @"\" + "vinewatchXConfig.txt"))
            {
                if (MessageBox.Show("Configuration was detected in " + MainForm.ExeDir + ".\n\nLoad that?", "Config detected in Operating Directory!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    manualFolderSelect = false;
                    readConfig(MainForm.ExeDir);
                }
            }

            if (manualFolderSelect)
            {

                string path = establishPath();

                if (path != "")
                {
                    if (File.Exists(path + @"\" + "vinewatchXConfig.txt"))
                    {
                        readConfig(path);
                    }
                    else
                    {
                        MessageBox.Show("Sorry sport, no files named vinewatchXConfig.txt in this folder.", "No config detected in folder!");
                    }
                }
            }

        }

        private void writeConfig(string targetFolder)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(targetFolder + "\\vinewatchXConfig.txt"))
                {
                    // Streamers

                    file.WriteLine("@ Streamers");
                    xDebug.WriteLine("@ Streamers");
                    foreach (Streamer eachStreamer in StreamerUtils.StreamerList)
                    {
                        file.WriteLine("S " + eachStreamer.Name + "\t" + eachStreamer.SoundFilename + "\t" + eachStreamer.Aliases + "\t" + eachStreamer.AltService + "\t" + eachStreamer.AltChannel + "\t" + eachStreamer.MonitorAltChannel.ToString());
                        xDebug.WriteLine("S " + eachStreamer.Name + "\t" + eachStreamer.SoundFilename + "\t" + eachStreamer.Aliases + "\t" + eachStreamer.AltService + "\t" + eachStreamer.AltChannel + "\t" + eachStreamer.MonitorAltChannel.ToString());
                    }

                    // Icons

                    file.WriteLine("@ Icons");
                    xDebug.WriteLine("@ Icons");

                    file.WriteLine("I " + parentForm.getIconsAsString());
                    xDebug.WriteLine("I " + parentForm.getIconsAsString());

                    // Parameters

                    file.WriteLine("@ Params");
                    xDebug.WriteLine("@ Params");

                    file.WriteLine("P " + "tts=" + parentForm.opt.ttsRadioButton.Checked.ToString());
                    xDebug.WriteLine("P " + "tts=" + parentForm.opt.ttsRadioButton.Checked.ToString());

                    file.WriteLine("P " + "startminimized=" + parentForm.opt.startVinewatchMinimizedCheckbox.Checked.ToString());
                    xDebug.WriteLine("P " + "startminimized=" + parentForm.opt.startVinewatchMinimizedCheckbox.Checked.ToString());

                    file.WriteLine("P " + "runatstart=" + parentForm.opt.runVinewatchStartupCheckbox.Checked.ToString());
                    xDebug.WriteLine("P " + "runatstart=" + parentForm.opt.runVinewatchStartupCheckbox.Checked.ToString());

                    file.WriteLine("P " + "balloontimeout=" + parentForm.getBalloonTipTimeout());
                    xDebug.WriteLine("P " + "balloontimeout=" + parentForm.getBalloonTipTimeout());

                    file.WriteLine("P " + "pollrate=" + parentForm.getPollRate());
                    xDebug.WriteLine("P " + "pollrate=" + parentForm.getPollRate());

                }
            }
            catch
            {
                if (Rights.UAC.IsRunAsAdmin() || Rights.UAC.IsProcessElevated())
                    MessageBox.Show("The config file couldn't be written.");
                else
                    if (MessageBox.Show("Could not write the config file, do you want to try restarting VinewatchX with more privileges?", "Need Elevation?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        if (Rights.UAC.ExecuteElevated())
                            MainForm.mf.exitVinewatchXToolStripMenuItem_Click(new object(), new EventArgs());

            }
            xDebug.WriteLine("Done.\n" + targetFolder + @"\vinewatchXConfig.txt");
        }

        public bool writeDefaultConfig(bool configAlreadyLoaded)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(MainForm.ExeDir + "\\vinewatchXConfig.txt"))
                {
                    // Streamers

                    file.WriteLine("@ Streamers");
                    file.WriteLine("S Bobito" + "\t" + "InternalResource" + "\t" + "Bobo;Presidente" + "\t" + "" + "\t" + "" + "\t" + "False");
                    file.WriteLine("S Darren" + "\t" + "InternalResource" + "\t" + "Spud;Potato" + "\t" + "Twitch" + "\t" + "Iwantapotato" + "\t" + "False");
                    file.WriteLine("S Direboar" + "\t" + "InternalResource" + "\t" + "Dire;Boar;Durrbore;Durbur" + "\t" + "Twitch" + "\t" + "Direboar" + "\t" + "False");
                    file.WriteLine("S Fred" + "\t" + "InternalResource" + "\t" + "Froob" + "\t" + "Twitch" + "\t" + "Fredsauce" + "\t" + "False");
                    file.WriteLine("S Gingers" + "\t" + "InternalResource" + "\t" + "Fear" + "\t" + "Twitch" + "\t" + "Feargingers" + "\t" + "False");
                    file.WriteLine("S Guest" + "\t" + "InternalResource" + "\t" + "" + "\t" + "" + "\t" + "" + "\t" + "False");
                    file.WriteLine("S Hooty" + "\t" + "InternalResource" + "\t" + "Owl;Hoots;Hootet" + "\t" + "Twitch" + "\t" + "Hootey" + "\t" + "False");
                    file.WriteLine("S Imakuni" + "\t" + "InternalResource" + "\t" + "Ima;Pelicuni" + "\t" + "Twitch" + "\t" + "Pelikuni" + "\t" + "False");
                    file.WriteLine("S Jen" + "\t" + "InternalResource" + "\t" + "Jenna;Harley Quinn" + "\t" + "Twitch" + "\t" + "Mentaljen" + "\t" + "False");
                    file.WriteLine("S Joel" + "\t" + "InternalResource" + "\t" + "Jobel;Jorbel;Jogel;Skeletor;Joestar;Jojo" + "\t" + "Twitch" + "\t" + "Vargskelethor" + "\t" + "False");
                    file.WriteLine("S KY" + "\t" + "InternalResource" + "\t" + "Kwheezy" + "\t" + "Livebyfoma" + "\t" + "Twitch" + "\t" + "False");
                    file.WriteLine("S Limes" + "\t" + "InternalResource" + "\t" + "Limey;Seal;Aisha;Aishy" + "\t" + "Twitch" + "\t" + "Limealicious" + "\t" + "False");
                    file.WriteLine("S Rev" + "\t" + "InternalResource" + "\t" + "Collin;Muffin" + "\t" + "Twitch" + "\t" + "Revscarecrow" + "\t" + "False");
                    file.WriteLine("S Study" + "\t" + "InternalResource" + "\t" + "Study" + "\t" + "" + "\t" + "" + "\t" + "False");
                    file.WriteLine("S Vinny" + "\t" + "InternalResource" + "\t" + "Vine;Vince;Vingle;Pizzapasta" + "\t" + "" + "\t" + "" + "\t" + "False");

                    // Icons

                    file.WriteLine("@ Icons");
                    file.WriteLine("I InternalResource");

                    // Parameters

                    file.WriteLine("@ Params");
                    file.WriteLine("P " + "tts=false");
                    file.WriteLine("P " + "startminimized=False");
                    file.WriteLine("P " + "runatstart=" + (parentForm != null ? parentForm.opt.runVinewatchStartupCheckbox.Checked.ToString() : "false"));
                    file.WriteLine("P " + "balloontimeout=3");
                    file.WriteLine("P " + "pollrate=30");

                }

                xDebug.WriteLine("Done.\n" + MainForm.ExeDir + @"\vinewatchXConfig.txt");
                return true;
            }
            catch
            {
                if (Rights.UAC.IsRunAsAdmin() || Rights.UAC.IsProcessElevated())
                {
                    MessageBox.Show("The config file couldn't be written.");
                    return false;
                }
                else
                {
                    if (configAlreadyLoaded)
                    {
                        return false;
                    }
                    else
                    {
                        if (Rights.UAC.ExecuteElevated())
                        {
                            VinewatchX.Forms.MainForm.ForceClose = true;
                            Application.Exit();
                            return false;
                        }
                        else
                            return false;
                    }
                }
            }

            
        }

        private string establishPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.ShowDialog();

            xDebug.WriteLine("VineConf:\t Working Dir. set to - " + (fbd.SelectedPath == "" ? "Nothing! Defaulting to exe. dir." : fbd.SelectedPath));
            return fbd.SelectedPath;
        }

        private void readConfig(string targetFolder)
        {
            xDebug.WriteLine("Shit happens here.");
            if (File.Exists(targetFolder + @"\" + "vinewatchXConfig.txt"))
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(targetFolder + "\\vinewatchXConfig.txt"))
                {
                    while (file.EndOfStream != true)
                    {
                        applyConfigByLine(file.ReadLine());
                    }
                }
            }
            else
            {
                throw new FileNotFoundException();
            }

        }

        private void applyConfigByLine(string line)
        {
            string[] feedback = { "", "" };

            // Streamer
            if (line[0].Equals('S'))
            {
                string[] words = line.Split('\t'); feedback = words;
                xDebug.WriteLine("applyConfigByLine - " + words[0] + "_" + words[1] + "\n" + words[0].Substring(2) + " - " + words[1]);

                if(words.Length == 2)
                    StreamerUtils.AddStreamer(words[0].Substring(2), words[1]);
                else
                    StreamerUtils.AddStreamer(words);
            }

            // Icon
            if (line[0].Equals('I'))
            {
                parentForm.setIconsFromString(line.Substring(2));
            }

            // Parameter
            if (line[0].Equals('P'))
            {
                parentForm.setParamFromString(line.Substring(2));
            }
        }
    }
}
