namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> current = this._head;

            while (current != null)
            {
                if (item.Equals(current.Value))
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

            T current = this._head.Value;
            this._head = this._head.Next;

            this.Count--;

            return current;
        }

        public void Enqueue(T item)
        {
            Node<T> newHead = new Node<T>(item);
            Node<T> current = this._head;

            if (current == null)
            {
                this._head = newHead;
            }
            else
            {
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newHead;
            }

            this.Count++;
        }

        public T Peek()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException();
            }

            return this._head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}