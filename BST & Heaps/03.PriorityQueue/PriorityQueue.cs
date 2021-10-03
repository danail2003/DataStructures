namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> _elements;

        public PriorityQueue()
        {
            this._elements = new List<T>();
        }

        public int Size => this._elements.Count;

        public T Dequeue()
        {
            T element = this.Peek();
            this._elements[0] = this._elements[this.Size - 1];
            this._elements[this.Size - 1] = element;
            this._elements.RemoveAt(this.Size - 1);
            this.HeapifyDown();

            return element;
        }

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

        private void HeapifyDown()
        {
            int index = 0;
            int leftChildIndex = this.GetLeftChildIndex(0);
            while (this.IndexIsValid(leftChildIndex) && this.IsLess(index, leftChildIndex))
            {
                int toSwapWith = leftChildIndex;
                int rightChildIndex = this.GetRightChildIndex(index);

                if (this.IndexIsValid(rightChildIndex) && this.IsLess(toSwapWith, rightChildIndex))
                {
                    toSwapWith = rightChildIndex;
                }

                this.Swap(toSwapWith, index);
                index = toSwapWith;
                leftChildIndex = this.GetLeftChildIndex(index);
            }
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = this.GetParentIndex(index);
            while (index > 0 && this.IsGreater(index, parentIndex))
            {
                this.Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = this.GetParentIndex(index);
            }
        }
        private void Swap(int currentIndex, int parentIndex)
        {
            T temp = this._elements[currentIndex];
            this._elements[currentIndex] = this._elements[parentIndex];
            this._elements[parentIndex] = temp;
        }

        private bool IsGreater(int index, int parentIndex)
        {
            return this._elements[index].CompareTo(this._elements[parentIndex]) > 0;
        }

        private bool IsLess(int index, int parentIndex)
        {
            return this._elements[index].CompareTo(this._elements[parentIndex]) < 0;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private bool IndexIsValid(int index)
        {
            return index < this.Size;
        }
    }
}
