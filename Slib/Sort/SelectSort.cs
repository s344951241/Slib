using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Sort
{
    public class SelectSort<T> where T:IComparable
    {
        public static void sort(IList<T> iter)
        {
            for (int i = 0; i < iter.Count-1; i++)
            {
                int min = i;
                for (int j = i + 1; j < iter.Count; j++)
                {
                    if (iter[min].CompareTo(iter[j]) > 0)
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    iter.Swap(min, i);
                }
            }
        }
    }
}
