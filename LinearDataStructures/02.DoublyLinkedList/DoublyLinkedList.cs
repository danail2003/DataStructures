namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Item = item,
                Next = null,
            };

            if (this.head == null)
            {
                this.head = this.tail = newNode;
            }
            else
            {
                Node<T> oldHead = this.head;

                oldHead.Previous = newNode;
                this.head = newNode;
                this.head.Next = oldHead;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            throw new NotImplementedException();
        }

        public T GetFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            return this.head.Item;
        }

        public T GetLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            Node<T> current = this.head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Item;
        }

        public T RemoveFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            T oldValue = this.head.Item;
            this.head = this.head.Next;

            this.Count--;

            return oldValue;
        }

        public T RemoveLast()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException();
            }

            if (this.Count == 1)
            {
                this.Count--;

                T oldValue = this.head.Item;
                this.head = default;

                return oldValue;
            }

            Node<T> current = this.head;

            for (int i = 0; i < this.Count - 2; i++)
            {
                current = current.Next;
            }

            T lastElement = current.Next.Item;
            current.Next = default;

            this.Count--;

            return lastElement;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this.head;

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