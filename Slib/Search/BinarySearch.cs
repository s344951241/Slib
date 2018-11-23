using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Search
{
    public class BinarySearch<T> where T:IComparable
    {
        public static int Indexof(IList<T> a, int key)
        {
            int lo = 0;
            int hi = a.Count - 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (key.CompareTo(a[mid]) < 0)
                {
                    hi = mid - 1;
                }
                else if (key.CompareTo(a[mid]) > 0)
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }


}
