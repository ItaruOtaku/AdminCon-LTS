using System;
using System.Collections.Generic;

namespace AdminCon_CLI_dotnetEdition.Modules.DiskSpeedChecker
{
    internal class ProgramLocationGenerator
    {
        public String Generate(String programName) //mode = 0: normal; mode = 1: script mode.
        {
            //Get the directory of ac.exe
            String ac_workingdir = Environment.CommandLine.ToUpper().Replace("\"", null);//delete " " from start and end of String.
            String ac_path = ac_workingdir.Replace(programName, null);
            Char[] ac_pathInChars = ac_path.ToCharArray();
            List<Char> ac_pathInCharList = new List<Char>(ac_pathInChars);
            ac_pathInCharList.Remove(' '); //remove the blankspace at the end of array to concat.
            ac_path = new String(ac_pathInCharList.ToArray());
            return ac_path;
        }
    }
}