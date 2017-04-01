using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class Node<T> 
    {
        public Node(T value) {
            Value = value;
            Left = null;
            Right = null;
        }

        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }

    public class BST<T> where T : IComparable<T>
    {
        public Node<T> Head { get; set; }

        public void Insert(T value)
        {
            Node<T> node = new Node<T>(value);
            Node<T> temp = Head;

            if(temp == null) {Head = node;}

            while(temp != null)
            {
                int comparisonResult = temp.Value.CompareTo(value);

                if (comparisonResult > 0)
                {
                    // Insert Right
                    if(temp.Right == null)
                    {
                        temp.Right = node;
                        return;
                    }
                    else
                    {
                        temp = temp.Right;
                    }
                }
                else if (comparisonResult < 0)
                {
                    // Insert Left
                    if(temp.Left == null)
                    {
                        temp.Left = node;
                        return;
                    }
                    else
                    {
                        temp = temp.Left;
                    }
                }
                else
                {
                    // Insert Right in case of equality.
                    temp = temp.Right;
                }
            }           
        }

        public T GetMinValue()
        {
            if (Head == null) { throw new KeyNotFoundException(); }
            var temp = Head;

            while(temp.Left != null)
            {
                temp = temp.Left;
            }

            return temp.Value;
        }

        public T GetMaxValue()
        {
            if(Head == null) { throw new KeyNotFoundException(); }

            var temp = Head;

            while(temp.Right != null)
            {
                temp = temp.Right;
            }

            return temp.Value;
        }

        public bool Remove(T value)
        {
            if (Head == null) { throw new KeyNotFoundException(); }

            var current = Head;
            Node<T> previous = null;

            while(current != null)
            {
                int comparisonResult = current.Value.CompareTo(value);

                if(comparisonResult == 0)
                {
                    if(current.Left == null && current.Right == null)
                    {
                        if (previous.Left == current)
                            previous.Left = null;
                        else
                            previous.Right = null;
                    }
                    else if(current.Left == null)
                    {
                        if (previous.Left == current)
                            previous.Left = current.Right;
                        else
                            previous.Right = current.Right;
                    }
                    else if(current.Right == null)
                    {
                        if (previous.Left == current)
                            previous.Left = current.Left;
                        else
                            previous.Right = current.Left;
                    }
                    else
                    {
                        var prevTemp = previous;
                        var temp = current;

                        while(temp.Left != null)
                        {
                            prevTemp = previous.Left;
                            temp = temp.Left;
                        }

                        T newVal = temp.Value;

                        current.Value = temp.Value;
                        prevTemp.Left = null;
                    }

                    return true;
                }
                else if (comparisonResult < 0)
                {
                    previous = current;
                    current = current.Left;
                }
                else
                {
                    previous = current;
                    current = current.Right;
                }

            }

            return false;
        }

        public List<T> InOderTraversal()
        {
            Node<T> temp = Head;

            return this.InOderTraversal(temp);
        }

        public List<T> InOderTraversal(Node<T> node)
        {
            List<T> result = new List<T>();

            while (node != null)
            {
                InOderTraversal(node.Left);
                result.Add(node.Value);
                InOderTraversal(node.Right);
            }

            return result;
        }

        public List<T> InOrderTraversalIterative()
        {
            Stack<T> stack = new Stack<T>();
            var temp = Head;

            while(temp != null)
            {

            }

            return null;
        }

        public List<T> InOderTraversalIterative()
        {
            Node<T> temp = Head;

            return null;
        }

        public List<T> PreOrderTraversal()
        {
            Node<T> temp = Head;

            return this.PreOrderTraversal(temp);
        }

        public List<T> PreOrderTraversal(Node<T> node)
        {
            List<T> result = new List<T>();

            while(node != null)
            {
                result.Add(node.Value);
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }

            return result;
        }

        public List<T> PostOrderTraversal()
        {
            Node<T> temp = Head;

            return this.PostOrderTraversal(temp);
        }

        public List<T> PostOrderTraversal(Node<T> node)
        {
            List<T> result = new List<T>();

            while(node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                result.Add(node.Value);
            }

            return result;
        }
    }
}
