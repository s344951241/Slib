using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slib.Stack
{
   
    public class DoubleStack<T>
    {
        private T[] _array;
        private int _size1;
        private int _size2;

        private const int _defautCapacity = 10;

        public DoubleStack() {
            _array = new T[_defautCapacity];
            _size1 = 0;
            _size2 = _defautCapacity;
        }

        public DoubleStack(int capacity)
        {
            if (capacity < 0)
                throw new Exception("len is less than zero");
            _array = new T[capacity];
            _size1 = 0;
            _size2 = capacity;
        }
        public int Count(int stackNum)
        {
            int size = 0;
            if (stackNum == 1)
            {
                size = _size1;
            }
            else if (stackNum == 2)
            {
                size = _array.Length-_size2;
            }
            Stack<int> st = new Stack<int>();
            return size;
        }
        public Object Pop(int stackNum)
        {
            Object obj = null;
            if (stackNum == 1)
            {
                if (_size1 == 0)
                {
                    throw new InvalidOperationException("doubleStack1 is Empty");
                }
                obj = _array[--_size1];
                _array[_size1] = default(T);
            }
            else if (stackNum == 2)
            {
                if (_size2 == _array.Length)
                {
                    throw new InvalidOperationException("doubleStack2 is Empty");
                }
                obj = _array[_size2];
                _array[_size2] = default(T);
                _size2++;
            }
            return obj;

        }
        public void Push(T obj, int stackNum)
        {
            if (_size1 == _size2)
            {
                T[] newArry = new T[(_array.Length == 0) ? _defautCapacity : 2 * _array.Length];
                Array.Copy(_array, 0, newArry, 0,_size1);
                _size2 = newArry.Length - (_array.Length - _size1);
                Array.Copy(_array, _size1, newArry,_size2 , _array.Length - _size1);
                _array = newArry;
                
            }
            if (stackNum == 1)
            {
                _array[_size1++] = obj;
            }
            else if (stackNum == 2)
            {
                _array[--_size2] = obj;
            }
        }
    }
}
