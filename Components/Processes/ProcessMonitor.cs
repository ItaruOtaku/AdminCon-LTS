using System;
using System.Diagnostics;

namespace AdminCon_CLI_dotnetEdition.Components.Processes
{
    public class ProcessMonitor
    {
        #region Constants
        private const String KB = "KB";
        private const String MB = "MB";
        private const Int32 processAlgorithms_32BIT_BYTELENGTH = 32 * 8;
        private const Int32 processAlgorithms_64BIT_BYTELENGTH = 64 * 8;
        #endregion

        //private Int32  threadCount;
        //private long memoryUsage;

        public ProcessMonitor(Process p)
        {
            //this.threadCount = GetThreadCount(p);
            //this.memoryUsage = GetPrivateMemoryUsage_KB(p);
        }
        public ProcessMonitor()
        {

        }
        private Int32 GetThreadCount(Process p)
        {
            ProcessThreadCollection PTC = p.Threads;
            return PTC.Count;
        }
        public Single GetPhysicalMemoryUsage_KB(Process p)
        {
            return p.WorkingSet64 / 1024;
        }
        public Single GetPrivateMemoryUsage_KB(Process p)
        {
            return p.PrivateMemorySize64 / 1024;
        }
        public Single GetPagedMemoryUsage_KB(Process p)
        {
            return p.PagedMemorySize64;
        }
    }
}
//Program Entry @ Program.cs