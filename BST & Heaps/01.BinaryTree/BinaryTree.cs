namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value,
            IAbstractBinaryTree<T> leftChild,
            IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder result = new StringBuilder();

            this.AsIndentedPreOrderDfs(this, indent, result);

            return result.ToString();
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> inOrderElements = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                inOrderElements.AddRange(this.LeftChild.InOrder());
            }

            inOrderElements.Add(this);

            if (this.RightChild != null)
            {
                inOrderElements.AddRange(this.RightChild.InOrder());
            }

            return inOrderElements;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> inOrderElements = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                inOrderElements.AddRange(this.LeftChild.PostOrder());
            }

            if (this.RightChild != null)
            {
                inOrderElements.AddRange(this.RightChild.PostOrder());
            }

            inOrderElements.Add(this);

            return inOrderElements;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> inOrderElements = new List<IAbstractBinaryTree<T>>();

            inOrderElements.Add(this);

            if (this.LeftChild != null)
            {
                inOrderElements.AddRange(this.LeftChild.PreOrder());
            }

            if (this.RightChild != null)
            {
                inOrderElements.AddRange(this.RightChild.PreOrder());
            }

            return inOrderElements;
        }

        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.ForEachInOrder(action);
            }

            action.Invoke(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.ForEachInOrder(action);
            }
        }

        private void AsIndentedPreOrderDfs(IAbstractBinaryTree<T> binaryTree, int indent, StringBuilder result)
        {
            result.AppendLine($"{new string(' ', indent)}{binaryTree.Value}");

            if (binaryTree.LeftChild != null)
            {
                this.AsIndentedPreOrderDfs(binaryTree.LeftChild, indent + 2, result);
            }

            if (binaryTree.RightChild != null)
            {
                this.AsIndentedPreOrderDfs(binaryTree.RightChild, indent + 2, result);
            }
        }
    }
}
