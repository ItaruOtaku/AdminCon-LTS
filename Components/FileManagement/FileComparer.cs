using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
/* AdminCon 4.0 Command Line Interface Edition - Source Code - FileComparer.cs
 * Intro: Compare 2 different files.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.FileManagement
{
    interface FileComparer
    {
        /// <summary>
        /// Compares 2 files and returns full result.
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns>result</returns>
        List<String> CompareAll(File f1, File f2);

        /// <summary>
        /// Compares 2 files by size.
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns>result</returns>
        List<String> CompareBySize(File f1, File f2);

        /// <summary>
        /// Compares 2 files by contents.
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns>result</returns>
        List<String> CompareByBytes(File f1, File f2);
    }
}
