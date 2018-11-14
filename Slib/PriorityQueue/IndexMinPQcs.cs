using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.PriorityQueue
{
    public class IndexMinPQ<T> : IEnumerable<int> where T:IComparable<T>
    {
        private int m_MaxN;     // maximum number of elements on PQ
        private int m_N;        // number of elements on PQ
        private int[] m_pq;     // binary heap using 1-based indexing
        private int[] m_qp;     // inverse of pq - qp[pq[i]] = pq[qp[i]] = i
        private T[] m_Keys;     // keys[i] = priority of i

        public IndexMinPQ(int maxN)
        {
            if (maxN < 0)
            {
                throw new ArgumentNullException();
            }
            m_MaxN = maxN;
            m_N = 0;
            m_Keys = new T[maxN+1];
            m_pq = new int[maxN + 1];
            m_qp = new int[maxN + 1];
            for (int i = 0; i <= maxN; i++)
            {
                m_qp[i] = -1;
            }
        }

        public bool isEmpty()
        {
            return m_N == 0;
        }

        public bool contains(int i)
        {
            if (i < 0 || i >= m_MaxN)
            {
                throw new IndexOutOfRangeException();
            }
            return m_qp[i] != -1;
        }
        public int size()
        {
            return m_N;
        }
        public void insert(int i, T key)
        {
            if (i < 0 || i > m_MaxN)
            {
                throw new IndexOutOfRangeException();
            }
            if (contains(i))
            {
                throw new ArgumentException("index is already in the priority queue");
            }
            m_N++;
            m_qp[i] = m_N;
            m_pq[m_N] = i;
            m_Keys[i] = key;
            swim(m_N);
        }
        public int minIndex()
        {
            if (m_N == 0)
            {
                throw new NullReferenceException("Priority queue underflow");
            }
            return m_pq[1];
        }
        public T minKey()
        {
            if (m_N == 0)
            {
                throw new NullReferenceException("Priority queue underflow");
            }
            return m_Keys[m_pq[1]];
        }
        public int delMin()
        {
            if (m_N == 0) {
                throw new ArgumentException("Priority queue underflow");
            }
            int min = m_pq[1];
            exch(1, m_N--);
            sink(1);
            System.Diagnostics.Debug.Assert(min==m_pq[m_N + 1]);

            m_qp[min] = -1;        // delete
            m_Keys[min] = default(T);    // to help with garbage collection
            m_pq[m_N + 1] = -1;        // not needed
            return min;
        }
        public T keyOf(int i)
        {
            if (i < 0 || i >= m_MaxN)
            {
                throw new IndexOutOfRangeException();
            }
            if (!contains(i)) {
                throw new ArgumentException("index is not in the priority queue");
            } 
            else return m_Keys[i];
        }
        public void changeKey(int i, T key)
        {
            if (i < 0 || i >= m_MaxN) {
                throw new IndexOutOfRangeException();
            }
            if (!contains(i)) {
                throw new ArgumentException("index is not in the priority queue");
            } 
            m_Keys[i] = key;
            swim(m_qp[i]);
            sink(m_qp[i]);
        }
        public void change(int i, T key)
        {
            changeKey(i, key);
        }
        public void decreaseKey(int i, T key)
        {
            if (i < 0 || i >= m_MaxN)
            {
                throw new IndexOutOfRangeException();
            }
            if (!contains(i))
            {
                throw new ArgumentException("index is not in the priority queue");
            }
            if (m_Keys[i].CompareTo(key) <= 0)
            {
                throw new NullReferenceException("Calling decreaseKey() with given argument would not strictly decrease the key");
            }   
            m_Keys[i] = key;
            swim(m_qp[i]);
        }
        public void increaseKey(int i, T key)
        {
            if (i < 0 || i >= m_MaxN)
            {
                throw new IndexOutOfRangeException();
            }
            if (!contains(i))
            {
                throw new ArgumentException("index is not in the priority queue");
            }

            if (m_Keys[i].CompareTo(key) >= 0)
            {
                throw new NullReferenceException("Calling increaseKey() with given argument would not strictly increase the key");
            }
            m_Keys[i] = key;
            sink(m_qp[i]);
        }

        public void delete(int i)
        {
            if (i < 0 || i >= m_MaxN)
            {
                throw new IndexOutOfRangeException();
            }
            if (!contains(i))
            {
                throw new ArgumentException("index is not in the priority queue");
            } 
            int index = m_qp[i];
            exch(index, m_N--);
            swim(index);
            sink(index);
            m_Keys[i] = default(T);
            m_qp[i] = -1;
        }
        private bool greater(int i, int j)
        {
            return m_Keys[m_pq[i]].CompareTo(m_Keys[m_pq[j]]) > 0;
        }
        private void exch(int i, int j)
        {
            int swap = m_pq[i];
            m_pq[i] = m_pq[j];
            m_pq[j] = swap;
            m_qp[m_pq[i]] = i;
            m_qp[m_pq[j]] = j;
        }
        private void swim(int k)
        {
            while (k > 1 && greater(k / 2, k))
            {
                exch(k, k / 2);
                k = k / 2;
            }
        }
        private void sink(int k)
        {
            while (2 * k <= m_N)
            {
                int j = 2 * k;
                if (j < m_N && greater(j, j + 1))
                {
                    j++;
                }
                if (!greater(k, j))
                    break;
                exch(k, j);
                k = j;
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new HeapEnumerator(m_pq,m_Keys,m_N);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class HeapEnumerator : IEnumerator<int>
        {
            private IndexMinPQ<T> m_Copy;
            private int m_Current;
            public HeapEnumerator(int [] pq,T [] keys,int n)
            {
                m_Copy = new IndexMinPQ<T>(pq.Length - 1);
                for (int i = 1; i <= n; i++)
                {
                    m_Copy.insert(pq[i], keys[pq[i]]);
                }
            }
            public bool hasNext()
            {
                return !m_Copy.isEmpty();
            }
            public int Current {
                get {
                    return m_Current;
                }
            }

            object IEnumerator.Current {
                get {
                    return m_Current;
                }
            }
            public bool MoveNext()
            {
                if (!hasNext())
                {
                    return false;
                }
                else
                {
                    m_Current = m_Copy.delMin();
                    return true;
                }
             
            }

            public void Reset()
            {
                m_Current = -1;
            }

            public void Dispose()
            {
                m_Copy = null;
            }
        }
    }
}
