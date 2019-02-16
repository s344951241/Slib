using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Sort
{
    public class InsertSort<T> where T:IComparable
    {
        public static void sort(IList<T> iter)
        {
            for (int i = 0; i < iter.Count-1; i++)
            {
                int curret = i + 1;
                T value = iter[curret];
                for (int j = i; j >= 0; j--)
                {
                    if (iter[j].CompareTo(value) > 0)
                    {
                        iter[j+1] = iter[j];
                        curret = j;
                    }
                }
                iter[curret] = value;
                Console.WriteLine(iter.Print<T>());
            }
        }
    }
}
