using System;
using AdminCon_CLI_dotnetEdition.Modules.ACWatchDog.Components;
/* AdminCon 6.0 Command Line Interface Edition - Source Code - Program.cs
 * Intro: The class that launches program.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.ACWatchDog
{
    class Program
    {
        static void Main(String[] args) //Program entry
        {
            Console.Title = "Reading Data...";
            new DataBarGenerator();
        }
    }
}
