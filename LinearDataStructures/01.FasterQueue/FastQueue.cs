namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> current = this._head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException();
            }

            Node<T> current = this._head;
            T oldValue = current.Item;
            this._head = current.Next;

            this.Count--;

            return oldValue;
        }

        public void Enqueue(T item)
        {
            Node<T> newItem = new Node<T>
            {
                Item = item,
                Next = null
            };

            if (this._head == null)
            {
                this._head = this._tail = newItem;
            }
            else
            {
                this._tail.Next = newItem;
                this._tail = this._tail.Next;
            }

            this.Count++;
        }

        public T Peek()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException();
            }

            return this._head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}