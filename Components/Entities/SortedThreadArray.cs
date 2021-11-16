using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - SortedThreadArray.cs
 * Intro: Customized data structure: Sorted thread list
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Entities
{
    /// <summary>
    /// IComparer - Comparable Object
    /// </summary>
    class SortThread :IComparer<Thread>
    {
        public Int32 Compare(Thread t1, Thread t2)
        {
            return t1.ManagedThreadId.CompareTo(t2.ManagedThreadId);
        }
    }

    class SortedThreadArray : List<Thread>
    {
        public SortedThreadArray()
        {
            this.Sort(new SortThread());
        }
        public SortedThreadArray(Int32 maxlen)
        {
            if (this.GetLength() > maxlen)
            {
                throw new Exception("List Length Out Of Range.");
            }
            this.Sort(new SortThread());
        }
        public SortedThreadArray(Int32 minlen, Int32 maxlen)
        {
            if (this.GetLength() > maxlen || this.GetLength() < minlen)
            {
                throw new Exception("List Length Out Of Range.");
            }
            this.Sort(new SortThread());
        }
        public Int32 GetLength()
        {
            Int32 count = 0;
            foreach (Thread t in this)
            {
                count++;
            }
            return count;
        }
        public override String ToString()
        {
            return base.ToString();
        }
    }
}
//Program Entry @ Program.cs