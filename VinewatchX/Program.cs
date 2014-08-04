using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VinewatchX.Forms;

namespace VinewatchX
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool startMinimized = args.Any(a => Regex.IsMatch(a, @"--minimi[sz]ed", RegexOptions.IgnoreCase));

            Application.Run(new MainForm(startMinimized));
        }
    }
}
