using System;
using System.Diagnostics;

namespace AdminCon_CLI_dotnetEdition.Components.Processes
{
    class pKiller
    {
        private static Process p;
        private static Process[] pArray;
        #region Contructors
        public pKiller()
        {
            throw new Exception("No Arguments.");
        }
        public pKiller(Process p)
        {
            p.Kill();
        }
        public pKiller(String name)
        {
            Process[] pArray = Process.GetProcessesByName(name);
            foreach (Process p in pArray)
            {
                p.Kill();
            }
        }
        public pKiller(Int32 id)
        {
            Process p = Process.GetProcessById(id);
            p.Kill();
        }
        public pKiller(Process[] pArray)
        {
            for (Int32 movR = 0; movR < pArray.Length - 1; movR++)
            {
                for (Int32 movL = pArray.Length; movL > pArray.Length - 1 - movR; movL--)
                {
                    if (pArray[movL].WorkingSet64 < pArray[movL + 1].WorkingSet64)
                    {
                        Process temp = pArray[movL + 1];
                        pArray[movL + 1] = pArray[movL];
                        pArray[movL] = temp;
                    }
                }
            }
            foreach (Process p in pArray)
            {
                p.Kill();
            }
        }
        public pKiller(Int32[] pidArray)
        {
            foreach (Int32 i in pidArray)
            {
                p = Process.GetProcessById(i);
                p.Kill();
            }
        }
        public pKiller(String[] pnameArray)
        {
            foreach (String s in pnameArray)
            {
                pArray = Process.GetProcessesByName(s);
                foreach (Process p in pArray)
                {
                    p.Kill();
                }
            }
        }
        #endregion

        #region Deconstructors
        ~pKiller()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
