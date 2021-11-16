using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - grammarAnalyzer.cs
* Intro: Split the input Int32o "command", "keyword" and "Arguments".
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Command
{
    /// <summary>
    /// Initialize command, argument, and field from a single input stream.
    /// </summary>
    class GrammarAnalyzer
    {
        /// <summary>
        /// Ignore extra spaces in the input.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>String[]</returns>
        private String[] RegexSplit_CaseIgnored(String str)
        {
            Regex replaceSpace = new Regex(@"\s{1,}", RegexOptions.IgnoreCase); //Filter

            //SPACE REPLACEMENT
            //Replace multiple spaces between arg, field and command Int32o only one space input.
            String[] ret =  replaceSpace.Replace(str, " ").Trim().Split(' ');
            List<String> list = new List<String>(ret);
            if(list[0] == " ") //If the input starts with a space(after spaces replacement), remove it.
            {
                list.Remove(ret[0]);
            }
            return list.ToArray();
        }
        public String getArgument(String statement)
        {    
            try
            {
                String[] sArray = RegexSplit_CaseIgnored(statement);
                return sArray[2];
            }
            catch(Exception){} 
            return null;
        }
        public String getField(String statement)
        {       
            try
            {
                String[] sArray = RegexSplit_CaseIgnored(statement);
                return sArray[1];
            }
            catch (Exception){}
            return null;
        }
        public String getCommand(String statement)
        {
            try
            {
                String[] sArray = RegexSplit_CaseIgnored(statement);
                return sArray[0];
            }
            catch (Exception){}
            return null;
        }
        public String fix(String statement)
        {
            Regex replaceSpace = new Regex(@"\s{1,}", RegexOptions.IgnoreCase); //Filter

            //SPACE REPLACEMENT
            //Replace multiple spaces between arg, field and command Int32o only one space input.
            List<Char> charList = new List<Char>(replaceSpace.Replace(statement, " ").Trim().ToCharArray());
            if(statement == "")
            {
                return "";
            }
            if (charList[0] == ' ')
            {
                charList.Remove(charList[0]);
            }
            return new String(charList.ToArray());
        }
    }
}
//Program Entry @ Program.cs
