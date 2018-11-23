using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Sort
{
    public class QuickSort<T> where T:IComparable
    {
        public static void sort(IList<T> iter)
        {
            quickSort(iter, 0, iter.Count - 1);    
        }

        private static void quickSort(IList<T> iter, int low, int high)
        {
            if (low >= high)
                return;
            int flag = partition(iter, low, high);//返回新的哨兵的位置
            quickSort(iter, low, flag - 1);
            quickSort(iter, flag + 1, high);
        }

        private static int partition(IList<T> iter, int low, int high)
        {
            int key = low;//哨兵的位置
            while (low < high)
            {
                while (low < high && iter[high].CompareTo(iter[key]) >= 0)//从右往左
                {
                    high--;
                }
                while (low < high && iter[low].CompareTo(iter[key]) <= 0)//从左往右
                {
                    low++;
                }
                iter.Swap(low, high);
            }
            iter.Swap(key, high);
            return high;
        }
    }
}
