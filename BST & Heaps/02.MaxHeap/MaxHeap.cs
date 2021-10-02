namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> _elements;

        public MaxHeap()
        {
            this._elements = new List<T>();
        }

        public int Size => this._elements.Count;

        public void Add(T element)
        {
            this._elements.Add(element);

            int index = this.Size - 1;

            this.HeapifyUp(index);
        }

        public T Peek()
        {
            return this._elements[0];
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);
            while (index > 0 && this.IsGreater(index, parentIndex))
            {
                T temp = this._elements[index];
                this._elements[index] = this._elements[parentIndex];
                this._elements[parentIndex] = temp;
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this._elements[index].CompareTo(this._elements[parentIndex]) > 0;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }
    }
}
