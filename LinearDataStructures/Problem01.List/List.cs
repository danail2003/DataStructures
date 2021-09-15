namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;
        private int size;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            this.items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);

                this.items[index] = value;
            }
        }

        public int Count => this.size;

        public void Add(T item)
        {
            if (this.size == this.items.Length)
            {
                this.items = this.Resize();
            }

            this.items[size++] = item;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            int index = -1;

            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);

            if (this.Count == this.items.Length)
            {
                this.items = this.Resize();
            }

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.size++;
        }

        public bool Remove(T item)
        {
            bool isExist = false;

            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i].Equals(item))
                {
                    for (int j = i; j < this.items.Length - 1; j++)
                    {
                        this.items[j] = this.items[j + 1];
                    }

                    this.size--;

                    isExist = true;
                }
            }

            return isExist;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }

            this.items[this.Count - 1] = default;
            this.size--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private T[] Resize()
        {
            T[] newArray = new T[this.items.Length * 2];
            Array.Copy(this.items, newArray, this.items.Length);

            return newArray;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }
    }
}