using System;
using System.Threading;
/// <summary>
/// Development Standards No.0002 - Define an Entity.
/// </summary>

// (c) 2017-2021 Project Amadeus
namespace Project_Amadeus.CSharp.DesktopDevelopment.Standards
{
    //This is an example of Entity definition.
    //The developers should accord to this standard when they define their own entities.

    public interface StandardInterface //Define an interface first, then implement it.
    {
        Boolean Dispose();
        String ToString();
        void Pause(Int32 time);
    }
    class Entity : StandardInterface
    {
        /*****ATTENTION: Every function should have a <summary/> comment above it.*****/
        /*****ATTENTION: Fields must be private. Use constructor to set values to them.*****/

        /// <summary>
        /// Fields.
        /// </summary>
        private String CLASS_IDENTIFIER; //Must be private.

        /// <summary>
        /// The Standard Format of Class Identifier: Project Amadeus DevSTD
        /// ClassID = AccessModifier + ClassName + MemberCount, split with "-".
        /// Example: ClassID for class "public static class Administrator", with 6 members:
        /// pub-sta-Administrator-0006
        /// </summary>
        /// <param name="ClassID"></param>
        public Entity(String ClassID) //Setter.
        {
            this.CLASS_IDENTIFIER = ClassID;
        }

        /// <summary>
        /// Function: Constructor
        /// The developer must initialize the class id while creating Object. If didn't, throw an exception.
        /// </summary>
        public Entity()
        {
            throw new Exception("Can't Create Instance Until The Identifier Has Been Initialized.");
        }

        /// <summary>
        /// Getter method.
        /// </summary>
        /// <returns></returns>
        public String GetCLASS_IDENTIFIER() //Getter.
        {
            return this.CLASS_IDENTIFIER;
        }

        /// <summary>
        /// Function: Dispose
        /// The implementstion of method Dispose()
        /// </summary>
        /// <returns>Boolean</returns>
        public Boolean Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Function: ToString
        /// Override the ToString() method. ClassType + ClassID + HashCode
        /// </summary>
        /// <returns>String</returns>
        public override String ToString()
        {
            return
                this.GetType() + "<" + CLASS_IDENTIFIER + ">-hash: " + this.GetHashCode();
        }

        /// <summary>
        /// Function: Pause
        /// Pause the thread for a while.
        /// </summary>
        /// <param name="ms"></param>
        public void Pause(Int32 ms)
        {
            Thread.Sleep(ms);
        }
    }

    /// <summary>
    /// Standard Interface of Entity.
    /// </summary>
}
