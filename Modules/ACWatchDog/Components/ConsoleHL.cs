using System;
/* AdminCon 6.0 Command Line Interface Edition - Source Code - ConsoleHL.cs
 * Intro: Highlight the console Yellow stream.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.ACWatchDog.Components
{
    /// <summary>
    /// Highlighted console Yellow plug-ins
    /// </summary> 
    public static class ConsoleHL
    {
        private static void HighLightedWriteLine(object YellowObject, ConsoleColor YellowObject_COLOR)//ConsoleColor: enum
        {
            if (YellowObject.ToString() == "" || YellowObject == null)
            {
                throw new Exception("Illegal Parameter is Given.");
            }
            ConsoleColor CURRENT_FOREGROUND_COLOR = Console.ForegroundColor;
            Console.ForegroundColor = YellowObject_COLOR; //Set foreground color
            Console.WriteLine(YellowObject.ToString()); //Print ciolored YellowObject
            Console.ForegroundColor = CURRENT_FOREGROUND_COLOR; //Change the foreground color to original
        }
        private static void HighLightedWrite(object YellowObject, ConsoleColor YellowObject_COLOR)
        {
            if (YellowObject.ToString() == "" || YellowObject == null)
            {
                throw new Exception("Illegal Parameter is Given.");
            }
            ConsoleColor CURRENT_FOREGROUND_COLOR = Console.ForegroundColor;
            Console.ForegroundColor = YellowObject_COLOR;
            Console.Write(YellowObject.ToString());
            Console.ForegroundColor = CURRENT_FOREGROUND_COLOR;
        }
        #region High-Lighted Console.WriteLine()
        /// <summary>
        /// ConsoleHL.WriteLine() with highlight plug-ins.
        /// Red(red), Gray(gray), Cyan(cyan), Yellow(yellow), DarkCyan(dark cyan)
        /// </summary>
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteRedLine(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.Red)
        {
            HighLightedWriteLine(YellowObject, YellowObject_COLOR);
        }
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteGrayLine(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.Gray)
        {
            HighLightedWriteLine(YellowObject, YellowObject_COLOR);
        }
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteCyanLine(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.Cyan)
        {
            HighLightedWriteLine(YellowObject, YellowObject_COLOR);
        }
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteYellowLine(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.Yellow)
        {
            HighLightedWriteLine(YellowObject, YellowObject_COLOR);
        }
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteDarkCyanLine(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.DarkCyan)
        {
            HighLightedWriteLine(YellowObject, YellowObject_COLOR);
        }
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteGreenLine(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.Green)
        {
            HighLightedWriteLine(YellowObject, YellowObject_COLOR);
        }
        #endregion
        #region High-Lighted Console.Write()
        /// <summary>
        /// ConsoleHL.Write() with highlight plug-ins.
        /// Red(red), Gray(gray), Cyan(cyan), Yellow(yellow), DarkCyan(dark cyan)
        /// </summary>
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteRed(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.Red)
        {
            HighLightedWrite(YellowObject, YellowObject_COLOR);
        }
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteGray(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.Gray)
        {
            HighLightedWrite(YellowObject, YellowObject_COLOR);
        }
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteCyan(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.Cyan)
        {
            HighLightedWrite(YellowObject, YellowObject_COLOR);
        }
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteYellow(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.Yellow)
        {
            HighLightedWrite(YellowObject, YellowObject_COLOR);
        }
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteDarkCyan(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.DarkCyan)
        {
            HighLightedWrite(YellowObject, YellowObject_COLOR);
        }
        /// <param name="YellowObject"></param>
        /// <param name="YellowObject_COLOR"></param>
        public static void WriteGreen(this object YellowObject, ConsoleColor YellowObject_COLOR = ConsoleColor.Green)
        {
            HighLightedWrite(YellowObject, YellowObject_COLOR);
        }
        #endregion

        #region WriteSpaces
        public static void WriteSpaces(int spacesCount)
        {
            for(int i = 0; i < spacesCount; i++)
            {
                Console.Write(" ");
            }
        }
        #endregion
    }
}
