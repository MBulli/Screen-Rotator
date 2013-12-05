using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenRotator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                EnterConsoleMode(args);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }

        /// <summary>
        /// Enters the pseudo console mode
        /// </summary>
        /// <param name="args"></param>
        static void EnterConsoleMode(string[] args)
        {
            if (args == null)
                throw new ArgumentNullException("args");
            if (args.Length > 1)
            {
                DisplayHelp();
            }
            else
            {
                switch (args[0])
                {
                    case "-tl": ScreenRotator.ToggleLandscapeModes(); break;
                    case "-tp": ScreenRotator.TogglePotraitModes(); break;
                    case "-r": ScreenRotator.RotateScreen(); break;
                    //case "-bi": ScreenRotator.BlockInput(); break;
                    case "-h":
                    default: DisplayHelp(); break;
                }
            }
        }

        static void DisplayHelp()
        {
            string help = Properties.Resources.CmdHelp;

            MessageBox.Show(help, "Screen Rotator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
