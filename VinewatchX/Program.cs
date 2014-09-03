using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VinewatchX.Forms;

namespace VinewatchX
{
    class Program
    {
        public static string Directory { get; private set; }

        [STAThread]
        static void Main(string[] args)
        {
            Directory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if(!Singularity.Scan())
            {
                MainForm mf = new MainForm(args);

                if (!MainForm.ForceClose)
                Application.Run(mf);
            }

        }
    }
}
