using AdminCon_CLI_dotnetEdition.Components.@Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
#pragma warning disable nullable
/* AdminCon 7.0 Command Line Interface Edition - Source Code - ToolRegist.cs
 * Intro: Read configurations.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Configuration
{
    /// <summary>
    /// File Location: {INSTALLATION_PATH}\config\toolregist.acfg
    /// Explain: The users can put their own executable under "tools" folder and
    /// register it in toolregist.acfg; the registration info should be written in
    /// "k,v" format. Key: filename; Value: Command.
    /// If a "command" of a filename is defined, the users will be able to type this
    /// command to launch the corresponding executable.
    /// 
    /// file format: {program-filename,command}
    /// </summary>
    class ToolRegist
    {
        public ToolRegist()
        {

        }
        private String TOOLREG_FILE_PATH = ACInfo.locationPath + "config\\toolregist.acfg";
        private String TOOLREG_FILE_PATH_FOR_SCRIPT = ACInfo.locationPathWhenRunningScript + "config\\toolregist.acfg";

        /// <summary>
        /// Store Program Filename and Reference Command inside a Dictionary
        /// </summary>
        /// <returns>Key(Program Filename) and Values(Reference Command)</returns>
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
                         * {program-filename,command}
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
                         * {program-filename,command}
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
        /// Check if a Program is Registered in the toolregist.acfg
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
        /// Get the Program Filename if a Reference Command Exists.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Program Filename</returns>
        public String GetProgramFileName(String command, Int32 mode)
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