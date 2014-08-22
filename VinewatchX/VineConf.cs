using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VinewatchX.Forms;

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
                if (MessageBox.Show("Save to " + Directory.GetCurrentDirectory() + "?", "No path selected.", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    writeConfig(Directory.GetCurrentDirectory());
                }
            }
            else
            {
                writeConfig(path);
            }
        }

        public void exportConfig2()
        {
            if (MessageBox.Show("Save to current directory? (" + Directory.GetCurrentDirectory() + ")", "No path selected.", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                writeConfig(Directory.GetCurrentDirectory());
                MessageBox.Show("Done. Saved to " + Directory.GetCurrentDirectory() + @"vinewatchXConfig.txt");
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

            if (File.Exists(Directory.GetCurrentDirectory() + "\\vinewatchXConfig.txt"))
            {
                if (MessageBox.Show("Configuration was detected in " + Directory.GetCurrentDirectory() + ".\n\nLoad that?", "Config detected in Operating Directory!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    manualFolderSelect = false;
                    readConfig(Directory.GetCurrentDirectory());
                }
            }

            if (manualFolderSelect)
            {

                string path = establishPath();

                if (path != "")
                {
                    if (File.Exists(path + "\\vinewatchXConfig.txt"))
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
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(targetFolder + "\\vinewatchXConfig.txt"))
            {
                // Streamers

                file.WriteLine("@ Streamers");
                Debug.WriteLine("@ Streamers");
                foreach (Streamer eachStreamer in StreamerUtils.StreamerList)
                {
                    file.WriteLine("S " + eachStreamer.Name + "\t" + eachStreamer.SoundFilename + "\t" + eachStreamer.Aliases  + "\t" + eachStreamer.AltService + "\t" + eachStreamer.AltChannel  + "\t" + eachStreamer.MonitorAltChannel.ToString());
                    Debug.WriteLine("S " + eachStreamer.Name + "\t" + eachStreamer.SoundFilename + "\t" + eachStreamer.Aliases + "\t" + eachStreamer.AltService + "\t" + eachStreamer.AltChannel + "\t" + eachStreamer.MonitorAltChannel.ToString());
                }

                // Icons

                file.WriteLine("@ Icons");
                Debug.WriteLine("@ Icons");

                file.WriteLine("I " + parentForm.getIconsAsString());
                Debug.WriteLine("I " + parentForm.getIconsAsString());

                // Parameters

                file.WriteLine("@ Params");
                Debug.WriteLine("@ Params");

                file.WriteLine("P " + "tts=" + parentForm.opt.ttsRadioButton.Checked.ToString());
                Debug.WriteLine("P " + "tts=" + parentForm.opt.ttsRadioButton.Checked.ToString());

                file.WriteLine("P " + "startminimized=" + parentForm.opt.startVinewatchMinimizedCheckbox.Checked.ToString());
                Debug.WriteLine("P " + "startminimized=" + parentForm.opt.startVinewatchMinimizedCheckbox.Checked.ToString());

                file.WriteLine("P " + "runatstart=" + parentForm.opt.runVinewatchStartupCheckbox.Checked.ToString());
                Debug.WriteLine("P " + "runatstart=" + parentForm.opt.runVinewatchStartupCheckbox.Checked.ToString());

                file.WriteLine("P " + "balloontimeout=" + parentForm.getBalloonTipTimeout());
                Debug.WriteLine("P " + "balloontimeout=" + parentForm.getBalloonTipTimeout());

                file.WriteLine("P " + "pollrate=" + parentForm.getPollRate());
                Debug.WriteLine("P " + "pollrate=" + parentForm.getPollRate());

            }

            Debug.WriteLine("Done.\n" + targetFolder + @"\vinewatchXConfig.txt");
        }

        public void writeDefaultConfig()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Directory.GetCurrentDirectory() + "\\vinewatchXConfig.txt"))
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
                file.WriteLine("P " + "runatstart=" + parentForm.opt.runVinewatchStartupCheckbox.Checked.ToString());
                file.WriteLine("P " + "balloontimeout=3");
                file.WriteLine("P " + "pollrate=30");

            }

            Debug.WriteLine("Done.\n" + Directory.GetCurrentDirectory() + @"\vinewatchXConfig.txt");
        }

        private string establishPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            fbd.ShowDialog();

            Debug.WriteLine("VineConf:\t Working Dir. set to - " + (fbd.SelectedPath == "" ? "Nothing! Defaulting to exe. dir." : fbd.SelectedPath));
            return fbd.SelectedPath;
        }

        private void readConfig(string targetFolder)
        {
            Debug.WriteLine("Shit happens here.");
            if (File.Exists(targetFolder + "\\vinewatchXConfig.txt"))
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
                Debug.WriteLine("applyConfigByLine - " + words[0] + "_" + words[1] + "\n" + words[0].Substring(2) + " - " + words[1]);

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
