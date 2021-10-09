namespace _05.TopView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(T value, BinaryTree<T> left, BinaryTree<T> right)
        {
            this.Value = value;
            this.LeftChild = left;
            this.RightChild = right;
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public List<T> TopView()
        {
            SortedDictionary<int, KeyValuePair<T, int>> offsetToValueLevel = new SortedDictionary<int, KeyValuePair<T, int>>();

            this.FillDfs(this, offsetToValueLevel, 0, 1);

            return offsetToValueLevel.Values.Select(kvp => kvp.Key).ToList();
        }

        private void FillDfs(BinaryTree<T> subTree,
            SortedDictionary<int, KeyValuePair<T, int>> offsetToValueLevel,
            int offset,
            int level)
        {
            if (subTree == null)
            {
                return;
            }

            if (!offsetToValueLevel.ContainsKey(offset))
            {
                offsetToValueLevel.Add(offset, new KeyValuePair<T, int>(subTree.Value, level));
            }

            if (level < offsetToValueLevel[offset].Value)
            {
                offsetToValueLevel[offset] = new KeyValuePair<T, int>(subTree.Value, level);
            }

            this.FillDfs(subTree.LeftChild, offsetToValueLevel, offset - 1, level + 1);
            this.FillDfs(subTree.RightChild, offsetToValueLevel, offset + 1, level + 1);
        }
    }
}
