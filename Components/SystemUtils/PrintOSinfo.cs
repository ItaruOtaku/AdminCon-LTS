using System;
using AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay;
using AdminCon_CLI_dotnetEdition.Components.Sound;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - PrintOSInfo.cs
 * Intro: Get basic informsations of Windows OS.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.SystemUtils
{
    /// <summary>
    /// PrInt32 OS-info and hardware info
    /// </summary>
    class PrintOSInfo
    {
        public void PrintSystemInfo()
        {
            Double tickcountMin = Math.Round((Double)Environment.TickCount /1000 / 60, 1);
            Double tickcountHour = Math.Round((Double)Environment.TickCount / 1000 / 60 /60, 1);
            Double tickcountDay = Math.Round((Double)Environment.TickCount / 1000 /60 /60 /24, 1);
            #region Get Machine Info
            //Get OS-Info
            String                 MACHINE_NAME =     Environment.MachineName;
            String   WINDOWS_NT_OS_VERSION_NAME =     Convert.ToString(Environment.OSVersion.Version);
            String                 SERVICE_PACK =     Environment.OSVersion.ServicePack;
                     WINDOWS_NT_OS_VERSION_NAME =     WINDOWS_NT_OS_VERSION_NAME + " " + SERVICE_PACK;
            String                    USER_NAME =     Environment.UserName;
            String                  DOMAIN_NAME =     Environment.UserDomainName;
            String                   TICK_COUNT =     tickcountMin.ToString() + " minutes (" + tickcountHour + " hours, " +tickcountDay + " days) ago";
            String             SYSTEM_PAGE_SIZE =    (Environment.SystemPageSize / 1024).ToString() + "KB";
            String                   SYSTEM_DIR =     Environment.SystemDirectory;
            String        PROCESSOR_CORES_COUNT =     Environment.ProcessorCount.ToString();
            String                     PLATFORM =     Environment.OSVersion.Platform.ToString();
            Boolean                 IS_64BIT_OS =     Environment.Is64BitOperatingSystem;
            Boolean            IS_X64_PROCESSOR =     Environment.Is64BitProcess;
            String                  CURRENT_DIR =     Environment.CurrentDirectory;
            String                 COMMAND_LINE =     Environment.CommandLine;
            String[]             LOGICAL_DRIVES =     Environment.GetLogicalDrives();
            String                    HOST_NAME =     System.Net.Dns.GetHostName();
            System.Net.IPAddress[]     ipadrlst =     System.Net.Dns.GetHostAddresses(HOST_NAME);
            #endregion
            #region PrInt32 Machine Info
            //PrInt32 Info
            Console.WriteLine("\n\n********* Computer Info *********\n\n");
            ConsoleHL.WriteOutput("\n||   Machine name: ");
            ConsoleHL.WriteInfoLine(MACHINE_NAME);
            ConsoleHL.WriteOutput("\n||   NT kernel version: ");
            ConsoleHL.WriteInfoLine(WINDOWS_NT_OS_VERSION_NAME);
            ConsoleHL.WriteOutput("\n||   User name: ");
            ConsoleHL.WriteInfoLine(USER_NAME);
            ConsoleHL.WriteOutput("\n||   Domain: ");
            ConsoleHL.WriteInfoLine(DOMAIN_NAME);
            ConsoleHL.WriteOutput("\n||   The last time system started: ");
            ConsoleHL.WriteInfoLine(TICK_COUNT);
            ConsoleHL.WriteOutput("\n||   System page size: ");
            ConsoleHL.WriteInfoLine(SYSTEM_PAGE_SIZE);
            ConsoleHL.WriteOutput("\n||   System directory: ");
            ConsoleHL.WriteInfoLine(SYSTEM_DIR);
            ConsoleHL.WriteOutput("\n||   Amount of cores of CPU: ");
            ConsoleHL.WriteInfoLine(PROCESSOR_CORES_COUNT);
            ConsoleHL.WriteOutput("\n||   Platform: ");
            ConsoleHL.WriteInfoLine(PLATFORM);
            ConsoleHL.WriteOutput("\n||   X64OS: ");
            ConsoleHL.WriteInfoLine(IS_64BIT_OS);
            ConsoleHL.WriteOutput("\n||   X64CPU: ");
            ConsoleHL.WriteInfoLine(IS_X64_PROCESSOR);
            ConsoleHL.WriteOutput("\n||   Current working directory: ");
            ConsoleHL.WriteInfoLine(CURRENT_DIR);
            ConsoleHL.WriteOutput("\n||   Location of AdminCon: ");
            ConsoleHL.WriteInfoLine(COMMAND_LINE);
            ConsoleHL.WriteOutput    ("\n||   Logical drives: ");
            for(Int32 i = 0; i < LOGICAL_DRIVES.Length; i++)
            {
                ConsoleHL.WriteInfo(LOGICAL_DRIVES[i] + "      "); //PrInt32 all available logical partitions
            }
            ConsoleHL.WriteOutput("\n\n||   Available IPv4-IPv6: \n");
            for (Int32 i = 0; i < ipadrlst.Length; i++)
            {
                ConsoleHL.WriteInfo("\n        "+ipadrlst[i] + "\n"); //PrInt32 available IPv4 and IPV6 addresses.
            }
            HardwareInfo hardwareInfo = new HardwareInfo();
            hardwareInfo.prInt32HardwareInfo();
            Console.WriteLine("\n\n********************************\n\n");
            #endregion
            NotificationSounds SoundPlay = new NotificationSounds();
            SoundPlay.BeepComplete();
        }
    }
}
//Program Entry @ Program.cs