namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            this.Value = value;
            this.RightChild = rightChild;
            this.LeftChild = leftChild;

            if (this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }

            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            List<BinaryTree<T>> firstList = new List<BinaryTree<T>>();
            List<BinaryTree<T>> secondList = new List<BinaryTree<T>>();

            this.FindDfs(this, first, firstList);
            this.FindDfs(this, second, secondList);

            BinaryTree<T> firstNode = firstList[0];
            BinaryTree<T> secondNode = secondList[0];

            T parent = firstNode.Parent.Value;

            while (!parent.Equals(firstNode.Value) || !parent.Equals(secondNode.Value))
            {
                if (!parent.Equals(firstNode.Value))
                {
                    firstNode = firstNode.Parent;
                }

                if (!parent.Equals(secondNode.Value))
                {
                    secondNode = secondNode.Parent;
                }
            }

            return firstNode.Value;
        }

        private void FindDfs(BinaryTree<T> current, T value, List<BinaryTree<T>> list)
        {
            if (current == null)
            {
                return;
            }

            if (current.Value.Equals(value))
            {
                list.Add(current);
            }

            this.FindDfs(current.LeftChild, value, list);
            this.FindDfs(current.RightChild, value, list);
        }
    }
}
