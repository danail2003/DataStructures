namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;
        private int _size;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this._items[index];
            }
            set
            {
                this.ValidateIndex(index);

                if (this.Count == 0)
                {
                    this._items[this._items.Length - 1] = value;
                    this._size++;
                }
                else
                {
                    this._size++;
                    this._items[this._items.Length - this.Count] = value;
                }
            }
        }

        public int Count => this._size;

        public void Add(T item)
        {
            if (this.Count == this._items.Length)
            {
                this._items = this.Resize();
            }

            if (this.Count == 0)
            {
                this._items[0] = item;
            }
            else
            {
                for (int i = this.Count; i > 0; i--)
                {
                    this._items[i] = this._items[i - 1];
                }

                this._items[0] = item;
            }

            this._size++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private T[] Resize()
        {
            T[] newArray = new T[this._items.Length * 2];

            Array.Copy(this._items, newArray, this._items.Length);

            return newArray;
        }
    }
}