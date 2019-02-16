using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Sort
{
    public class BubbleSort<T> where T:IComparable
    {
        public static void sort(IList<T> iter)
        {
            for (int i = 0; i < iter.Count-1; i++)
            {
                for (int j = 0; j < iter.Count-1 - i; j++)
                {
                    if (iter[j].CompareTo(iter[j + 1]) > 0)
                    {
                        iter.Swap(j, j + 1);
                    }
                }
            }
        }
    }
}
