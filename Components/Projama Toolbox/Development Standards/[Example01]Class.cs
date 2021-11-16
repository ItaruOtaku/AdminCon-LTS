
// (c) 2017-2021 Project Amadeus
using System;
/// <summary>
/// Development Standards No.0001 - Basic Standards.
/// </summary>
namespace Project_Amadeus.CSharp.DesktopDevelopment.Standards
{
    //This is an example of standard class definition.
    //The developers should accord to this standard when they define their own classes.

    /// <summary>
    /// Use "CamelCase" when defining a class or an interface.
    /// </summary>
    interface Interface //Define an interface first, then implement it.
    {
        Int32 Function(Int32 number);
    }
    class Class : Interface
    {
        /*****ATTENTION: Every function should have a <summary/> comment above it.*****/
        /*****ATTENTION: Fields must be private. Use constructor to set values to them.*****/

        private Int32 field; //Fields should be private.
        private const Int32 CONSTANT = 0; //Use "ALL_CAPS" when defining Constants.

        /// <summary>
        /// Constructor.
        /// </summary>
        public Class() //A default constructor should always be declared whether you use it or not.
        {
            // some code.
        }

        /// <summary>
        /// Setter.
        /// </summary>
        /// <param name="field"></param>
        public void SetField(Int32 field)
        {
            this.field = field;
        }

        /// <summary>
        /// Getter.
        /// </summary>
        /// <returns></returns>
        public Int32 GetField()
        {
            return this.field;
        }

        /// <summary>
        /// Method (also known as "function").
        /// Use "CamelCase" when defining a method.
        /// </summary>
        /// <returns></returns>
        public Int32 Function(Int32 number /*Use understandable words when defining Arguments.*/)
        {
            Int32 returnValue = number; //Use "camelCase" when defining local variables.
            return returnValue;
        }
    }
}
