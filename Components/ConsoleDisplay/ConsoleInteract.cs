using System;
using System.Collections.Generic;
using System.Text;
using AdminCon_CLI_dotnetEdition.Components.Command;
using AdminCon_CLI_dotnetEdition.Components.Configuration;
using AdminCon_CLI_dotnetEdition.Components.FileManagement;
using AdminCon_CLI_dotnetEdition.Components.@Global;
using AdminCon_CLI_dotnetEdition.Components.Modes;
using AdminCon_CLI_dotnetEdition.Components.Processes;
using AdminCon_CLI_dotnetEdition.Components.Sound;
using AdminCon_CLI_dotnetEdition.Components.SystemUtils;
using AdminCon_CLI_dotnetEdition.Components.UI;
using Microsoft.VisualBasic.Devices;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - ConsoleInteract.cs
* Intro: Command line interface IO controller.
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay
{
    interface ConsoleIO
    {
        void ShellExecute();
    }
    /// <summary>
    /// References functional classes.
    /// </summary>  
    class ConsoleInteract:ConsoleIO
    {
        public String command;
        #region Create readonly instances
        readonly GrammarAnalyzer      grammarAnalyzer      =    new     GrammarAnalyzer();
        readonly ProcessAlgorithms    processAlgorithms    =    new   ProcessAlgorithms();
        readonly PrintOSInfo          systemInfo           =    new         PrintOSInfo();
        readonly ProcessQuery         processQuery         =    new        ProcessQuery();
        readonly DiskOps              disk                 =    new             DiskOps();
        readonly NotificationSounds   notificationSounds   =    new  NotificationSounds();
        readonly Startup              program              =    new             Startup();
        readonly UserInterface        userInterface        =    new       UserInterface();
        readonly ScriptMode           script               =    new          ScriptMode();
        readonly SearchProcess        searchProcess        =    new       SearchProcess();
        readonly Program              mainProgram          =    new             Program();
        readonly ComputerInfo         computerInfo         =    new        ComputerInfo();
        readonly ToolRegist           toolreg              =    new          ToolRegist();
        readonly ProcessRef           processRef           =    new          ProcessRef();
        readonly String               EasterEggKey         =          ACInfo.easterEggKey;
        #endregion
        #region System Prompts
        private void PromptMsg_BadCommand()
        {
            String BAD_COMMAND_MSG = "Error - Bad Command.";
            ConsoleHL.WriteErrorLine(BAD_COMMAND_MSG);
            notificationSounds.BeepBadCommand();
        }
        //overload
        private void PromptMsg_BadCommand(Exception ex)//Exception handler prompt
        {
            ConsoleHL.WriteErrorLine(ex.Message);
            notificationSounds.BeepException();
        }
        private void PromptMsg_PressAnyKeyToContinue()
        {
            Console.WriteLine("Press any key to continue...");
        }
        #endregion
        public void ShellExecute()
        {
            Console.Title = "AdminCon "+ ACInfo.versionNumber + "- Shell";
            System.GC.Collect(); //Try to collect garbage once per statement execution.
            Console.Write("\n\nac:root/cli>");
            command = grammarAnalyzer.fix(Console.ReadLine());
            String cmdUpper = command.ToUpper();
            #region Internal Commands
            switch (cmdUpper)
            {
                //Null input:
                case "":
                    break;
                //Help Utilities.
                case "/?":
                case "HELP":
                    ConsoleHL.WriteOutputLine("Commands: ");
                    ConsoleHL.WriteHelpLine("\nProcess Operations: ");
                    ConsoleHL.WriteInfoLine("\nKILL    RUN    GETPID    GETMEM    LISP    FIND");
                    ConsoleHL.WriteHelpLine("\nSystem Utilities: ");
                    ConsoleHL.WriteInfoLine("\nFDISK    DFRG    PERFSTAT    TIME    PING    WINFO    HEX");
                    ConsoleHL.WriteHelpLine("\nFunctional Keywords: ");
                    ConsoleHL.WriteInfoLine("\nECHO    CLS    DELAY    UI    INFO    PAUSE    BEEP    ACW32    REST    EXIT");
                    ConsoleHL.WriteOutputLine("\n\n\nFields: "); ConsoleHL.WriteInfoLine("\n[PID]    [PNAME]    [IP_ADDRESS]      [DOMAIN]      [PATH]      [DRIVE] or more.");
                    ConsoleHL.WriteOutputLine("\n\n\nArguments: "); ConsoleHL.WriteInfoLine("\n/S: Field type of String" +
                     "    /I: Field type of Int32    /D: Disk drive letter");
                    ConsoleHL.WriteHelpLine("\n\n\nHELP + Command Name to view help info of this command.\nAll commands are not case-sensitive.");
                    ConsoleHL.WriteHelp("You can also write a batch script with extension name of");
                    ConsoleHL.WriteOutput(" .acs ");
                    ConsoleHL.WriteHelpLine("and open with this program.");
                    break;
                case "HELP KILL":
                case "KILL /?":
                    ConsoleHL.WriteHelpLine("\nKILL - Kill a running process.\n\nArguments: \nKILL /S [PNAME] - Kill a process " +
                        "by its name.\nKILL /I [PID] - Kill a process by its PID.");
                    break;
                case "KILL":
                    ConsoleHL.WriteHelpLine("\nKILL - Kill a running process.\n\nArguments: \nKILL /S [PNAME] - Kill a process " +
                        "by its name.\nKILL /I [PID] - Kill a process by its PID.");
                    break;
                case "HELP RUN":
                case "RUN /?":
                    ConsoleHL.WriteHelpLine("\nRUN - Start a process, or open a file.\n\nArguments: \nRUN /S [PNAME] - Start a process by its name." +
                        "\nRUN /S [PATH] - Open a file in specific path.");
                    break;
                case "RUN":
                    ConsoleHL.WriteHelpLine("\nRUN - Start a process, or open a file.\n\nArguments: \nRUN /S [PNAME] - Start a process by its name." +
                        "\nRUN /S [PATH] - Open a file in specific path.");
                    break;
                case "HELP TIME":
                case "TIME /?":
                    ConsoleHL.WriteHelpLine("\nTIME - PrInt32 current time.\n\nArguments: none.");
                    break;
                case "TIME":
                    ConsoleHL.WriteOutputLine(System.DateTime.Now.ToString() + "\n");
                    break;
                case "HELP GETPID":
                case "GETPID /?":
                    ConsoleHL.WriteHelpLine("\nGETPID - Get Process ID by its name.\n\nArguments:\nGETPID /S [PNAME]\n");
                    break;
                case "GETPID":
                    ConsoleHL.WriteHelpLine("\nGETPID - Get Process ID by its name.\n\nArguments:\nGETPID /S [PNAME]\n");
                    break;
                case "HELP PING":
                case "PING /?":
                    ConsoleHL.WriteHelpLine("\nPING - Send TCP packages to a specific IP Address or domain."
                        + "\nArguments: \nPING /S [IP_ADDRESS] or PING /S [DOMAIN]" + "\n\nExample(s):\n " +
                    "      PING /S 192.168.0.1     PING /S LOCALHHOST     PING /S GOOGLE.COM \n");
                    break;
                case "PING":
                    ConsoleHL.WriteHelpLine("\nPING - Send TCP packages to a specific IP Address or domain."
                        + "\nArguments: PING /S [IP_ADDRESS] or PING /S [DOMAIN]" + "\n\nExample(s):\n " +
                    "      PING /S 192.168.0.1     PING /S LOCALHOST     PING /S GOOGLE.COM \n");
                    break;
                case ("HELP CLS"):
                case "CLS /?":
                    ConsoleHL.WriteHelpLine("\nCLS - Clear the console.\n\nArguments: none.");
                    break;
                case "CLS":
                    Console.Clear();
                    break;
                case ("HELP LISP"):
                case "LISP /?":
                    ConsoleHL.WriteHelpLine("\nLISP - List all processes.\n\nArguments: \nLISP -I or LISP" +
                        " - Sort processes by id." +
                        "\nLISP -M - Sort processes by memory usage.");
                    break;
                case ("LISP"):
                case ("LISP -I"):
                    processQuery.ListProcesses(0);
                    break;
                case ("LISP -M"):
                    processQuery.ListProcesses(1);
                    break;
                case ("HELP WINFO"):
                case "WINFO /?":
                    ConsoleHL.WriteHelpLine("\nWINFO - PrInt32 infomation of your Windows PC.\n\nArguments: none.");
                    break;
                case ("WINFO"):
                    Console.Title = "Gathering Information...";
                    systemInfo.PrintSystemInfo();
                    break;
                case "HEX":
                case "HELP HEX":
                case "HEX /?":
                    ConsoleHL.WriteHelpLine("\nHEX - View the binary code of a source file in hex.\n\nArguments: \nHEX /S [FILEPATH] - View hex code of this file");
                    break;
                case "HELP FDISK":
                case "FDISK /?":
                    ConsoleHL.WriteHelpLine("\nFDISK - Format a specified drive.\n\nArguments: \nFDISK /D [DRIVE] - Format a drive." +
                        "\n\nExample(s):\n" + "FDISK /D D:\\" + " - Format drive D:\\.");
                    break;
                case "FDISK":
                    ConsoleHL.WriteHelpLine("\nFDISK - Format a specified drive.\n\nArguments: \nFDISK /D [DRIVE] - Format a drive." +
                        "\n\nExample(s):\n" + "FDISK /D D:\\" + " - Format drive D:\\.");
                    break;
                case "HELP DFRG":
                case "DFRG /?":
                    ConsoleHL.WriteHelpLine("\nDFRG - Defrag a specified drive.\n\nArguments: \nDFRG /D [DRIVE] - Defrag a drive." +
                        "\n\nExample(s):\n" + "DFRG /D C:\\" + " - Defrag drive C:\\.");
                    break;
                case "DFRG":
                    ConsoleHL.WriteHelpLine("\nDFRG - Defrag a specified drive.\n\nArguments: \nDFRG /D [DRIVE] - Defrag a drive." +
                        "\n\nExample(s):\n" + "DFRG /D C:\\" + " - Defrag drive C:\\.");
                    break;
                case "HELP UI":
                case "UI /?":
                    ConsoleHL.WriteHelpLine("\nUI - Open a window with graphical interface.\n\nArguments: none.");
                    break;
                case "UI":
                    userInterface.UIWindow_StartInNewThread();
                    break;
                case "HELP INFO":
                case "INFO /?":
                    ConsoleHL.WriteHelpLine("\nINFO - View information of this program.\n\nArguments: none.");
                    break;
                case "INFO":
                    userInterface.AboutWindow_StartInNewThread();
                    break;
                case "DELAY":
                case "HELP DELAY":
                case "DELAY /?":
                    ConsoleHL.WriteHelpLine("\nDELAY - Stop the program in specific milliseconds.\n\nArguments: \nDELAY /I 1000 - Stop the program for 1000 ms.");
                    break;
                case "HELP PAUSE":
                case "PAUSE /?":
                    ConsoleHL.WriteHelpLine("\nPAUSE - Pause the program.\n\nArguments: none");
                    break;
                case "PAUSE":
                    PromptMsg_PressAnyKeyToContinue();
                    Console.ReadKey();
                    break;
                case "GETMEM":
                case "GETMEM /?":
                case "HELP GETMEM":
                    ConsoleHL.WriteHelpLine("\nGETMEM - Get the memory usage of a process.\n\nArguments: \nGETMEM /S [PNAME] - Get memory usage of a process " +
                        "by its name.\nGETMEM /I [PID] - Get memory usage of a process by its PID.");
                    break;
                case "HELP ACW32":
                case "ACW32 /?":
                    ConsoleHL.WriteHelpLine("\nACW32: Start the Win32 version of AdminCon.\n\nArguments: none.");
                    break;
                case "ACW32":
                    try
                    {
                        //1. Get the directory of ac.exe
                        String ac_workingdir = Environment.CommandLine.ToUpper().Replace("\"", null);//delete " " from start and end of String.
                        //result: [path]\ac.exe

                        //2. Remove "AC.EXE" from ac_workingdir
                        String acw32_path = ac_workingdir.Replace("AC.EXE", null);
                        Char[] acw32_pathInChars = acw32_path.ToCharArray();
                        List<Char> acw32_pathIncharList = new List<Char>(acw32_pathInChars);
                        acw32_pathIncharList.Remove(' '); //remove the blankspace at the end of array to concat.
                        acw32_path = new String(acw32_pathIncharList.ToArray());
                        //result: [path]

                        //3. Concat the path with the location of acwin32.exe
                        StringBuilder sb = new StringBuilder();
                        sb.Append(acw32_path);
                        sb.Append("TOOLS\\ACWIN32.EXE");
                        acw32_path = sb.ToString();
                        //result: [path]\TOOLS\ACWIN32.EXE

                        //4. Start the process.
                        System.Diagnostics.Process.Start(acw32_path);
                    }catch(Exception ex) { ConsoleHL.WriteErrorLine(ex.Message); }
                    break;
                case "BEEP":
                    Console.Beep(800, 200);
                    break;
                case "HELP BEEP":
                case "BEEP /?":
                    ConsoleHL.WriteHelpLine("\nBEEP - The console will beep for once.\n\nArguments: none");
                    break;
                case "ECHO /?":
                case "HELP ECHO":
                    ConsoleHL.WriteHelpLine("\nECHO - Displays messages.\nArguments: ECHO [TEXT] - Display some text.");
                    break;
                case "PERFSTAT":
                    #region Performace Information Output
                    Console.Title = "Gathering Information...";
                    Single[] memoryUsage = MemoryStatus.GetMemoryUsage().ToArray();
                    Int32[] maxSupRAM = MemoryStatus.GetMaxSupportedRAM().ToArray();

                    Double totalAvailablePhysicalMemory = computerInfo.TotalPhysicalMemory; //Installed RAM
                    Double availablePhysicalMemory = computerInfo.AvailablePhysicalMemory;  //Free space

                    ConsoleHL.WriteOutput("Estimated Memory Usage: ");
                    ConsoleHL.WritePrompt(Math.Round(mainProgram.daemon.mem_Usage / 1024, 2) + " MB"+"/Total "+
                        Math.Round(totalAvailablePhysicalMemory/1024/1024,2)+"MB, "+ Math.Round(mainProgram.daemon.rest_memUsage / 1024, 2)+"MB Free.");

                    ConsoleHL.WriteOutput("\nEstimated CPU Usage: ");
                    ConsoleHL.WritePrompt((Int32)mainProgram.daemon.cpu_Usage + "%\n");

                    ConsoleHL.WriteOutput("Estimated Hard Disk Usage: ");
                    ConsoleHL.WritePrompt(Math.Round(mainProgram.daemon.disk_IO_Speed / 1024 / 1024, 2) + " MB/s\n");

                    ConsoleHL.WriteOutput("\nMaximum Supported Capacity of RAM On This Machine: ");
                    ConsoleHL.WriteErrorLine(maxSupRAM[2]+"GB");
                    #endregion
                    break;
                case "PERFSTAT /?":
                case "HELP PERFSTAT":
                    ConsoleHL.WriteHelpLine("\nPERFSTAT: Get usages of memory, cpu and disk of your system.\n\nArguments: none.");
                    break;
                case "REST":
                    Console.Clear();
                    notificationSounds.BeepQuit();
                    program.run(false);
                    break;
                case "REST /?":
                case "HELP REST":
                    ConsoleHL.WriteHelpLine("\nREST: Restart this program.\n\nArguments: none.");
                    break;
                case "FIND":
                case "FIND /?":
                case "HELP FIND":
                    ConsoleHL.WriteHelpLine("\nFIND - Find processes that match the condition.\n\nArguments: \nFIND /S [PNAME] - Find a process by its name." +
                        "\nFIND /I Min-Max - Find a group of processes by their memory usages (MB).\n\nExample(s): \nFIND /S svc - Find a process whose name contains \"svc\""+
                        "\nFIND /I 100-1024 - Find for all processes that take up 100MB~1024MB of RAM.");
                    break;
                case "EXIT":
                    notificationSounds.BeepQuit();
                    program.exit();
                    break;
                case "EXIT /?":
                case "HELP EXIT":
                    ConsoleHL.WriteHelpLine("\nEXIT: Exit this program.\n\nArguments: none.");
                    break;
                #endregion
                #region Commands With Arguments and Fields
                default:
                    String cmds = grammarAnalyzer.getCommand(cmdUpper);
                    String field = grammarAnalyzer.getField(cmdUpper);
                    String arg = grammarAnalyzer.getArgument(cmdUpper);
                    try
                    {
                        if (toolreg.CheckIfRegistered(command, 0) == true)
                        {
                            //Launch personalized executable
                            System.Diagnostics.Process.Start(ACInfo.locationPath + "\\tools\\" + toolreg.GetProgramFileName(command,0));
                        }
                        else if (cmds == "HEX")
                        {
                            if(field == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if(field == "/S")
                            {
                                new BinaryToHexDisplay(arg).RunHexProgram(0);
                            }
                            else
                            {
                                PromptMsg_BadCommand();
                            }
                        }
                        else if (command.StartsWith("echo"))
                        {
                            String[] kv = command.Split(' ');
                            try
                            {
                                ConsoleHL.WriteOutput(kv[1] + "\n");
                            }
                            catch (Exception) { }
                        }
                        else if(command.ToLower() == EasterEggKey)
                        {
                            userInterface.EasterEggWindow_StartInNewThread();
                        }
                        else if ((0 < cmds.Length && 3 >= cmds.Length) && (cmds.Contains(":") || cmds.Contains(":\\")))
                        {
                            try
                            {
                                disk.OpenDrive(cmds);
                            }
                            catch (Exception ex)
                            {
                                PromptMsg_BadCommand(ex);
                            }
                        }
                        else if (cmds == "FIND")
                        {
                            if (field == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (field == "/S")
                            {
                                ConsoleHL.WriteOutput(searchProcess.Generate_Output(arg));
                            }
                            else if (field == "/I")
                            {
                                try
                                {
                                    Single min = (Single)Convert.ToDouble(arg.Split('-')[0]);
                                    Single max = (Single)Convert.ToDouble(arg.Split('-')[1]);
                                    ConsoleHL.WriteOutput(searchProcess.Generate_Output(min, max));
                                    notificationSounds.BeepComplete();
                                }
                                catch (Exception ex)
                                {
                                    PromptMsg_BadCommand(ex);
                                }
                            }
                        }
                        else if (cmds.Contains(".ACS"))
                        {
                            script.ShellExecute(cmds);
                        }
                        else if (cmds == "GETMEM")
                        {
                            if (field == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (field == "/S")
                            {
                                Single memusage = processAlgorithms.getProcessMemoryUsage(arg);
                                if (memusage == 0)
                                {
                                    notificationSounds.BeepException();
                                    ConsoleHL.WriteErrorLine("Process Not Found.");
                                }
                                else
                                {
                                    try
                                    {
                                        ConsoleHL.WriteOutputLine("Memory Usage of " + arg + ": " + processAlgorithms.getProcessMemoryUsage(arg) + " KB");
                                    }
                                    catch (Exception ex)
                                    {
                                        PromptMsg_BadCommand(ex);
                                    }
                                }
                            }
                            else if (field == "/I")
                            {
                                try
                                {
                                    ConsoleHL.WriteOutputLine("Memory Usage of PID(" + arg + "): " + processAlgorithms.getProcessMemoryUsage(Convert.ToInt32(arg)) + " KB");
                                }
                                catch (Exception)
                                {
                                    ConsoleHL.WriteErrorLine("Process Not Found.");
                                    notificationSounds.BeepException();
                                }
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (cmds == "DELAY")
                        {
                            if (field == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (field == "/I")
                            {
                                System.Threading.Thread.Sleep(Convert.ToInt32(arg));
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (cmds == "FDISK")
                        {
                            if (field == null) { PromptMsg_BadCommand(); }
                            else if (field == "/D")
                            {
                                disk.formatdisk(arg);
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (cmds == "DFRG")
                        {
                            if (field == null) { PromptMsg_BadCommand(); }
                            else if (field == "/D")
                            {
                                disk.diskdefragment(arg);
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (cmds == "KILL")
                        {
                            if (field == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (field == "/S")
                            {
                                if(processRef.CheckIfRegistered(arg,0))
                                {
                                    processAlgorithms.KillProcess(processRef.GetProcessName(arg, 0));
                                }
                                else
                                {
                                    try
                                    {
                                        processAlgorithms.KillProcess(arg);
                                    }
                                    catch (Exception ex)
                                    {
                                        PromptMsg_BadCommand(ex);
                                    }
                                }
                            }
                            else if (field == "/I")
                            {
                                try
                                {
                                    processAlgorithms.KillProcessByPID(Convert.ToInt32(arg));
                                }
                                catch (Exception)
                                {
                                    ConsoleHL.WriteErrorLine("Process Not Found.");
                                    notificationSounds.BeepException();
                                }
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (cmds == "RUN")
                        {
                            if (field == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (field == "/S")
                            {
                                try
                                {
                                    System.Diagnostics.Process.Start(arg);
                                }
                                catch (Exception ex)
                                {
                                    PromptMsg_BadCommand(ex);
                                }
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (cmds == "GETPID")
                        {
                            if (field == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (field == "/S")
                            {
                                try
                                {
                                    ConsoleHL.WriteOutputLine(processAlgorithms.PrInt32PID(arg) + "\n");
                                }
                                catch (Exception)
                                {
                                    ConsoleHL.WriteErrorLine("Process Not Found.");
                                    notificationSounds.BeepException();
                                }
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (cmds == "PING")
                        {
                            if (field == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (field == "/S")
                            {
                                ConsoleHL.WriteOutputLine("Please Wait......\n");
                                String timecmd = "ping " + arg;
                                System.Diagnostics.Process p = new System.Diagnostics.Process();
                                p.StartInfo.FileName = "cmd.exe";
                                p.StartInfo.UseShellExecute = false;
                                p.StartInfo.RedirectStandardInput = true;
                                p.StartInfo.RedirectStandardOutput = true;
                                p.StartInfo.RedirectStandardError = true;
                                p.StartInfo.WindowStyle =
                                    System.Diagnostics.ProcessWindowStyle.Normal;
                                p.Start();
                                p.StandardInput.WriteLine(timecmd + "&exit");
                                p.StandardInput.AutoFlush = true;
                                p.StandardInput.WriteLine("exit");//cmd.exe must quit from the current thread to avoid thread suspend.
                                String output = p.StandardOutput.ReadToEnd(); //Method "ReadToEnd() will be suspended if cmd.exe is still occupying the current thread. 
                                String[] temp = output.Split(new String[] { "Pinging " + arg + " with 32 bytes of data:" }, 0);
                                p.WaitForExit();
                                p.Close();
                                ConsoleHL.WriteOutputLine(temp[temp.Length - 1]);
                                notificationSounds.BeepComplete();
                            }
                            else
                            {
                                PromptMsg_BadCommand(); 
                            }
                        }
                        else
                        {
                            PromptMsg_BadCommand();
                        }
                    }
                    catch (Exception ex)
                    {
                        PromptMsg_BadCommand(ex);
                    }
                    break;
                    #endregion
            }
        }
    }
}
//Program Entry @ Program.cs