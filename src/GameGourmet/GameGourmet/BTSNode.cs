using System;

namespace GameGourmet
{
    public class BSTNode<T>
    {
        public BSTNode(T value)
        {
            Data = value;
        }
        
        public int Count { get; private set; }

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

        public BSTNode<T> FindRight()
        {
            return this.Right;
        }
        
        public BSTNode<T> FindLeft()
        {
            return this.Left;
        }
        

        public void PreOrderTraversal(BSTNode<T> parent)
        {
            if (parent != null)
            {
                Count++;
                PreOrderTraversal(parent.Left);
                PreOrderTraversal(parent.Right);
            }
        }
    }
}