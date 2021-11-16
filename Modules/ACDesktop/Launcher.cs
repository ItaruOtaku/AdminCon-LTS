using AdminCon_CLI_dotnetEdition.Modules.ACDesktop.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - Launcher.cs
 * Intro: The class that launches program.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.ACDesktop
{
    class Launcher
    {
        [STAThread]
        static void Main(String[] args) //Program entry
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DesktopEnvironment());
        }
    }
}
