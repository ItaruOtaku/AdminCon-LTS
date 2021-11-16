using System;
using AdminCon_CLI_dotnetEdition.Components.@Global;
using AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay;
using AdminCon_CLI_dotnetEdition.Components.Processes;
using AdminCon_CLI_dotnetEdition.Components.Sound;
using AdminCon_CLI_dotnetEdition.Components.SystemUtils;
using AdminCon_CLI_dotnetEdition.Components.UI;
using AdminCon_CLI_dotnetEdition.Components.Command;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - Safemode.cs
* Intro: CLI in safemode
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Modes
{
    /// <summary>
    /// Safemode
    /// </summary>
    class SafemodeCLI : ConsoleIO
    {
        #region Create readonly instances
        readonly GrammarAnalyzer    grammarAnalyzer     =    new     GrammarAnalyzer();
        readonly ProcessAlgorithms  processAlgorithms   =    new   ProcessAlgorithms();
        readonly PrintOSInfo        systemInfo          =    new         PrintOSInfo();
        readonly ProcessQuery       processQuery        =    new        ProcessQuery();
        readonly DiskOps            disk                =    new             DiskOps();
        readonly NotificationSounds notificationSounds  =    new  NotificationSounds();
        readonly SafemodeStartup    program             =    new     SafemodeStartup();
        readonly UserInterface      userInterface       =    new       UserInterface();
        #endregion
        private void PromptMsg_BadCommand()
        {
            String BAD_COMMAND_MSG = "Error - Bad Command.";
            Console.WriteLine(BAD_COMMAND_MSG);
            notificationSounds.BeepBadCommand();
        }
        private void PromptMsg_NotAllowedInSafemode()
        {
            String BAD_COMMAND_MSG = "The current operation is not allowed in safemode.\n";
            Console.WriteLine(BAD_COMMAND_MSG);
            notificationSounds.BeepBadCommand();
        }
        public void ShellExecute()
        {
            System.GC.Collect(); //Try to collect garbage once per statement execution.
            Console.Write("\n\nac:safemode/cli>");
            String command = Console.ReadLine();
            String cmdUpper = command.ToUpper();
            #region Internal Commands
            switch (cmdUpper)
            {
                //Null input:
                case "":
                    break;
                //Help Utilities.
                case "BEEP":
                    Console.Beep(800, 200);
                    break;
                case "HELP BEEP":
                    ConsoleHL.WriteHelpLine("\n\nBEEP - The console will beep for once.\n\nArguments: none");
                    break;
                case "/?":
                case "HELP":
                    Console.WriteLine("\nCommands: ");
                    Console.WriteLine("\nKILL    RUN    TIME    GETPID    CLS    WINFO     LISP    BEEP\n\nREST    ECHO    EXIT");
                    Console.WriteLine("\n\n\nFields: "); Console.WriteLine("\n[PID]    [PNAME]");
                    Console.WriteLine("\n\n\nArguments: "); Console.WriteLine("\n/S: Field type of String" +
                     "    /I: Field type of Int32");
                    Console.WriteLine("\n\n\nHELP + Command Name to view help info of this command.\nAll commands are not case-sensitive.");
                    break;
                case "HELP INFO":
                case "INFO /?":
                    Console.WriteLine("\nINFO - View information of this program.\n\nArguments: none.");
                    break;
                case "INFO":
                    userInterface.AboutWindow_StartInNewThread();
                    break;
                case "HELP KILL":
                case "KILL /?":
                    Console.WriteLine("\nKILL - Kill a running process.\n\nArguments: \nKILL /S [PNAME] - Kill a process " +
                        "by its name.\nKILL /I [PID] - Kill a process by its PID.");
                    break;
                case "KILL":
                    Console.WriteLine("\nKILL - Kill a running process.\n\nArguments: \nKILL /S [PNAME] - Kill a process " +
                        "by its name.\nKILL /I [PID] - Kill a process by its PID.");
                    break;
                case "HELP RUN":
                case "RUN /?":
                    Console.WriteLine("\nRUN - Start a process, or open a file.\n\nArguments: \nRUN /S [PNAME] - Start a process by its name." +
                        "\nRUN /S [PATH] - Open a file in specific path.");
                    break;
                case "RUN":
                    Console.WriteLine("\nRUN - Start a process, or open a file.\n\nArguments: \nRUN /S [PNAME] - Start a process by its name." +
                        "\nRUN /S [PATH] - Open a file in specific path.");
                    break;
                case "HELP TIME":
                case "TIME /?":
                    Console.WriteLine("\nTIME - PrInt32 current time.\n\nArguments: none.");
                    break;
                case "TIME":
                    Console.WriteLine(DateTime.Now.ToString() + "\n");
                    break;
                case "HELP GETPID":
                case "GETPID /?":
                    Console.WriteLine("\nGETPID - Get Process ID by its name.\n\nArguments:\nGETPID /S [PNAME]\n");
                    break;
                case "GETPID":
                    Console.WriteLine("\nGETPID - Get Process ID by its name.\n\nArguments:\nGETPID /S [PNAME]\n");
                    break;
                case ("HELP CLS"):
                case ("CLS /?"):
                    Console.WriteLine("\nCLS - Clear the console.\n\nArguments: none.");
                    break;
                case "CLS":
                    Console.Clear();
                    break;
                case ("HELP LISP"):
                case "LISP /?":
                    ConsoleHL.WriteHelpLine("\nLISP - List all processes.\n\nArguments: \nLISP -I or LISP - Sort processes by id." +
                       "\nLISP -M - Sort processes by memory usage.");
                    break;
                case ("LISP"):
                case "LISP -I":
                    processQuery.ListProcesses(0);
                    break;
                case "LISP -M":
                    processQuery.ListProcesses(0);
                    break;
                case ("HELP WINFO"):
                case "WINFO /?":
                    Console.WriteLine("\nWINFO - PrInt32 infomation of your Windows machine.\n\nArguments: none.");
                    break;
                case ("WINFO"):
                    Console.Title = "Gathering Information...";
                    systemInfo.PrintSystemInfo();
                    break;
                case "REST":
                    Console.Clear();
                    notificationSounds.BeepQuit();
                    program.saferun(false);
                    break;
                case "REST /?":
                case "HELP REST":
                    ConsoleHL.WriteHelpLine("\nREST: Restart this program.\n\nArguments: none.");
                    break;
                case "ECHO /?":
                case "HELP ECHO":
                    ConsoleHL.WriteHelpLine("\n\nECHO - Displays messages.\nArguments: ECHO [TEXT] - Display some text.");
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
                    String para = grammarAnalyzer.getField(cmdUpper);
                    String keyw = grammarAnalyzer.getArgument(cmdUpper);
                    try
                    {
                        if (command.StartsWith("echo"))
                        {
                            String[] kv = command.Split(' ');
                            ConsoleHL.WriteOutput(kv[1] + "\n");
                        }
                        else if ((0 < cmds.Length && 3 >= cmds.Length) && (cmds.Contains(":") || cmds.Contains(":\\")))
                        {
                            try
                            {
                                disk.OpenDrive(cmds);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                notificationSounds.BeepException();
                            }
                        }
                        else if (cmds == "KILL")
                        {
                            if (para == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (para == "/S")
                            {
                                if (keyw == "SVCHOST" || keyw == "SVCHOST.EXE"
                                    || keyw == "NTOSKRNL" || keyw == "NTOSKRNL.EXE"
                                    || keyw == "SYSTEM" || keyw == "IDLE"|| keyw 
                                    == "EXPLORER" || keyw == "EXPLORER.EXE")
                                {
                                    PromptMsg_NotAllowedInSafemode();
                                }
                                else
                                {
                                    try
                                    {
                                        processAlgorithms.KillProcess(keyw);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        notificationSounds.BeepException();
                                    }
                                }

                            }
                            else if (para == "/I")
                            {
                                try
                                {
                                    processAlgorithms.KillProcessByPID(Convert.ToInt32(keyw));
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Process Not Found.");
                                    notificationSounds.BeepException();
                                }
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (cmds == "RUN")
                        {
                            if (para == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (para == "/S")
                            {
                                try
                                {
                                    System.Diagnostics.Process.Start(keyw);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    notificationSounds.BeepException();
                                }
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (cmds == "GETPID")
                        {
                            if (para == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (para == "/S")
                            {
                                try
                                {
                                    Console.WriteLine(processAlgorithms.PrInt32PID(keyw) + "\n");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Process Not Found.");
                                    notificationSounds.BeepException();
                                }
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else
                        {
                            PromptMsg_BadCommand();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "\n");
                        notificationSounds.BeepException();
                    }
                    break;
                    #endregion
            }
        }
    }
    class SafemodeStartup
    {
        private void ProgressBarController()
        {
            // You are not allowed to view this.
            // No, you are not allowed. Trust me.
            // Only God and me should know what does this function do.
            Random rd = new Random();
            for (Int32 i = 0; i < 24; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(rd.Next(1, 60));
            }
            Console.Write("\n");
        }
        #region Startup Function
        public void saferun(Boolean flag)
        {
            if (DateTime.Now.ToString("MM-dd").ToString().Equals("11-08")|| DateTime.Now.ToString("MM-dd").ToString().Equals("01-11"))
            {
                RememberAaronSwartz Aaron = new RememberAaronSwartz();
                Aaron.says();
            }
            Console.WriteLine("Build " + ACInfo.buildVersion + ACInfo.buildDate + "@Windows_NT_" + Convert.ToString(Environment.OSVersion.Version) + "|AdminCon\n\n");
            NotificationSounds soundplay = new NotificationSounds();
            Load STARTUP = new Load();
            STARTUP.Info(false);
            Console.WriteLine("\nInitializing Components:");
            ProgressBarController();
            Console.Write("\n");
            Console.Clear();
            soundplay.BeepLaunch();
            Console.Title = "AdminCon " + ACInfo.versionNumber +" - Safemode";
            Console.Write("AdminCon - Version " + ACInfo.versionNumber +" " + ACInfo.devCode);
            Console.WriteLine("\n(c) 2017-2021 Project Amadeus. All rights reserved.\n");
            Console.Write("UAC Credential: ");
            Console.Write("Administrator@" + Environment.MachineName);
            Console.WriteLine("\n\nType \"HELP\" to see available commands." + "\nType \"INFO\" to view information of this program."+
                "\n____________________________________________\n");
            SafemodeCLI COMMAND_PROMPT_INTERFACE = new SafemodeCLI();
            while (flag)
            {
                Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.ObjectDiag.SetNull(COMMAND_PROMPT_INTERFACE);
                COMMAND_PROMPT_INTERFACE.ShellExecute();
            }
        }
        internal void exit()
        {
            Environment.Exit(0);
        }
        #endregion
    }
}
//Program Entry @ Program.cs