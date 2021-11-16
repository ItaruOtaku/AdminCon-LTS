using System;
/* Project Amadeus - Windows Desktop Development SDK - ObjectDiag.cs
* Feature: Diagnose the objects.
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security
{
    public static class ObjectDiag
    {
        private static String GetName(Object obj)
        {
            return obj.ToString();
        }
        private static Int32 GetHash(Object obj)
        {
            return obj.GetHashCode();
        }
        /// <summary>
        /// Get Object info.
        /// <param name="obj"></param>
        /// </summary>
        public static String GetInfo(Object obj)
        {
            return GetName(obj)+": "+Convert.ToString(GetHash(obj));
        }
        /// <summary>
        /// Set Object to null.
        /// <param name="obj"></param>
        /// </summary>
        public static void SetNull(Object obj)
        {
            obj.Equals(null);
        }
    }
}
//Program Entry @ Program.cs