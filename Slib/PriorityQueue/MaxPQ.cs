using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.PriorityQueue
{
    public class MaxPQ<T> : IEnumerable<T>
    {
        private T[] _pq;
        private int _n;
        private IComparer<T> _comparer;

        public MaxPQ(int initCapacity)
        {
            _pq = new T[initCapacity + 1];
            _n = 0;
        }
        public MaxPQ() : this(1)
        {

        }
        public MaxPQ(int initCapacity, IComparer<T> comparer) : this(initCapacity)
        {
            _comparer = comparer;
        }

        public MaxPQ(IComparer<T> comparer) : this()
        {
            _comparer = comparer;
        }

        public MaxPQ(T[] keys)
        {
            _n = keys.Length;
            _pq = new T[_n + 1];
            for (int i = 0; i < _n; i++)
            {
                _pq[i + 1] = keys[i];
            }

            for (int k = _n / 2; k >= 1; k--)
            {
                sink(k);
            }
            System.Diagnostics.Debug.Assert(isMaxHeap());
        }

        public void insert(T key)
        {
            if (_n == _pq.Length - 1)
            {
                resize(2 * _pq.Length);
            }
            _pq[++_n] = key;
            swim(_n);
            System.Diagnostics.Debug.Assert(isMaxHeap());
        }
        public T delMax()
        {
            if (isEmpty())
                throw new IndexOutOfRangeException("Priority queue underflow");
            T max = _pq[1];
            exch(1, _n--);
            sink(1);
            _pq[_n + 1] = default(T);
            if ((_n > 0) && (_n == (_pq.Length - 1) / 4))
            {
                resize(_pq.Length / 2);
            }
            System.Diagnostics.Debug.Assert(isMaxHeap());
            return max;
        }
        public bool isEmpty()
        {
            return _n == 0;
        }

        public int size()
        {
            return _n;
        }

        public T max()
        {
            if (isEmpty())
            {
                throw new IndexOutOfRangeException("Priority queue underflow");
            }
            return _pq[1];
        }
        private void resize(int capacity)
        {
            System.Diagnostics.Debug.Assert(capacity > _n);
            T[] temp = new T[capacity];
            for (int i = 1; i <= _n; i++)
            {
                temp[i] = _pq[i];
            }
            _pq = temp;
        }
        private void swim(int k)
        {
            while (k > 1 && less(k / 2, k))
            {
                exch(k / 2, k);
                k = k / 2;
            }
        }
        private void sink(int k)
        {
            while (2 * k <= _n)
            {
                int j = 2 * k;
                if (j < _n && less(j, j + 1))
                {
                    j++;
                }
                if (!less(k, j))
                {
                    break;
                }
                exch(k, j);
                k = j;
            }
        }
        private bool less(int i, int j)
        {
            if (_comparer == null)
            {
                return ((IComparable<T>)_pq[i]).CompareTo(_pq[j]) < 0;
            }
            else
            {
                return _comparer.Compare(_pq[i], _pq[j]) > 0;
            }
        }

        private void exch(int i, int j)
        {
            T swap = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = swap;
        }

        private bool isMaxHeap()
        {
            return isMaxHeap(1);
        }

        private bool isMaxHeap(int k)
        {
            if (k > _n)
                return true;
            int left = 2 * k;
            int right = 2 * k + 1;
            if (left <= _n && less(k, left))
                return false;
            if (right <= _n && less(k, right))
                return false;
            return isMaxHeap(left) && isMaxHeap(right);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new HeapEnumerator(_comparer, size(), _n, _pq);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class HeapEnumerator : IEnumerator<T>
        {
            private MaxPQ<T> _copy;
            private T _current;

            public HeapEnumerator(IComparer<T> comparer,int size,int n,T[] pq)
            {
                if (comparer == null)
                {
                    _copy = new MaxPQ<T>(size);
                }
                else
                {
                    _copy = new MaxPQ<T>(size, comparer);
                }

                for (int i = 1; i <= n; i++)
                {
                    _copy.insert(pq[i]);
                }
            }
            public bool hasNext()
            {
                return !_copy.isEmpty();
            }
            public T Current {
                get {
                    return _current;
                }
            }

            object IEnumerator.Current {
                get {
                    return _current;
                }
            }

            public void Dispose()
            {
                _copy = null;
            }

            public bool MoveNext()
            {
                if (!hasNext())
                {
                    return false;
                }
                else
                {
                    _current = _copy.delMax();
                    return true;
                }
            }

            public void Reset()
            {
                _current = default(T);
            }
        }
    }
}
