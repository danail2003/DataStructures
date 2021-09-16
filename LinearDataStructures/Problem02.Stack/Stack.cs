namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public Stack()
        {
            this._top = null;
            this.Count = 0;
        }

        public Stack(Node<T> _top)
        {
            this._top = _top;
            this.Count = 1;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> current = this._top;

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

        public T Peek()
        {
            if (this._top == null)
            {
                throw new InvalidOperationException();
            }

            return this._top.Value;
        }

        public T Pop()
        {
            if (this._top == null)
            {
                throw new InvalidOperationException();
            }

            T current = this._top.Value;

            Node<T> newTop = this._top.Next;
            this._top.Next = null;
            this._top = newTop;


            this.Count--;

            return current;
        }

        public void Push(T item)
        {
            Node<T> newNode = new Node<T>(item, _top);

            this._top = newNode;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = this._top;

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