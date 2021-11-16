using AdminCon_CLI_dotnetEdition.Components.@Global;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
#pragma warning disable nullable
/* AdminCon 7.0 Command Line Interface Edition - Source Code - Config.cs
 * Intro: Read and write configuration to a file.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Configuration
{
    class Config
    {
        private String CONFIG_FILE_PATH = ACInfo.locationPath+"config\\settings.acfg";

        /// <summary>
        /// Store Keys and Values as String array
        /// </summary>
        /// <returns>Kays and Values in String[]</returns>
        public String[] Get()
        {
            String[] argsAndValues = { };
            FileStream fs = new FileStream(CONFIG_FILE_PATH, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(fs, Encoding.Default);
            String strReadline; Int32 count = 0;
            while ((strReadline = read.ReadLine()) != null)
            {
                argsAndValues[count] = strReadline;
                count++;
            }
            return argsAndValues;
        }

        /// <summary>
        /// Write Keys and Values to settings.acfg
        /// </summary>
        /// <param name="k"></param>
        /// <param name="v"></param>
        /// <returns>Status code(0,-1).</returns>
        public Int32 Set(String k, String v)
        {
            //Set properties
            if (k.Equals("") || k.Equals(null) || v.Equals("") || v.Equals(null))
            {
                throw new Exception("Field Not Provided.");
            }
            FileStream fs = new FileStream(CONFIG_FILE_PATH, FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            String propertyField = k + "=" + v;
            try
            {
                sw.WriteLine(propertyField);
                return 0;
            } catch (Exception)
            {
                return -1;
            }
        }
        public void WrongStatementHandler(String cmd, Int32 startEntry, Boolean valid)
        {
            if (valid)
            {
                cmd = cmd.Remove(cmd.ToCharArray()[startEntry]);
            }
        }
    }
}
//Program Entry @ Program.cs