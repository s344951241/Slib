using System;
using System.Collections;
using System.Collections.Generic;

namespace Slib.PriorityQueue
{
   
    public class MinPQ<T> : IEnumerable<T>
    {
        private T[] m_pq;
        private int m_N;
        private IComparer<T> m_Comparer;

        public MinPQ(int initCapacity)
        {
            m_pq = new T[initCapacity + 1];
            m_N = 0;
        }
        public MinPQ():this(1)
        {
            
        }
        public MinPQ(int initCapacity, IComparer<T> comparer):this(initCapacity)
        {
            m_Comparer = comparer;
        }
        public MinPQ(IComparer<T> comparer) : this()
        {
            m_Comparer = comparer;
        }
        public MinPQ(T[] keys)
        {
            m_N = keys.Length;
            m_pq = new T[m_N + 1];
            for (int i = 0; i < m_N; i++)
            {
                m_pq[i + 1] = keys[i];
            }
            for (int k = m_N / 2; k >= 1; k--)
            {
                sink(k);
            }
            System.Diagnostics.Debug.Assert(isMinHeap());
        }
        public bool isEmpty()
        {
            return m_N == 0;
        }

        public int size()
        {
            return m_N;
        }
        public T min()
        {
            if (isEmpty())
                throw new IndexOutOfRangeException("Priority queue underflow");
            return m_pq[1];
        }

        private void resize(int capacity)
        {
            System.Diagnostics.Debug.Assert(capacity>m_N);
            T[] temp = new T[capacity];
            for (int i = 1; i <= m_N; i++)
            {
                temp[i] = m_pq[i];
            }
            m_pq = temp;
        }

        public void insert(T t)
        {
            if (m_N == m_pq.Length - 1)
                resize(2 * m_pq.Length);
            m_pq[++m_N] = t;
            swim(m_N);
            System.Diagnostics.Debug.Assert(isMinHeap());
        }
        public T delMin()
        {
            if (isEmpty())
                throw new IndexOutOfRangeException("Priority queue underflow");
            exch(1, m_N);
            T min = m_pq[m_N--];
            sink(1);
            m_pq[m_N + 1] = default(T);
            if ((m_N > 0) && (m_N == (m_pq.Length - 1) / 4))
            {
                resize(m_pq.Length / 2);
            }
            System.Diagnostics.Debug.Assert(isMinHeap());
            return min;

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
        private bool greater(int i, int j)
        {
            if (m_Comparer == null)
            {
                return ((IComparable<T>)m_pq[i]).CompareTo(m_pq[j]) > 0;
            }
            else
            {
                return m_Comparer.Compare(m_pq[i], m_pq[j]) > 0;
            }
        }

        private void exch(int i,int j)
        {
            T swap = m_pq[i];
            m_pq[i] = m_pq[j];
            m_pq[j] = swap;
        }
        private bool isMinHeap()
        {
            return isMinHeap(1);
        }
        private bool isMinHeap(int k)
        {
            if (k > m_N)
                return true;
            int left = 2 * k;
            int right = 2 * k + 1;
            if (left <= m_N && greater(k, left))
                return false;
            if (right <= m_N && greater(k, right))
                return false;
            return isMinHeap(left) && isMinHeap(right);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new HeapEnumerator(m_Comparer,size(),m_N,m_pq);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class HeapEnumerator : IEnumerator<T>
        {
            private MinPQ<T> m_Copy;
            private T m_Curret;
            public HeapEnumerator(IComparer<T> comparer,int size,int n,T[] pq)
            {
                if (comparer == null)
                {
                    m_Copy = new MinPQ<T>(size);
                }
                else
                {
                    m_Copy = new MinPQ<T>(size, comparer);
                }
                for (int i = 1; i <= n; i++)
                {
                    m_Copy.insert(pq[i]);
                }
            }
            public void Dispose()
            {
                m_Copy = null;
            }

            public bool MoveNext()
            {
                if (!hasNext())
                {
                    return false;
                }
                else
                {
                    m_Curret = m_Copy.delMin();
                    return true;
                }
            }

            public void Reset()
            {
                m_Curret = default(T);
            }

            public bool hasNext()
            {
                return !m_Copy.isEmpty();
            }
            object IEnumerator.Current
            {
                get
                {
                    return m_Curret;
                }
            }

            public T Current
            {
                get {
                    return m_Curret;
                }
            }
        }
    }
}
