using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - User32API.cs
* Intro: Win API C# equivalent - Winuser.h, user32.dll
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Win32
{
    class User32API
    {
        private static Hashtable processWnd = null;

        public delegate Boolean WNDENUMPROC(IntPtr hwnd, UInt32 lParam);

        static User32API()
        {
            if (processWnd == null)
            {
                processWnd = new Hashtable();
            }
        }

        [DllImport("user32.dll", EntryPoint = "EnumWindows", SetLastError = true)]
        public static extern Boolean EnumWindows(WNDENUMPROC lpEnumFunc, UInt64 lParam);

        [DllImport("user32.dll", EntryPoint = "GetParent", SetLastError = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern UInt32 GetWindowThreadProcessId(IntPtr hWnd, ref UInt32 lpdwProcessId);

        [DllImport("user32.dll", EntryPoint = "IsWindow")]
        public static extern Boolean IsWindow(IntPtr hWnd);

        [DllImport("kernel32.dll", EntryPoint = "SetLastError")]
        public static extern void SetLastError(UInt32 dwErrCode);

        public static IntPtr GetCurrentWindowHandle()
        {
            IntPtr ptrWnd = IntPtr.Zero;
            UInt32 uiPid = (UInt32)System.Diagnostics.Process.GetCurrentProcess().Id;  // Current PID
            Object objWnd = processWnd[uiPid];

            if (objWnd != null)
            {
                ptrWnd = (IntPtr)objWnd;
                if (ptrWnd != IntPtr.Zero && IsWindow(ptrWnd))  // Get handle from cache
                {
                    return ptrWnd;
                }
                else
                {
                    ptrWnd = IntPtr.Zero;
                }
            }

            Boolean bResult = EnumWindows(new WNDENUMPROC(EnumWindowsProc), uiPid);
            if (!bResult && Marshal.GetLastWin32Error() == 0)
            {
                objWnd = processWnd[uiPid];
                if (objWnd != null)
                {
                    ptrWnd = (IntPtr)objWnd;
                }
            }

            return ptrWnd;
        }

        private static Boolean EnumWindowsProc(IntPtr hwnd, UInt32 lParam)
        {
            UInt32 uiPid = 0;

            if (GetParent(hwnd) == IntPtr.Zero)
            {
                GetWindowThreadProcessId(hwnd, ref uiPid);
                if (uiPid == lParam)    // Find the handle of main window of process
                {
                    processWnd[uiPid] = hwnd;   // cache the handle
                    SetLastError(0);
                    return false;   // return false to terminate
                }
            }

            return true;
        }

    }
}
//Program Entry @ Program.cs