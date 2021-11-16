/* AdminCon 7.0 Command Line Interface Edition - Source Code - ACInfo.cs
* Intro: Information of version.
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
using System;
using System.Collections.Generic;

namespace AdminCon_CLI_dotnetEdition.Components.@Global
{
    public static class ACInfo
    {
        public static String versionNumber = "7.0";
        public static String buildVersion  = "7.0.0.1";
        public static String buildDate     = "<2021-10>";
        public static String devCode       = "Raiden Mei";
        public static String easterEggKey  = "lightning-empress!";
        public static String locationPath  = new ProgramLocationGenerator().Generate("AC.EXE",0);
        public static String locationPathWhenRunningScript = new ProgramLocationGenerator().Generate("AC.EXE",1); //Why do this?
        /*
         * Explain:
         * When launch ac.exe through a script(ex. test.acs), Encironment.CommandLine will be like:
         * [PATH]\ac.exe  + space +  [PATH2]\test.acs
         * So we need to split this string by space and get the first string in the array.
         * */
    }
    public class ProgramLocationGenerator
    {
        public String Generate(String programName, Int32 mode) //mode = 0: normal; mode = 1: script mode.
        {
            switch (mode)
            {
                case 0:
                    //Get the directory of ac.exe
                    String ac_workingdir = Environment.CommandLine.ToUpper().Replace("\"", null);//delete " " from start and end of string.
                    String ac_path = ac_workingdir.Replace(programName, null);
                    Char[] ac_pathInChars = ac_path.ToCharArray();
                    List<Char> ac_pathIncharList = new List<Char>(ac_pathInChars);
                    ac_pathIncharList.Remove(' '); //remove the blankspace at the end of array to concat.
                    ac_path = new String(ac_pathIncharList.ToArray());
                    return ac_path;
                case 1:
                    //Get the directory of ac.exe
                    String ac_workingdir_s = Environment.CommandLine.ToUpper().Replace("\"", null);//delete " " from start and end of string.
                    String[] acPathAndScriptPath = ac_workingdir_s.Split(' ');
                    String ac_path_s = acPathAndScriptPath[0].Replace(programName, null);
                    Char[] ac_pathInChars_s = ac_path_s.ToCharArray();
                    List<Char> ac_pathIncharList_s = new List<Char>(ac_pathInChars_s);
                    ac_pathIncharList_s.Remove(' '); //remove the blankspace at the end of array to concat.
                    ac_path = new String(ac_pathIncharList_s.ToArray());
                    ac_path = new String(ac_pathIncharList_s.ToArray());
                    return ac_path;
                default:
                    throw new Exception("No Such Option.");

            }

        }
    }
}
//Program Entry @ Program.cs