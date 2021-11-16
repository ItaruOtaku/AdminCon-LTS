using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - SortedProcessArray.cs
 * Intro: Customized data structure: Sorted process list
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Entities
{
    class ProcessArray : List<Process>
    {
        public ProcessArray()
        {
            this.Sort(new Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.PIDComparer());
        }
        public ProcessArray(Int32 maxlen)
        {
            if(this.GetLength() > maxlen)
            {
                throw new Exception("List Length Out Of Range.");
            }
            this.Sort(new Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.PIDComparer());
        }
        public ProcessArray(Int32 minlen, Int32 maxlen)
        {
            if (this.GetLength() > maxlen || this.GetLength() < minlen)
            {
                throw new Exception("List Length Out Of Range.");
            }
            this.Sort(new Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.PIDComparer());
        }
        public override String ToString()
        {
            StringBuilder strbuild = new StringBuilder();
            Int32 count = -1;
            foreach (Process p in this)
            {
                count++;
                switch (p.Id.ToString().Length)
                {
                    case (1):
                        if (count > 8)
                        {
                            strbuild.Append("\n\n");
                            count = 0;
                        }
                        strbuild.Append(p.Id + "        ");
                        break;
                    case (2):
                        if (count > 8)
                        {
                            strbuild.Append("\n\n");
                            count = 0;
                        }
                        strbuild.Append(p.Id + "       ");
                        break;
                    case (3):
                        if (count > 8)
                        {
                            strbuild.Append("\n\n");
                            count = 0;
                        }
                        strbuild.Append(p.Id + "      ");
                        break;
                    case (4):
                        if (count > 8)
                        {
                            strbuild.Append("\n\n");
                            count = 0;
                        }
                        strbuild.Append(p.Id + "     ");
                        break;
                    case (5):
                        if (count > 8)
                        {
                            strbuild.Append("\n\n");
                            count = 0;
                        }
                        strbuild.Append(p.Id + "    ");
                        break;
                    case (6):
                        if (count > 8)
                        {
                            strbuild.Append("\n\n");
                            count = 0;
                        }
                        strbuild.Append(p.Id + "   ");
                        break;
                    case (7):
                        if (count > 8)
                        {
                            strbuild.Append("\n\n");
                            count = 0;
                        }
                        strbuild.Append(p.Id + "  ");
                        break;
                    default:
                        throw new Exception("Out Of Range.");
                }
            }
            return strbuild.ToString();
        }
        public Int32 Kill()
        {
            Int32 count = 0;
            foreach (Process p in this)
            {
                p.Kill();
                count++;
            }
            return count;
        }
        public Int32 GetLength()
        {
            Int32 count = 0;
            foreach (Process p in this)
            {
                count++;
            }
            return count;
        }
        public Int32[] getPIdList()
        {
            Int32[] pidArray = null;
            for (Int32 i = 0; i < this.GetLength(); i++)
            {
                pidArray[i] = this[i].Id;
            }
            return pidArray;
        }
    }
    public interface AbstractiveProcessReferences : IComparable<Process>
    {
        void Init();
        void Create();
        void Run();
        Boolean CheckDependencies();
        Int32 CheckDependenciesNumber();
        void SetHash();
        Int32 GetHash();
        Int32 InfoEncrypt();
    }
    public interface ObjectiveProcessReferences : AbstractiveProcessReferences { }

}
//Program Entry @ Program.cs