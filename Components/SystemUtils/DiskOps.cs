using System;
using System.Diagnostics;
using AdminCon_CLI_dotnetEdition.Components.Sound;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - DiskOps.cs
 * Intro: Disk Operations Module
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.SystemUtils
{
    /// <summary>
    /// Disk Operations Module
    /// </summary>
    class DiskOps
    {
        public void OpenDrive(String driveletter) //Input C:\ or C: to open a logical drive
        {
            NotificationSounds notificationSounds = new NotificationSounds();
            try
            {
                Process.Start(driveletter);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                notificationSounds.BeepException();
            }
        }
        public void formatdisk(String driveletter) //Format a logical partition
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("format.com", driveletter); //Add param when launch format.com
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }
        public void diskdefragment(String driveletter) //Defrag the selected logical partition
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo("defrag.exe", driveletter);
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }
    }
}
