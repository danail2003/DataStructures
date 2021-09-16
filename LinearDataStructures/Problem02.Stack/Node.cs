namespace Problem02.Stack
{
    public class Node<T>
    {
        public Node(T value, Node<T> next)
        {
            this.Value = value;
            this.Next = next;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
    }
}