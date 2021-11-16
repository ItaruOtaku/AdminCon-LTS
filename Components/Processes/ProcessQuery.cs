using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay;
using AdminCon_CLI_dotnetEdition.Components.Entities;
using AdminCon_CLI_dotnetEdition.Components.Sound;
using AdminCon_CLI_dotnetEdition.Components.SystemUtils;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - ProcessQuery.cs
* Intro: PrInt32 all processes with their details.
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Processes
{
    /// <summary>
    /// PrInt32 all processes with their details.
    /// </summary>
    class ProcessQuery
    {
        readonly ProcessAlgorithms processAlgorithms = new ProcessAlgorithms();
        public void ListProcesses(Int32 flag) //PrInt32 all processes and their RAM usage
        {
            if(flag == 0)
            {
                Process[] pArray = Process.GetProcesses();
                ProcessArray pList = new ProcessArray();
                foreach (Process p in pArray)
                {
                    pList.Add(p);
                }
                pList.Sort(new Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.PIDComparer()); //Project Amadeus: Desktop Development Kit
                ConsoleHL.WriteTitle("PID:" + PrintSpaces(6) + "Process Name:" + PrintSpaces(37) + "Memory Usage:" + "\n" +
                    "=========================================================================" + "\n");
                foreach (Process p in pList)
                {
                    ConsoleHL.WriteOutputLine(p.Id + PrintSpaces(10 - p.Id.ToString().Length) + p.ProcessName +
                        PrintSpaces(50 - p.ProcessName.Length) + processAlgorithms.getProcessMemoryUsage(p) + PrintSpaces(10 -
                        (processAlgorithms.getProcessMemoryUsage(p).ToString().Length)) + " KB");
                }
                ConsoleHL.WritePrompt("\n\n" + pList.GetLength() + " (sub)processes are running currently, \n\n" +
                    "Around " + (Int32)MemoryStatus.GetTotalMemoryUsageMB() + "MB of RAM is in use.");
                NotificationSounds SoundPlay = new NotificationSounds();
                SoundPlay.BeepComplete();
            }
            else if(flag == 1)
            {
                Process[] pArray = Process.GetProcesses();
                ProcessArray pList = new ProcessArray();
                foreach (Process p in pArray)
                {
                    pList.Add(p);
                }
                pList.Sort(new Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.PMEMComparer()); //Project Amadeus: Desktop Development Kit
                ConsoleHL.WriteTitle("PID:" + PrintSpaces(6) + "Process Name:" + PrintSpaces(37) + "Memory Usage:" + "\n" +
                    "=========================================================================" + "\n");
                foreach (Process p in pList)
                {
                    ConsoleHL.WriteOutputLine(p.Id + PrintSpaces(10 - p.Id.ToString().Length) + p.ProcessName +
                        PrintSpaces(50 - p.ProcessName.Length) + processAlgorithms.getProcessMemoryUsage(p) + PrintSpaces(10 -
                        (processAlgorithms.getProcessMemoryUsage(p).ToString().Length)) + " KB");
                }
                ConsoleHL.WritePrompt("\n\n" + pList.GetLength() + " (sub)processes are running currently, \n\n" +
                    "Around " + (Int32)MemoryStatus.GetTotalMemoryUsageMB() + "MB of RAM is in use.");
                NotificationSounds SoundPlay = new NotificationSounds();
                SoundPlay.BeepComplete();
            }
            else
            {
                throw new Exception("No Such Option.");
            }
        }
        public String PrintSpaces(Int32 count) //Use spaces to align texts
        {
            StringBuilder sb = new StringBuilder();
            for(Int32 i = 0; i < count; i ++)
            {
                sb.Append("\0");
            }
            return sb.ToString();
        }
    }
}
//Program Entry @ Program.cs