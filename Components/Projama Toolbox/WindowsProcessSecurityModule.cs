using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
/* Project Amadeus - Windows Desktop Development SDK - WindowsProcessSecurityModule.cs
* Feature: The Security Module of Windows Kernel Processes
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security
{
    /// <summary>
    /// Windows Kernel Processes Security.
    /// This module provides basic correction and protection for operations to Windows Proccesses.
    /// </summary>
    public static class WindowsProcessSecurityModule
    {
        private static Int32[] KERNEL_PID_ARRAY = {0};

        /// <summary>
        /// Enum all important Window kernel proccesses.
        /// </summary>
        private enum IMPORTANT_PROCESSES_PNAMES // An Enum Collection of Windows Kernel Processes
        {
            svchost,rundll32,ctfmon,winlogon,wdfmgr,alg,smss,explorer,csrss,
            lsass,services,spoolsv,wmiprvse,Int32ernat,ntoskrnl
        }

        /// <summary>
        /// Convert enum members to String array.
        /// </summary>
        private static String[] pnameArr = Enum.GetNames(typeof(IMPORTANT_PROCESSES_PNAMES));

        /// <summary>
        /// Initialize the array of object "Process".
        /// </summary>
        /// <param name="coreProcessName"></param>
        private static void SetKERNEL_PID_ARRAY(String coreProcessName) // Initialize the array of PIDs of kernel processes (int32), set method.
        {
            Process[] KERNEL_PROCESS_ARRAY = Process.GetProcessesByName(coreProcessName);
            for(Int32 index = 0; index < KERNEL_PROCESS_ARRAY.Length; index ++)
            {
                KERNEL_PID_ARRAY[index] = Convert.ToInt32(KERNEL_PROCESS_ARRAY[index]);
            }
        }

        /// <summary>
        /// This method gets every single PID from the PID Array.
        /// </summary>
        /// <returns>Int32[]</returns>
        private static Int32[] GetKERNEL_PID_ARRAY() // The get method of PID array.
        {
            Array.Sort(KERNEL_PID_ARRAY);
            return KERNEL_PID_ARRAY;
        }

        /// <summary>
        /// This method creates an arraylist of instanciated objects of processes.
        /// </summary>
        /// <returns>ArrayList</returns>
        private static ArrayList IMPORTANT_KERNEL_PROCESSES_INIT()
        {
            ArrayList KRNL_P_ARR = null;
            foreach (String pname in pnameArr)
            {
                KRNL_P_ARR.Add(Process.GetProcessesByName(pname));
            }
            return KRNL_P_ARR;
        }
        
        private static Int32[] MemoryCompression()
        {
            foreach(String pname in pnameArr)
            {
                SetKERNEL_PID_ARRAY(pname);
            }
            Int32[] PID_Arr = GetKERNEL_PID_ARRAY();
            for(Int32 i = 0; i < PID_Arr.Length; i ++)
            {
                PID_Arr[i] = PID_Arr[i] << 2; // mov
            }
            return PID_Arr;
        }
    }
    /// <summary>
    /// This class implements the interface "IComparer". 
    /// Defines a compare mothod.
    /// </summary>
    class PIDComparer : IComparer<Process>
    {
        /// <summary>
        /// Compare the pid of 2 processes.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Int32</returns>
        public Int32 Compare(Process p1, Process p2)
        {
            return (p1.Id.CompareTo(p2.Id));
        }
    }
    /// <summary>
    /// This class implements the interface "IComparer". 
    /// Defines a compare mothod.
    /// </summary>
    class PMEMComparer : IComparer<Process>
    {
        /// <summary>
        /// Compare the pid of 2 processes.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Int32</returns>
        public Int32 Compare(Process p1, Process p2)
        {
            return (p1.PrivateMemorySize64.CompareTo(p2.PrivateMemorySize64));
        }
    }
}
//Program Entry @ Program.cs