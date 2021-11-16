//TODO: Refactor the code structure and optimize the algorithm.
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - SearchProcess.cs
 * Intro: Search for a process by its:
 * 1. name(fuzzy search)
 * 2. memory usage(ranged)
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Processes
{
    /// <summary>
    /// Search for a process by name or memory usage.
    /// </summary>
    class SearchProcess
    {
        //Process List
        private List<Process> processList = new List<Process>();

        //Process name list
        private List<String> processNameList = new List<String>();

        //Process memory usage Map
        private Dictionary<Process, Single> processMemoryUsageReflection = new Dictionary<Process, Single>();


        //Constructor (Initializer)
        public SearchProcess()
        {
            processList = new List<Process>(Process.GetProcesses());
            foreach (Process p in processList)
            {
                processNameList.Add(p.ProcessName);
                processMemoryUsageReflection.Add(p, p.PrivateMemorySize64);
            }
        }

        /// <summary>
        /// Search for a process by name.
        /// </summary>
        /// <param name="fuzzyname"></param>
        /// <returns>ProcessInfo</returns>
        private List<ProcessInfo> SearchByName(String fuzzyname)
        {
            Boolean exists = false; //The flag that checks if any process name is matched.
            Process[] pArray = null;
            #region local variables
            String fullname = "";
            Single memUsage = 0;
            String fullpath = "";
            #endregion
            foreach (String processName in processNameList)
            {
                if (processName.ToUpper().Contains(fuzzyname.ToUpper()) ||processName.ToUpper() == fuzzyname.ToUpper())
                {
                    pArray = Process.GetProcessesByName(processName);
                    exists = true;
                }
            }
            List<ProcessInfo> returnList = new List<ProcessInfo>();
            if (exists)
            {
                for (Int32 i = 0; i < pArray.Length; i++)
                {
                    Process p = pArray[i];
                    fullname = p.ProcessName;
                    //Assign the fields
                    memUsage += p.PrivateMemorySize64/1024/1024;
                    try
                    {
                        fullpath = p.MainModule.FileName.ToString();
                    }
                    catch (Exception) {
                        fullpath = Environment.MachineName+"(Virtual Process)";
                    }
                    
                    returnList.Add(new ProcessInfo(fullname, memUsage, fullpath));
                }
                return returnList;
            }
            else
            {
                throw new Exception("Process Not Found.");
            }
        }

        /// <summary>
        /// Search for a group of processes by ranged memory usage
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Process Information Group</returns>
        private List<ProcessInfo> SearchByMemoryUsage(Single min, Single max)
        {
            Process[] pArray = Process.GetProcesses();
            List<ProcessInfo> processInfoGroup = new List<ProcessInfo>();
            #region local variables
            String fullname = "";
            Single memUsage = 0;
            String fullpath = "";
            #endregion
            foreach (Process p in pArray)
            {
                if ((Single)p.PrivateMemorySize64/1024/1024 >= min && (Single)p.PrivateMemorySize64/1024/1024 <= max)
                { 
                    fullname = p.ProcessName;
                    memUsage = p.PrivateMemorySize64/1024/1024;
                    try
                    {
                        fullpath = p.MainModule.FileName.ToString();
                    }catch(Exception)
                    {
                    }
                    processInfoGroup.Add(new ProcessInfo(fullname, memUsage, fullpath));
                }
            }
            switch (processInfoGroup.Count)
            {
                case 0:
                    throw new Exception("Process Not Found.");
                default:
                    return processInfoGroup;
            }
        }

        /// <summary>
        /// Generate a String output for ProcessInfoGroup
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Templated Output String</returns>
        public String Generate_Output(Single min, Single max)
        {
            List<ProcessInfo> processInfoGroup = this.SearchByMemoryUsage(min, max);
            processInfoGroup.Sort(new ProcessInfoMemorySorter());
            String output = processInfoGroup.Count() + " Process(es) Matched.\n\n";
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(output);
            foreach(ProcessInfo pinfo in processInfoGroup)
            {
                strBuilder.Append(pinfo.GetProcessName() + ": "+pinfo.GetProcessMemoryUsage()+"MB, \nat "+
                    pinfo.GetFullPath()+"\n\n");
            }
            return strBuilder.ToString();
        }
        /// <summary>
        /// Generate a String output for ProcessInfoGroup
        /// </summary>
        /// <returns>Templated Output String</returns>
        public String Generate_Output(String name)
        {
            List<ProcessInfo> processInfoGroup = this.SearchByName(name);
            processInfoGroup.Sort(new ProcessInfoMemorySorter());
            String output = processInfoGroup.Count() + " Process(es) Matched.\n\n";
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(output);
            foreach (ProcessInfo pinfo in processInfoGroup)
            {
                strBuilder.Append(pinfo.GetProcessName() + ": " + pinfo.GetProcessMemoryUsage() + "MB, \nat " +
                    pinfo.GetFullPath() + "\n\n");
            }
            return strBuilder.ToString();
        }
        #region toolbox
        /// <summary>
        /// Get pids of a process by its name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Int32[] GetPIDArray(String name)
        {
            Process[] pArray = Process.GetProcessesByName(name);
            Int32[] pidArray = null;
            for (Int32 i = 0; i < pArray.Length; i++)
            {
                pidArray[i] = pArray[i].Id;
            }
            return pidArray;
        }
        #endregion
    }

    /// <summary>
    /// An entity that stores informations of a process.
    /// </summary>
    class ProcessInfo
    {
        //Fields
        private String processName;
        private Single processMemoryUsage;
        private String processFullPath; //Example: C:\Windows\System32\cmd.exe

        //All args Constructor
        public ProcessInfo(String pname, Single memusage, String path)
        {
            this.processName         = pname;
            this.processMemoryUsage  = memusage;
            this.processFullPath     = path;
        }

        //No arg Constructor
        public ProcessInfo()
        {

        }

        //Getters
        public String GetProcessName()
        {
            return this.processName;
        }
        public Single GetProcessMemoryUsage()
        {
            return this.processMemoryUsage;
        }
        public String GetFullPath()
        {
            return this.processFullPath;
        }
    }

    /// <summary>
    /// Sorter of List<ProcessInfo>
    /// </summary>
    class ProcessInfoMemorySorter : IComparer<ProcessInfo>
    {
        /// <summary>
        /// Compare the memusage of 2 ProcessInfo Object.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Int32</returns>
        public Int32 Compare(ProcessInfo pinfo1, ProcessInfo pinfo2)
        {
            return (pinfo1.GetProcessMemoryUsage().CompareTo(pinfo2.GetProcessMemoryUsage()));
        }
    }
}
//Program Entry @ Program.cs