namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this._children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddChild(child);
                this.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();

            this.Dfs(this, sb, 0);

            return sb.ToString().Trim();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            List<Tree<T>> nodes = this.OrderBfs(this);

            int deepestNodeDepth = 0;
            Tree<T> deepestNode = null;

            foreach (var node in nodes)
            {
                int depth = this.GetDepthOfNode(node);

                if (depth > deepestNodeDepth)
                {
                    deepestNode = node;
                    deepestNodeDepth = depth;
                }
            }

            return deepestNode;
        }

        public List<T> GetLeafKeys()
        {
            List<T> result = new List<T>();

            this.Bfs(this, result);

            return result;
        }

        public List<T> GetMiddleKeys()
        {
            List<T> result = new List<T>();
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> subTree = queue.Dequeue();

                if(subTree.Children.Count != 0 && subTree.Parent != null)
                {
                    result.Add(subTree.Key);
                }

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public List<T> GetLongestPath()
        {
            Tree<T> deepestNode = this.GetDeepestLeftomostNode();
            Stack<T> stack = new Stack<T>();
            Tree<T> currentNode = deepestNode;

            while (currentNode != null)
            {
                stack.Push(currentNode.Key);
                currentNode = currentNode.Parent;
            }

            return new List<T>(stack);
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            List<List<T>> result = new List<List<T>>();
            List<T> currentPath = new List<T>
            {
                this.Key
            };

            int currentSum = Convert.ToInt32(this.Key);
            this.GetPathsWithSum(this, result, currentPath, ref currentSum, sum);

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> result = new List<Tree<T>>();
            List<Tree<T>> allNodes = this.SubTreeWithGivenSumBfs(this);

            foreach (var child in allNodes)
            {
                int nodeSum = this.GetSubtreeSumDfs(child);

                if (sum == nodeSum)
                {
                    result.Add(child);
                }
            }

            return result;
        }

        private void Dfs(Tree<T> tree, StringBuilder sb, int depth)
        {
            sb.Append(new string(' ', depth)).Append(tree.Key).Append(Environment.NewLine);

            foreach (var child in tree.Children)
            {
                this.Dfs(child, sb, depth + 2);
            }
        }

        private void Bfs(Tree<T> tree, List<T> result)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                Tree<T> subTree = queue.Dequeue();

                if (subTree.Children.Count == 0)
                {
                    result.Add(subTree.Key);
                }

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        private List<Tree<T>> OrderBfs(Tree<T> tree)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<Tree<T>> nodes = new List<Tree<T>>();

            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                Tree<T> subTree = queue.Dequeue();

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);

                    if (child.Children.Count == 0)
                    {
                        nodes.Add(child);
                    }
                }
            }

            return nodes;
        }

        private int GetDepthOfNode(Tree<T> node)
        {
            int depth = 0;
            Tree<T> current = node;

            while (current.Parent != null)
            {
                depth++;
                current = current.Parent;
            }

            return depth;
        }

        private void GetPathsWithSum(Tree<T> tree, List<List<T>> result, List<T> currentPath, ref int currentSum, int sum)
        {
            foreach (var child in tree.Children)
            {
                currentPath.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);
                this.GetPathsWithSum(child, result, currentPath, ref currentSum, sum);
            }

            if (sum == currentSum)
            {
                result.Add(new List<T>(currentPath));
            }

            currentSum -= Convert.ToInt32(tree.Key);
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private int GetSubtreeSumDfs(Tree<T> child)
        {
            int currentSum = Convert.ToInt32(child.Key);
            int childSum = 0;

            foreach (var node in child.Children)
            {
                childSum += this.GetSubtreeSumDfs(node);
            }

            return currentSum + childSum;
        }

        private List<Tree<T>> SubTreeWithGivenSumBfs(Tree<T> tree)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<Tree<T>> nodes = new List<Tree<T>>();

            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                Tree<T> subTree = queue.Dequeue();

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                    nodes.Add(child);
                }
            }

            return nodes;
        }
    }
}
