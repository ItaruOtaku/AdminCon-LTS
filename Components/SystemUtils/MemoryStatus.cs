using System;
using System.Collections.Generic;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - MemoryStatus.cs
* Intro: Get the memory usage status.
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.SystemUtils
{
    /// <summary>
    /// Get RAM total usage.
    /// </summary>
    [Serializable]
    public static class MemoryStatus
    {
        public static Double GetTotalMemoryUsageKB()
        { 
            Double totalMemoryUsage = 0;
            System.Diagnostics.Process[] pArray = System.Diagnostics.Process.GetProcesses();
            foreach(System.Diagnostics.Process p in pArray)
            {
                totalMemoryUsage += (p.PrivateMemorySize64 + p.PagedSystemMemorySize64 + p.NonpagedSystemMemorySize64);
            }
            return totalMemoryUsage / 1024;
        }
        public static Double GetTotalMemoryUsageMB()
        {
            return GetTotalMemoryUsageKB() / 1024;
        }
        public static Double GetTotalMemoryUsageGB()
        {
            return GetTotalMemoryUsageKB() / 1024 / 1024;
        }
        public static List<Single> GetMemoryUsage()
        {
            List<Single> list = new List<Single>();
            list.Add((Single)GetTotalMemoryUsageKB());
            list.Add((Single)GetTotalMemoryUsageMB());
            list.Add((Single)GetTotalMemoryUsageGB());
            return list;
        }
        public static Int32 GetMaxSupportedRAM_KB()
        {
            String timecmd = "wmic memphysical get maxcapacity"; //This wmic command will get maximum ram capacity.
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //Process start attributes
            {
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.WindowStyle =
                    System.Diagnostics.ProcessWindowStyle.Normal;
            }
            p.Start();
            p.StandardInput.WriteLine(timecmd + "&exit");
            p.StandardInput.AutoFlush = true; p.StandardInput.WriteLine("exit");//cmd.exe must quit from the current thread to avoid thread suspend.
            String output = p.StandardOutput.ReadToEnd(); //Method "ReadToEnd() will be suspended if cmd.exe is still occupying the current thread.

            String[] temp = output.Split(new String[] { "MaxCapacity" }, 0); //Why do this?
            /* Explain: 
             * The output of command "wmic memphysical get maxcapacity" looks like this:
             * 
             * C:\Users\User>wmic memphysical get maxcapacity
             * MaxCapacity
             * 33554432
             *        ^
             *        Need to get this part of String and *convert to Int32*. (Unit: KB)
             *                                                  |
             *                    ______________________________|
             *                   |
                                \|/                                                 
                                 v                                                  */
            return Convert.ToInt32(temp[temp.Length-1]);
        }
        public static Int32 GetMaxSupportedRAM_MB()
        {
            return GetMaxSupportedRAM_KB() / 1024;
        }
        public static Int32 GetMaxSupportedRAM_GB()
        {
            return GetMaxSupportedRAM_MB() / 1024;
        }
        public static List<Int32> GetMaxSupportedRAM()
        {
            List<Int32> list = new List<Int32>();
            list.Add(GetMaxSupportedRAM_KB());
            list.Add(GetMaxSupportedRAM_MB());
            list.Add(GetMaxSupportedRAM_GB());
            return list;
        }
    }
}
//Program Entry @ Program.cs