using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Sort
{
    public class MergeSort<T> where T:IComparable
    {
        public static void sort(IList<T> iter)
        {

            IList<T> temp = new List<T>(iter);
            mergeSort(iter, 0, iter.Count-1, temp);
        }

        private static void mergeSort(IList<T> iter, int left, int right, IList<T> temp)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                mergeSort(iter, left, mid, temp);
                mergeSort(iter, mid + 1, right, temp);
                merge(iter, left, mid, right, temp);
            }
        }
        private static void merge(IList<T> iter, int left, int mid, int right, IList<T> temp)
        {
            int i = left;
            int j = mid + 1;
            int t = 0;
            while (i <= mid && j <= right)
            {
                if (iter[i].CompareTo(iter[j]) <= 0)
                {
                    temp[t] = iter[i];
                    i += 1;
                    t += 1;
                }
                else
                {
                    temp[t] = iter[j];
                    j += 1;
                    t += 1;
                }

            }
            while (i <= mid)
            {
                temp[t] = iter[i];
                t += 1;
                i += 1;
            }
            while (j <= mid)
            {
                temp[t] = iter[j];
                t += 1;
                j += 1;
            }
            t = 0;
            while (left <= right)
            {
                iter[left] = temp[t];
                left += 1;
                t += 1;
            }
        }
    }
}
