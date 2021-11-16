using System;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - Load.cs
 * Intro: Prompts
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay
{
    /// <summary>
    /// Prompts
    /// </summary>
    class Load
    {
        public void Info(Boolean isColored)
        {
            if(isColored == true)
            {
                Random ramdom = new Random();
                ConsoleHL.WriteOutputLine("System Environment Configured            -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                ConsoleHL.WriteOutputLine(".NET Runtime Configured                  -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                ConsoleHL.WriteOutputLine("Hard Disk Drive Detected                 -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                ConsoleHL.WriteOutputLine("Hardware status Detected                 -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                ConsoleHL.WriteOutputLine("Windows UAC Checked                      -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                ConsoleHL.WriteOutputLine("LIBFILE_LOADED: KERNEL32.dll             -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                ConsoleHL.WriteOutputLine("LIBFILE_LOADED: KERNELBASE.dll           -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                ConsoleHL.WriteOutputLine("LIBFILE_LOADED: ntdll.dll                -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                ConsoleHL.WriteOutputLine("LIBFILE_LOADED: combase.dll              -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                ConsoleHL.WriteOutputLine("LIBFILE_LOADED: MSCOREE.dll              -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                ConsoleHL.WriteOutputLine("Program Integrity Test                   -PIT_ATTEMPTED");
                System.Threading.Thread.Sleep(200);
                Console.WriteLine("\nDone.");
            }
            else
            {
                Random ramdom = new Random();
                Console.WriteLine("System Environment Configured            -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine(".NET Runtime Configured                  -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine("Hard Disk Drive Detected                 -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine("Hardware status Detected                 -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine("Windows UAC Checked                      -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine("LIBFILE_LOADED: KERNEL32.dll             -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine("LIBFILE_LOADED: KERNELBASE.dll           -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine("LIBFILE_LOADED: ntdll.dll                -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine("LIBFILE_LOADED: combase.dll              -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine("LIBFILE_LOADED: MSCOREE.dll              -TASK_COMPLETE");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine("Program Integrity Test                   -PIT_ATTEMPTED");
                System.Threading.Thread.Sleep(ramdom.Next(20,40));
                Console.WriteLine("Kernel Processes Secured                 -KPS_SAFE_MODE");
                System.Threading.Thread.Sleep(200);
                Console.WriteLine("\nDone.");
            }
        }
        public void help()
        {
            Console.Title = "AdminCon 7.0 - Help";
            ConsoleHL.WriteTitleLine("AdminCon - Version 4.0");
            Console.WriteLine("(c) 2017-2021 Project Amadeus. All rights reserved.\n");
            Console.WriteLine(@"Available Commands:

KILL    -   Kill a running process.
RUN     -   Start a process.
TIME    -   Show current system time.
GETMEM  -   Get the memory usage of a process. *
PERFSTAT -  Get usages of memory, cpu and disk of your system. *
GETPID  -   Get process id by its name.
FIND    -   Find processes that match the condition. *
PING    -   Send TCP packages to a specific IP Address or domain. *
ACW32   -   Launch the win32 version of AdminCon. *
CLS     -   Clear the console.
LISP    -   List all processes.
WINFO   -   PrInt32 infomation of your Windows PC.
FDISK   -   Format a specified drive. *
DFRG    -   Defrag a specified drive. *
EXIT    -   Exit this program. 
REST    -   Restart this program.
UI      -   Open a window with graphical interface. *
DELAY   -   Stop this program (or a running script) for a specified time.
PAUSE   -   Pause this program (or a running script). *
BEEP    -   The console will beep for once.

All commands are not case-sensitive.
*: This command is not available in safemode.
");
            Console.Write("Use  ");
            ConsoleHL.WriteOutput("ac.exe -s");
            Console.Write("    to run this program in safemode;\n");
            ConsoleHL.WriteOutput("     ac.exe -ui");
            Console.Write("   to run this program in GUI mode;\n");
            ConsoleHL.WriteOutput("     ac.exe -w32");
            Console.Write("  to run this program in win32 mode;\n");
            ConsoleHL.WriteOutput("     ac.exe -info");
            Console.Write(" to view info of this product.");
            Console.ReadKey();
        }
        public void ErrorInfo(String[] args)
        {
            Console.Title = "AdminCon";
            Console.WriteLine("AdminCon @" + Environment.MachineName + ": ");
            ConsoleHL.WriteErrorLine("Error - Bad Argument.");
            ConsoleHL.WriteOutputLine("\nArgument Given: ");
            foreach (String s in args)
            {
                ConsoleHL.WriteError(s);
            }
            Console.ReadKey();
        }
    }
}
//Program Entry @ Program.cs