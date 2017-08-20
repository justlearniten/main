using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb
{
    public class Utils
    {
        /// <summary>
        /// Cleans the string by removing multiple spaces and trinmming
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CleanUp(string str)
        {
            string res = str.Trim();
            while (res.Contains("  "))
                res = res.Replace("  ", " ");
            return res;    
        }
    }
}
