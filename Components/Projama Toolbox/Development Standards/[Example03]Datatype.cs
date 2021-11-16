using System;
using System.Collections.Generic;
/// <summary>
/// Development Standards No.0003 - Define Your Own Datatype.
/// </summary>

// (c) 2017-2021 Project Amadeus
namespace Project_Amadeus.CSharp.DesktopDevelopment.Standards
{

    //This is an example of datatype definition.
    //The developers should accord to this standard when they define their own datatypes.

    //Define a comparer (Optional).
    class SortDatatype : IComparer<Object>// Sort + Classname, implements Icomparer<T>.
    {
        /*****ATTENTION: Every function should have a <summary/> comment above it.*****/

        /// <summary>
        /// Implement Compare() method.
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <returns></returns>
        public Int32 Compare(Object o1, Object o2)
        {
            return 0; // o1.field.CompareTo(o2.field)
        }
    }

    //Main class.
    class Datatype : List<Object> //or hashmap, etc
    {

        //1. Constructor with no params
        /// <summary>
        /// Constructor.
        /// </summary>
        public Datatype()
        {
            this.Sort(new SortDatatype()); //Optional
        }

        //2. Constructor with size restriction.
        /// <summary>
        /// Constructor with maximum length restriction.
        /// </summary>
        /// <param name="maxlen"></param>
        public Datatype(Int32 maxlen)
        {
            if (this.GetLength() > maxlen)
            {
                throw new Exception("List Length Out Of Range.");
            }
            this.Sort(new SortDatatype()); //Optional
        }

        /// <summary>
        /// Constructor with maximum and minimum length restriction.
        /// </summary>
        /// <param name="minlen"></param>
        /// <param name="maxlen"></param>
        public Datatype(Int32 minlen, Int32 maxlen)
        {
            if (this.GetLength() > maxlen || this.GetLength() < minlen)
            {
                throw new Exception("List Length Out Of Range.");
            }
            this.Sort(new SortDatatype()); //Optional
        }

        //3. Create GetLength() method.
        /// <summary>
        /// Get length of this datatype.
        /// </summary>
        /// <returns></returns>
        public Int32 GetLength()
        {
            Int32 count = 0;
            foreach (Object o in this)
            {
                count++;
            }
            return count;
        }

        //4. Override ToString() method to make it more human-readable.
        /// <summary>
        /// Override ToString() method from base class.
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return base.ToString();
        }
    }
}
