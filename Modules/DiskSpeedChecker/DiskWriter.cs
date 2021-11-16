using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
/* AdminCon 6.0 Command Line Interface Edition - Source Code - DiskWriter.cs
 * Intro: Write bytes to disk to check general disk speed.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.DiskSpeedChecker
{
    internal class DiskWriter
    {
        private static ProgramLocationGenerator pathGenerator = new ProgramLocationGenerator();
        public static float generalDiskSpeed = 0;

        /// <summary>
        /// Write bytes to disk.
        /// </summary>
        /// <param name="size"></param>
        internal static void Write(int size/*MB*/)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int sizeInByte = size * 1024 * 1024;
            List<List<Char>> bufferList = CharPool.Generate(sizeInByte / 8);
            FileStream fileStream = new FileStream(pathGenerator.Generate("DCLOCK.EXE")+"data.data",FileMode.Create, FileAccess.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            lock(new Object())
            {
                foreach (List<Char> buffer in bufferList)
                {
                    streamWriter.Write(buffer.ToArray());
                }
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000);
            generalDiskSpeed = size/((stopwatch.ElapsedMilliseconds / 1000));
        }
    }

    /// <summary>
    /// The class that inits all characters.
    /// </summary>
    internal static class CharPool
    {
        private static String allChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
        private static int bufferSize = 8; //byte

        /// <summary>
        /// Generate Char buffers. (Char[8])
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<List<Char>> Generate(int count)
        {
            Char[] charArray = allChars.ToCharArray();
            List<Char> buffer = new List<Char>();
            List<List<Char>> bufferList = new List<List<Char>>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                for(int j = 0; j < bufferSize; j++)
                {
                    buffer.Add(charArray[random.Next(0,charArray.Length-1)]);
                }
                bufferList.Add(buffer);
                buffer.Clear();
            }
            return bufferList;
        }
    }

}