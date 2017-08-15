using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb
{
    public class DamerauLevenshtein
    {
        // https://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance
        public static int OSADistance(string a, string b)
        {
            int[,] d = new int[a.Length + 1, b.Length + 1];
            for (int i = 0; i <= a.Length; i++)
                d[i, 0] = i;
            for (int j = 0; j <= b.Length; j++)
                d[0, j] = j;
            for(int i = 1; i <= a.Length; i++)
            {
                for(int j = 1; j <= b.Length; j++)
                {
                    int cost = 1;
                    if (a[i - 1] == b[j - 1])
                        cost = 0;
                    d[i, j] = Math.Min(d[i - 1, j] + 1,         //deletion
                              Math.Min(d[i    , j - 1] + 1,     //insertion
                                       d[i - 1, j - 1] + cost));//substitution
                    if (i > 1 && j > 1 && a[i - 1] == b[j - 2] && a[i - 2] == b[j - 1])
                        d[i, j] = Math.Min(d[i, j],
                                           d[i - 2, j - 2] + cost);//transposition
                }
            }
            return d[a.Length, b.Length];
        }
    }
}
