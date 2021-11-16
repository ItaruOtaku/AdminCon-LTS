using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* AdminCon 6.0 Command Line Interface Edition - Source Code - Program.cs
 * Intro: The class that launches program.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.DiskSpeedChecker
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.Title = "AdminCon - Disk Speed Checker";
            Console.WriteLine("AdminCon CLI Shell - DClock v1.0");
            Console.WriteLine("Copyright (c) 2022 Project Amadeus. All rights reserved.");
            for (; ; )
            {
                try
                {
                    Console.Write("\n\n\n\nac:dclock/cli>");
                    String command = Console.ReadLine();
                    if (command.ToUpper() == "EXIT")
                    {
                        break;
                    }
                    else if (command == "")
                    {
                        continue;
                    }
                    else if (command.ToUpper() == "START")
                    {
                        Console.WriteLine("The program will write some data on the disk to check the general speed.");
                        Console.Write("Would you like to give it a specific data size? Y/N: ");
                        String option = Console.ReadLine();
                        switch (option.ToUpper())
                        {
                            case "Y":
                                Console.Write("Size(MB):");
                                bool completedOrNot = int.TryParse(Console.ReadLine(), out int size);
                                if (!completedOrNot)
                                {
                                    throw new Exception("Illegal Parameter Given.");
                                }
                                if (size > 2000)
                                {
                                    throw new Exception("Size is Too Large.");
                                }
                                Console.WriteLine("Writing Objects...");
                                DiskWriter.Write(size);
                                Console.WriteLine("General disk I/O speed: " + (int)DiskWriter.generalDiskSpeed + "MB/sec.");
                                Console.Write("Finished. Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "N":
                                Console.WriteLine("Writing Objects...");
                                DiskWriter.Write(100);
                                Console.WriteLine("General disk I/O speed: " + (int)DiskWriter.generalDiskSpeed + "MB/sec.");
                                Console.Write("Finished. Press any key to continue.");
                                Console.ReadKey();
                                break;
                            default:
                                Console.Write("Invalid Option.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Type \"START\" to start testing, \"EXIT\" to exit.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
