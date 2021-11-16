using AdminCon_CLI_dotnetEdition.Components.@Global;
using System;
using System.Diagnostics;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - BinaryToHexDisplay.cs
* Intro: Read a binary file as stream and output hex map.
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.FileManagement
{
    /// <summary>
    /// Binary Viewer
    /// </summary>
    class BinaryToHexDisplay
    {
        private String filepath;
        /// <summary>
        /// .ctor()
        /// </summary>
        /// <param name="path"></param>
        public BinaryToHexDisplay(String path)
        {
            this.filepath = path;
        }

        /// <summary>
        /// .ctor() no args
        /// </summary>
        public BinaryToHexDisplay()
        {
            throw new Exception("File Path Required.");
        }

        public void RunHexProgram(Int32 mode)
        {
            switch (mode)
            {
                case 0:
                    Process p = new Process();
                    ProcessStartInfo pInfo = new ProcessStartInfo(ACInfo.locationPath + "\\tools\\HEXVIEWER.EXE", filepath);
                    p.StartInfo = pInfo;
                    p.Start();
                    break;
                case 1:
                    Process p2 = new Process();
                    ProcessStartInfo pInfo2 = new ProcessStartInfo(ACInfo.locationPathWhenRunningScript + "\\tools\\HEXVIEWER.EXE", filepath);
                    p2.StartInfo = pInfo2;
                    p2.Start();
                    break;
                default:
                    throw new Exception("No Such Option.");
            }
        }
    }
}
//Program Entry @ Program.cs