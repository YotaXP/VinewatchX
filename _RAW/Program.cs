/*
* ----------------------------------------------------------------------------
* "THE BEER-WARE LICENSE" (Revision of H. Bristow):
* 
* As long as you retain this notice you can do whatever you want with this 
* stuff. If ever you should use this program, you are held under the one
* simple rule of this license, and by using the program you agree to adhere
* to said rule. 
* 
* Imposed rule - For each single user that uses the program, one beer is to
* be bought as a gift to the programmer, should ever their paths (User and
* programmer) cross.
* 
* Failure to adhere to the rule will lead to a user being shamed in the 
* distribution/version notes.
* 
* H. Bristow 12075134@brookes.ac.uk
* ----------------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VinewatchX
{
    class Program
    {



        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);



            //args[0] = "--minimized";



            if (args.Length > 0)
            {
                if (args[0] == "--minimised" || args[0] == "--minimized")
                {
                    Application.Run(new MainForm(true));
                }
                else
                {
                    Application.Run(new MainForm(false));
                }
            }
            else
            {
                Application.Run(new MainForm(false));
            }
        }
    }
}
