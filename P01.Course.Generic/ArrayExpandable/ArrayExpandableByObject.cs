using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Course.Generic.ArrayExpandable
{
    internal class ArrayExpandableByObject
    {
        private object?[] _items = null;

        private int _defaultCapacity = 4;

        private int _size;

        public object? this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _size)
                    throw new ArgumentOutOfRangeException(nameof(index));
                _items[index] = value;
            }
        }

        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        object[] newItems = new object[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, newItems, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = new object[_defaultCapacity];
                    }
                }
            }
        }

        public int Count => _size;


        public ArrayExpandableByObject()
        {
            _items = new object?[0];
        }

        public ArrayExpandableByObject(int capacity)
        {
            _items = new object?[capacity];
        }

        public void Add(object? value)
        {
            //数组元素为0或者数组元素容量满
            if (_size == _items.Length) EnsuresCapacity(_size + 1);
            _items[_size] = value;
            _size++;
        }

        private void EnsuresCapacity(int size)
        {
            if (_items.Length < size)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if (newCapacity < size) newCapacity = size;
                Capacity = newCapacity;
            }
        }

    }
}
