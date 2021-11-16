using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
/* AdminCon 6.0 Command Line Interface Edition - Source Code - DataBarGenerator.cs
 * Intro: Create and format resource databars.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.ACWatchDog.Components
{
    class DataBarGenerator
    {
        //field
        private Daemon daemon = Daemon.GetInstance();

        //constant
        private const String ruler = "___________________________________________________________________________________________________|100%";
        public DataBarGenerator()
        {
            Console.Title = "AdminCon - WatchDog";
            while (true)
            {
                Console.WriteLine("CPU Usage:\n");
                ConsoleHL.WriteCyanLine(this.Generate(daemon.cpu_Usage));
                ConsoleHL.WriteGreenLine(ruler);
                Console.WriteLine("\n\n\n");
                Console.WriteLine("RAM Usage:\n");
                ConsoleHL.WriteCyanLine(this.Generate((int)(daemon.mem_Usage_Ratio*100), daemon.mem_Usage, "MB"));
                ConsoleHL.WriteGreen(ruler);
                Thread.Sleep(800);
                Console.Clear();
            }
        }

        /// <summary>
        /// Generate a output String for resource value with unit.
        /// </summary>
        /// <param name="ratio"></param>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        /// <returns>Output String</returns>
        private String Generate(int ratio, Double value, String unit)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(PrintBlocks(ratio)+"  "+ratio+"%"+"/"+value+unit);
            return stringBuilder.ToString();
        }

        //override
        /// <summary>
        /// Generate a output String for resource value without unit.
        /// </summary>
        /// <param name="ratio"></param>
        /// <returns>Output String</returns>
        private String Generate(int ratio)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(PrintBlocks(ratio) + "  " + ratio + "%");
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Print some blocks as databar.
        /// </summary>
        /// <param name="blocks"></param>
        /// <returns>Databar</returns>
        private String PrintBlocks(int blocks)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < blocks; i++)
            {
                stringBuilder.Append('█');
            }
            return stringBuilder.ToString();
        }
    }
}
