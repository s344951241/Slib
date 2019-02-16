using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib
{
    public static class Extension
    {
        public static void Swap<T>(this IList<T> iter, int a, int b)
        {
            if (iter.Count > a && iter.Count > b)
            {
                T t = iter[a];
                iter[a] = iter[b];
                iter[b] = t;
            }
        }
        public static string Print<T>(this IList<T> iter)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < iter.Count; i++)
            {
                sb.Append("|").Append(iter[i].ToString());
            }
            return sb.ToString();
        }
    }
}
