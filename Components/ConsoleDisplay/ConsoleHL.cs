using System;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - ConsoleHL.cs
 * Intro: Highlight the console output stream.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay
{
    /// <summary>
    /// Highlighted console output plug-ins
    /// </summary> 
    public static class ConsoleHL
    {
        private static void HighLightedWriteLine(Object OutputObject, ConsoleColor OutputObject_COLOR)//ConsoleColor: enum
        {
            if (OutputObject.ToString() == "" || OutputObject == null)
            {
                throw new Exception("Illegal Parameter is Given.");
            }
            ConsoleColor CURRENT_FOREGROUND_COLOR = Console.ForegroundColor;
            Console.ForegroundColor = OutputObject_COLOR; //Set foreground color
            Console.WriteLine(OutputObject.ToString()); //PrInt32 ciolored OutputObject
            Console.ForegroundColor = CURRENT_FOREGROUND_COLOR; //Change the foreground color to original
        }
        private static void HighLightedWrite(Object OutputObject, ConsoleColor OutputObject_COLOR)
        {
            if (OutputObject.ToString() == "" || OutputObject == null)
            {
                throw new Exception("Illegal Parameter is Given.");
            }
            ConsoleColor CURRENT_FOREGROUND_COLOR = Console.ForegroundColor;
            Console.ForegroundColor = OutputObject_COLOR;
            Console.Write(OutputObject.ToString());
            Console.ForegroundColor = CURRENT_FOREGROUND_COLOR;
        }
        #region High-Lighted Console.WriteLine()
        /// <summary>
        /// ConsoleHL.WriteLine() with highlight plug-ins.
        /// Error(red), Help(gray), Info(cyan), Output(yellow), Prompt(dark cyan)
        /// </summary>
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WriteErrorLine(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.Red)
        {
            HighLightedWriteLine(OutputObject, OutputObject_COLOR);
        }
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WriteHelpLine(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.Gray)
        {
            HighLightedWriteLine(OutputObject, OutputObject_COLOR);
        }
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WriteInfoLine(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.Cyan)
        {
            HighLightedWriteLine(OutputObject, OutputObject_COLOR);
        }
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WriteOutputLine(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.Yellow)
        {
            HighLightedWriteLine(OutputObject, OutputObject_COLOR);
        }
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WritePromptLine(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.DarkCyan)
        {
            HighLightedWriteLine(OutputObject, OutputObject_COLOR);
        }
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WriteTitleLine(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.Green)
        {
            HighLightedWriteLine(OutputObject, OutputObject_COLOR);
        }
        #endregion
        #region High-Lighted Console.Write()
        /// <summary>
        /// ConsoleHL.Write() with highlight plug-ins.
        /// Error(red), Help(gray), Info(cyan), Output(yellow), Prompt(dark cyan)
        /// </summary>
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WriteError(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.Red)
        {
            HighLightedWrite(OutputObject, OutputObject_COLOR);
        }
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WriteHelp(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.Gray)
        {
            HighLightedWrite(OutputObject, OutputObject_COLOR);
        }
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WriteInfo(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.Cyan)
        {
            HighLightedWrite(OutputObject, OutputObject_COLOR);
        }
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WriteOutput(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.Yellow)
        {
            HighLightedWrite(OutputObject, OutputObject_COLOR);
        }
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WritePrompt(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.DarkCyan)
        {
            HighLightedWrite(OutputObject, OutputObject_COLOR);
        }
        /// <param name="OutputObject"></param>
        /// <param name="OutputObject_COLOR"></param>
        public static void WriteTitle(this Object OutputObject, ConsoleColor OutputObject_COLOR = ConsoleColor.Green)
        {
            HighLightedWrite(OutputObject, OutputObject_COLOR);
        }
        #endregion

        #region WriteSpaces
        public static void WriteSpaces(Int32 spacesCount)
        {
            for(Int32 i = 0; i < spacesCount; i++)
            {
                Console.Write(" ");
            }
        }
        #endregion
    }
}
//Program Entry @ Program.cs