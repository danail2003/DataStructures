namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

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
                    this._items[0] = value;
                }
                else
                {
                    if (index == 0)
                    {
                        this._items[index] = value;
                    }
                    else
                    {
                        for (int i = index - 1; i < index; i++)
                        {
                            this._items[index - i - 1] = value;
                        }
                    }
                }
            }
        }

        public int Count { get; set; }

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

            this.Count++;
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

            if (this.Count == this._items.Length)
            {
                this._items = this.Resize();
            }

            if (index == this.Count)
            {
                this._items[index] = item;
            }
            else
            {
                for (int i = 0; i < this.Count - index; i++)
                {
                    this._items[this.Count - i] = this._items[this.Count - i - 1];
                }

                this._items[index] = item;
            }

            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = 0;
            bool isFound = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this._items[i]))
                {
                    index = i;
                    this._items[i] = default;
                    this.Count--;
                    isFound = true;
                    break;
                }
            }

            for (int i = 0; i < this.Count - index; i++)
            {
                this._items[index + i] = this._items[index + i + 1];
            }

            return isFound;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            this._items[index] = default;
            this.Count--;

            for (int i = 0; i < this.Count - index; i++)
            {
                this._items[index + i] = this._items[index + i + 1];
            }
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