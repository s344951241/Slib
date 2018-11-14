using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Search
{
    public class BinarySearch
    {
        private BinarySearch()
        {

        }
        public static int indexof(int[] a, int key)
        {
            int lo = 0;
            int hi = a.Length - 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (key < a[mid])
                {
                    hi = mid - 1;
                }
                else if (key > a[mid])
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

        public static int rand(int key, int[] a)
        {
            return indexof(a, key);
        }
    }


}
