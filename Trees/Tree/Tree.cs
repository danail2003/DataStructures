namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public bool IsRootDeleted { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            List<T> result = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            if (IsRootDeleted)
            {
                return result;
            }

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subTree = queue.Dequeue();

                result.Add(subTree.Value);

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            List<T> result = new List<T>();

            this.Dfs(this, result);

            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parent = this.FindBfs(parentKey);

            this.CheckEmptyNode(parent);

            parent._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            Tree<T> currentNode = this.FindBfs(nodeKey);

            this.CheckEmptyNode(currentNode);

            foreach (var child in currentNode.Children)
            {
                child.Parent = null;
            }

            currentNode._children.Clear();

            Tree<T> parentNode = currentNode.Parent;
            
            if (parentNode is null)
            {
                IsRootDeleted = true;
            }
            else
            {
                parentNode._children.Remove(currentNode);
            }

            currentNode.Value = default;
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }

        private void Dfs(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                this.Dfs(child, result);
            }

            result.Add(tree.Value);
        }

        private Tree<T> FindBfs(T parent)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subTree = queue.Dequeue();

                if (subTree.Value.Equals(parent))
                {
                    return subTree;
                }

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private void CheckEmptyNode(Tree<T> node)
        {
            if (node is null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
