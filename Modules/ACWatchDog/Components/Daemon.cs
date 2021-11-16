using Microsoft.VisualBasic.Devices;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
/* AdminCon 6.0 Command Line Interface Edition - Source Code - Daemon.cs
 * Intro: Daemon threads that monitors memory, cpu and disk.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.ACWatchDog.Components
{
    [Serializable]
    [PerformanceCounterPermission(System.Security.Permissions.SecurityAction.Assert)]
    internal class Daemon : IDisposable //Should be handled by Garbage Collect periodly.
    {
        ComputerInfo computerInfo = new ComputerInfo();
        //Fields
        public Double mem_Usage; // KB
        public int cpu_Usage; // 1
        public Double disk_IO_Speed;// Byte per sec
        public Double mem_Usage_Ratio;

        //Performance Counters
        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter diskCounter = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", "_Total");

        //Singleton object
        private static Daemon instance = new Daemon();

        /// <summary>
        /// .ctor()
        /// </summary>
        private Daemon()
        {
            //Create sync threads.
            ThreadStart memorySnapshot = new ThreadStart(MemoryUsageSnapshot);
            ThreadStart cpuSnapshot = new ThreadStart(CPU_UsageSnapshot);
            ThreadStart diskSnapshot = new ThreadStart(DiskUsageSnapshot);

            Thread memoryMonitorThread = new Thread(memorySnapshot);
            Thread CPUMonitorThread = new Thread(cpuSnapshot);
            Thread diskMonitorThread = new Thread(diskSnapshot);

            memoryMonitorThread.Start();
            CPUMonitorThread.Start();
            diskMonitorThread.Start();
        } //Not Constructable from outside.

        /// <summary>
        /// .dtor()
        /// </summary>
        ~Daemon()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Get a singleton instance.
        /// </summary>
        /// <returns></returns>
        public static Daemon GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Take a snapshot for memory usage randomly.
        /// </summary>
        /// 

        //When Too Many AC.EXE Processes are Created:
        /* Exception Stacktrace
         * Unhandled Exception: System.ComponentModel.Win32Exception: Could not obtain memory information due to internal error.
            at Microsoft.VisualBasic.Devices.ComputerInfo.InternalMemoryStatus.Refresh()
            at Microsoft.VisualBasic.Devices.ComputerInfo.InternalMemoryStatus.get_TotalPhysicalMemory()
            at AdminCon_CLI_dotnetEdition.Components.Global.Daemon.MemoryUsageSnapshot() in Daemon.cs:line 76
            at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object st
        ate, Boolean preserveSyncCtx)
            at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boo
        lean preserveSyncCtx)
            at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
            at System.Threading.ThreadHelper.ThreadStart()*/
        //Stacktrace Reference.
        private void MemoryUsageSnapshot()
        {
            int installedMemory_MB = (int)(computerInfo.TotalPhysicalMemory / 1024 / 1024);
            while(true)
            {
                try
                {
                    Thread.Sleep(new Random().Next(100, 600));
                    mem_Usage = (computerInfo.TotalPhysicalMemory -
                        computerInfo.AvailablePhysicalMemory) / 1024/1024;
                    mem_Usage_Ratio = ((mem_Usage / installedMemory_MB));
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Take a snapshot for cpu usage randomly.
        /// </summary>
        private void CPU_UsageSnapshot()
        {
            while(true)
            {
                try
                {
                    Thread.Sleep(new Random().Next(100, 600));
                    cpu_Usage = (int)cpuCounter.NextValue();
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Take a snapshot for disk usage randomly.
        /// </summary>
        private void DiskUsageSnapshot()
        {
            while(true)
            {
                try
                {
                    Thread.Sleep(new Random().Next(100, 600));
                    disk_IO_Speed = diskCounter.NextValue();
                }catch(Exception){ }
            }
        }

        /// <summary>
        /// ToString() method
        /// </summary>
        /// <returns>String</returns>
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Memory Usage: "+Math.Round(mem_Usage / 1024, 2) + " MB");
            sb.Append("\nCPU Usage: " + (int)cpu_Usage + "%");
            sb.Append("\nDisk Usage: "+Math.Round(disk_IO_Speed / 1024 / 1024, 2) + " MB/s");
            return sb.ToString();
        }

        /// <summary>
        /// Implemented Dispose() Method.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
