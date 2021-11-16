using System;
using System.Text;
using System.Windows.Forms;
using AdminCon_CLI_dotnetEdition.Components.@Global;
using AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay;
using AdminCon_CLI_dotnetEdition.Components.Modes;
using AdminCon_CLI_dotnetEdition.Components.Sound;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - Startup.cs
 * Intro: The class that launches program.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components
{
    /// <summary>
    /// Startup
    /// </summary>
    class Startup
    {
        private void ProgressBarController()
        {
            Random rd = new Random();
            for (Int32 i = 0; i < 24; i++)
            {
                ConsoleHL.WritePrompt(".");
                System.Threading.Thread.Sleep(rd.Next(1, 60));
            }
            Console.Write("\n");
        }
        #region Startup Function
        public void run(Boolean ProgramSwitch)
        {
            if (DateTime.Now.ToString("MM-dd").ToString().Equals("11-08") || DateTime.Now.ToString("MM-dd").ToString().Equals("01-11"))
            {
                RememberAaronSwartz Aaron = new RememberAaronSwartz();
                Aaron.says();
            }
            NotificationSounds soundplay = new NotificationSounds();
            Load STARTUP = new Load();
            ConsoleInteract COMMAND_PROMPT_INTERFACE = new ConsoleInteract();

            Console.WriteLine("Build " + ACInfo.buildVersion + ACInfo.buildDate +"@Windows_NT_" + Convert.ToString(Environment.OSVersion.Version) + "|AdminCon\n\n");
            STARTUP.Info(true);
            Console.WriteLine("\nInitializing Components:");
            ProgressBarController();
            Console.Write("\n");
            Console.Clear();
            soundplay.BeepLaunch();
            Console.Title = "AdminCon 7.0 - Shell";
            ConsoleHL.WriteTitleLine("AdminCon - Version " + ACInfo.versionNumber + " " + ACInfo.devCode);
            Console.WriteLine("(c) 2017-2021 Project Amadeus. All rights reserved.\n");
            ConsoleHL.WritePrompt("UAC Credential: ");
            ConsoleHL.WriteInfo("Administrator@"+Environment.MachineName);
            Console.WriteLine("\n\nType \"HELP\" to see available commands.\nType \"UI\" to enable the graphical interface." +
                "\nType \"INFO\" to view information of this program."+"\nType \"ACW32\" to launch the Win32 version of AdminCon."+
                "\n_____________________________________________________\n");
            Random random = new Random();
            if (random.Next(1, 100) % 5 == 0)
            {
                new BingoSounds();
                ConsoleHL.WriteTitle("Bingo! Easter Egg Activated." + "\nEaster egg command: " + ACInfo.easterEggKey);
            }
            while (ProgramSwitch == true)
            {
                Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.ObjectDiag.SetNull(COMMAND_PROMPT_INTERFACE);
                COMMAND_PROMPT_INTERFACE.ShellExecute();
                System.GC.Collect();
            }
            return;
        }
        internal void exit()
        {
            Environment.Exit(0);
        }
        #endregion
    }
}
//Program Entry @ Program.cs