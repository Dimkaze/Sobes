using System;

namespace SobeS
{
    class Node<T> : IComparable<T>, IComparable where T : IComparable
    {
        public T Data { get; private set; }
        public Node<T> Left { get; private set; }
        public Node<T> Right { get; private set; }

        public Node(T data)
        {
            Data = data;
        }

        public Node(T Data, Node<T> Left, Node<T> Right)
        {
            this.Data = Data;
            this.Left = Left;
            this.Right = Right;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);
            if (node.Data.CompareTo(Data) == -1)
            {
                if (Left == null) Left = node;
                else Left.Add(data);
            }
            else
            {
                if (Right == null) Right = node;
                else Right.Add(data);
            }
                
        }
        public int CompareTo(object? obj)
        {
            if (obj is Node<T> item)
            {
                return Data.CompareTo(obj);
            }
            throw new Exception("Несовпадение типов");
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }

        public override string ToString() => Data.ToString();
        
    }
}