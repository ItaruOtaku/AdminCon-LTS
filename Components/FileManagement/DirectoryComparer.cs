using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - DirectoryComparer.cs
 * Intro: Compare 2 different directories.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.FileManagement
{
    interface DirectoryComparer
    {
        /// <summary>
        /// Compares files from 2 dirs. Returns full result.
        /// </summary>
        /// <returns>result</returns>
        List<String> CompareAll(String path1, String path2);

        /// <summary>
        /// Compare files between 2 directories by their names.
        /// </summary>
        /// <returns>result</returns>
        List<String> CompareFilesByNames(String path1, String path2);

        /// <summary>
        /// Compare files between 2 directories by size(KB/MB).
        /// </summary>
        /// <returns>result</returns>
        List<String> CompareFilesBySize(String path1, String path2);
    }
}
