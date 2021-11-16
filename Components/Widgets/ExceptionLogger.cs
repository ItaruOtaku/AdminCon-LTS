using System;
using System.Collections.Generic;
using System.Text;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - ExceptionLogger.cs
* Intro: Create log of exceptions.
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Widgets
{
    class ExceptionLogger : IDisposable
    {
        public Dictionary<Exception, DateTime> exceptionsTrace = new Dictionary<Exception, DateTime>();

        /// <summary>
        /// Add a catched exception instance and its creation time.
        /// </summary>
        /// <param name="ex">Exception Instance</param>
        public void Add(Exception ex)
        {
            this.exceptionsTrace.Add(ex, DateTime.Now);
            if (this.exceptionsTrace.Count > 1e3) this.exceptionsTrace.Clear();
        }
 
        /// <summary>
        /// Override: ToString(out Int32)
        /// </summary>
        /// <param name="exceptionCount">How many exception instances are currently in queue</param>
        /// <returns>Log message</returns>
        public String ToString(out Int32 exceptionCount)
        {
            StringBuilder StringBuilder = new StringBuilder();
            foreach(KeyValuePair<Exception, DateTime> kv in this.exceptionsTrace)
            {
                StringBuilder.Append(kv.Value.ToString() + "\n" + kv.Key.Message + "\n" + kv.Key.StackTrace+ "\n\n");
            }
            exceptionCount = this.exceptionsTrace.Count;
            return StringBuilder.ToString();
        }

        /// <summary>
        /// Override: Dispose()
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
//Program Entry @ Program.cs