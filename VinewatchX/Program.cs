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

            bool startMinimized = args.Any(a => Regex.IsMatch(a, @"--minimi[sz]ed", RegexOptions.IgnoreCase));

            Application.Run(new MainForm(startMinimized));
        }
    }
}
