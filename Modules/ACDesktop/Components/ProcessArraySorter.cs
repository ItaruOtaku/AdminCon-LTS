using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - ProcessArraySorter.cs
 * Intro: Sorter classes of process.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.ACDesktop.Components
{
    class ProcessIDSorter: IComparer<Process>
    {
        public Int32 Compare(Process p1, Process p2)
        {
            return p1.Id.CompareTo(p2.Id);
        }
    }
    class ProcessMemoryUsageSorter : IComparer<Process>
    {
        public Int32 Compare(Process p1, Process p2)
        {
            return p1.WorkingSet64.CompareTo(p2.WorkingSet64);
        }
    }
}
//Program Entry @ Launcher.cs