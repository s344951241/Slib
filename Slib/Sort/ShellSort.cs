using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Sort
{
    public class ShellSort<T> where T:IComparable
    {
        public static void sort(IList<T> iter)
        {
            for (int gap = iter.Count / 2; gap > 0; gap = gap / 2)
            {
                for (int i = gap; i < iter.Count; i++)
                {
                    int j = i;
                    while (j - gap >= 0 && iter[j - gap].CompareTo(iter[j])>0)
                    {
                        iter.Swap(j, j - gap);
                        j = j - gap;
                    }
                }
            }
        }
        public static void sort2(IList<T> iter)
        {
            int increment = iter.Count;
            while (increment > 1)
            {
                increment = increment / 3 + 1;
                for (int i = 0; i < iter.Count; i++)
                {
                    T key = iter[i];
                    int j = i - increment;
                    while (j >= 0)
                    {
                        if (iter[j].CompareTo(key)>0)
                        {
                            iter.Swap(j, j + increment);
                        }
                        j = j - increment;
                    }
                }
            }
        }
    }
}
