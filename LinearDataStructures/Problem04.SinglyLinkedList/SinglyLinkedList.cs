namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private int size;

        public int Count => this.size;

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (this._head != null)
            {
                newNode.Next = this._head;
            }

            this._head = newNode;
            this.size++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (this._head == null)
            {
                this._head = newNode;
            }
            else
            {
                Node<T> current = this._head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            }

            this.size++;
        }

        public T GetFirst()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException();
            }

            return this._head.Value;
        }

        public T GetLast()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException();
            }

            Node<T> current = this._head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public T RemoveFirst()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException();
            }

            T current = this._head.Value;
            this._head = this._head.Next;

            this.size--;

            return current;
        }

        public T RemoveLast()
        {
            if (this._head == null)
            {
                throw new InvalidOperationException();
            }

            Node<T> current = this._head;

            if (current.Next == null)
            {
                T returnedValue = current.Value;
                current = default;
                this.size--;

                return returnedValue;
            }

            for (int i = 0; i < this.size - 2; i++)
            {
                current = current.Next;
            }

            T oldValue = current.Next.Value;
            current.Next = default;

            this.size--;

            return oldValue;
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