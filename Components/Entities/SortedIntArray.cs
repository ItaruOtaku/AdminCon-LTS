using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - SortedIntArray.cs
 * Intro: Customized data structure: Sorted Int32 list
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Entities
{
    /// <summary>
    /// IComparer - Comparable Object
    /// </summary>
    class SortInt : IComparer<Int32>
    {
        public Int32 Compare(Int32 a, Int32 b)
        {
            return a.CompareTo(b);
        }
    }
    class SortedIntArray : List<Int32>
    {
        public SortedIntArray()
        {
            this.Sort(new SortInt()); //Sort after construction
        }
        public SortedIntArray(Int32 maxlen)
        {
            if (this.GetLength() > maxlen)
            {
                throw new Exception("List Length Out Of Range.");
            }
            this.Sort(new SortInt());
        }
        public SortedIntArray(Int32 minlen, Int32 maxlen)
        {
            if (this.GetLength() > maxlen || this.GetLength() < minlen)
            {
                throw new Exception("List Length Out Of Range.");
            }
            this.Sort(new SortInt());
        }
        public Int32 GetLength()
        {
            Int32 count = 0;
            foreach (Int32 i in this)
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