namespace app
{
    public class BSTNode<T>
    {
        public BSTNode(T value)
        {
            Data = value;
        }
        public T Data { get; private set; }
        public BSTNode<T> Parent { get; private set; }
        public BSTNode<T> Left { get; private set; }
        public BSTNode<T> Right { get; private set; }

        public void UpdateParentNode(BSTNode<T> node)
        {
            this.Parent = node;
        }

        public void UpdateLeftNode(BSTNode<T> node)
        {
            this.Left = node;
        }

        public void UpdateRightNode(BSTNode<T> node)
        {
            this.Right = node;
        }

        public bool HasChildrens()
        {
            return this.Right != null || this.Left != null;
        }
    }
}