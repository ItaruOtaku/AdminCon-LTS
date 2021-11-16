using AdminCon_CLI_dotnetEdition.Components.@Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
#pragma warning disable nullable
/* AdminCon 7.0 Command Line Interface Edition - Source Code - ProcessRef.cs
 * Intro: Read configurations.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Configuration
{
    /// <summary>
    /// File Location: {INSTALLATION_PATH}\config\pReference.acfg
    /// Explain: We've also provided a way to deal with processes with
    /// complicated process name. You can now register a process in
    /// pReference.acfg, which allows you to give processes different
    /// reference codes.
    /// For example: {myProcessWithComplicatedName,myprocess}
    /// To kill this process, you can simply type "kill /s myprocess"
    /// instead of "kill /s myProcessWithComplicatedName".
    /// 
    /// The process name and its refcode should be written in "k,v" format.
    /// 
    /// file format: {process-name,ref-code}
    /// </summary>
    class ProcessRef
    {
        public ProcessRef()
        {

        }
        private String TOOLREG_FILE_PATH = ACInfo.locationPath + "config\\pReference.acfg";
        private String TOOLREG_FILE_PATH_FOR_SCRIPT = ACInfo.locationPathWhenRunningScript + "config\\pReference.acfg";

        /// <summary>
        /// Store Process name and Reference code inside a Dictionary
        /// </summary>
        /// <returns>Key(Process name) and Values(Reference Code)</returns>
        public Dictionary<String, String> Get(Int32 mode) //mode = 0: normal; mode = 1: script mode.
        {
            switch (mode)
            {
                case 0:
                    Dictionary<String, String> keyval = new Dictionary<String, String>();
                    FileStream fs = new FileStream(TOOLREG_FILE_PATH, FileMode.Open, FileAccess.Read);
                    StreamReader read = new StreamReader(fs, Encoding.Default);
                    String strReadline;
                    while ((strReadline = read.ReadLine()) != null)
                    {
                        /* Tool registry file format:
                         * {process-name,ref-code}
                         * Example: {acwin32.exe,acw32}, no space.
                         */
                        if (strReadline.StartsWith("{"))
                        {
                            strReadline = strReadline.TrimStart('{').TrimEnd('}');
                            keyval.Add(strReadline.Split(',')[0], strReadline.Split(',')[1]);
                        }
                    }
                    return keyval;
                case 1:
                    Dictionary<String, String> keyval_s = new Dictionary<String, String>();
                    FileStream fs_s = new FileStream(TOOLREG_FILE_PATH_FOR_SCRIPT, FileMode.Open, FileAccess.Read);
                    StreamReader read_s = new StreamReader(fs_s, Encoding.Default);
                    String strReadline_s;
                    while ((strReadline_s = read_s.ReadLine()) != null)
                    {
                        /* Tool registry file format:
                         * {process-name,ref-code}
                         * Example: {acwin32.exe,acw32}, no space.
                         */
                        if (strReadline_s.StartsWith("{"))
                        {
                            strReadline_s = strReadline_s.TrimStart('{').TrimEnd('}');
                            keyval_s.Add(strReadline_s.Split(',')[0], strReadline_s.Split(',')[1]);
                        }
                    }
                    return keyval_s;
                default:
                    throw new Exception("No Such Option.");
            }
        }

        /// <summary>
        /// Check if a Process is Registered in the pReference.acfg
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Yes/No</returns>
        public Boolean CheckIfRegistered(String command, Int32 mode)
        {
            switch (mode)
            {
                case 0:
                    foreach (KeyValuePair<String, String> pair in Get(0))
                    {
                        if (pair.Value.ToUpper() == command.ToUpper())
                        {
                            return true;
                        }
                    }
                    return false;
                case 1:
                    foreach (KeyValuePair<String, String> pair in Get(1))
                    {
                        if (pair.Value.ToUpper() == command.ToUpper())
                        {
                            return true;
                        }
                    }
                    return false;
                default:
                    throw new Exception("No Such Option.");
            }
        }

        /// <summary>
        /// Get the Process if a Reference Code Exists.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Program Filename</returns>
        public String GetProcessName(String command, Int32 mode)
        {
            switch (mode)
            {
                case 0:
                    foreach (KeyValuePair<String, String> pair in Get(0))
                    {
                        if (pair.Value.ToUpper() == command.ToUpper())
                        {
                            return pair.Key;
                        }
                    }
                    return "";
                case 1:
                    foreach (KeyValuePair<String, String> pair in Get(1))
                    {
                        if (pair.Value.ToUpper() == command.ToUpper())
                        {
                            return pair.Key;
                        }
                    }
                    return "";
                default:
                    throw new Exception("No Such Option.");
            }
        }
    }
}
//Program Entry @ Program.cs