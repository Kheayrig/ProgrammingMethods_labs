using System.Collections;

namespace AVLTree
{
    public class Tree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public Node<TKey,TValue>? Root { get; set; }
        public int Count { get; set; }

        public int GetHeight(Node<TKey,TValue>? node)
        {
            return node?.Height ?? 0;
        }

        public int BalanceFactor(Node<TKey, TValue> node)
        {
            return GetHeight(node.Right) - GetHeight(node.Left);
        }

        public void Insert(Node<TKey, TValue> node)
        {
            if(Root == null)
            {
                Root = node;
                Count++;
                return;
            }
            Node<TKey, TValue> currentNode = Root;
            var parent = currentNode;
            while(currentNode != null)
            {
                parent = currentNode;
                if (node.Key.CompareTo(currentNode.Key) > 0)
                {
                    currentNode = currentNode.Right;
                    if(currentNode == null)
                    {
                        parent.Right = node;
                        parent.Right.Parent = parent;
                    }
                }
                else if(node.Key.CompareTo(currentNode.Key) < 0)
                {
                    currentNode = currentNode.Left;
                    if (currentNode == null)
                    {
                        parent.Left = node;
                        parent.Left.Parent = parent;
                    }
                }
                else throw new ArgumentException("Such key is already added");
            }
            Count++;
        }

        public void Insert(TKey key, TValue value)
        {
            Insert(new Node<TKey, TValue>(key, value));
        }

        //private void FixBalance(Node<TKey, TValue> node)
        //{
        //    while(node != null)
        //    {
        //        node.Height = BalanceFactor(node);
        //        if(node.Height < -2)
        //        node = node.Parent;
        //    }
        //}

        public void Remove(Node<TKey, TValue> node)
        {
            var removedNode = Find(node);

            if (removedNode.Right == null && removedNode.Left == null)
            {
                SwapParentChildToNode(removedNode);
            }
            else if (removedNode.Right == null)
            {
                SwapParentChildToNode(removedNode, removedNode.Left);
            }
            else if (removedNode.Left == null)
            {
                SwapParentChildToNode(removedNode, removedNode.Right);
            }
            else
            {
                var minNode = FindMinNode(removedNode.Right);
                removedNode.Key = minNode.Key;
                removedNode.Value = minNode.Value;
                //swap minNode to right child
                SwapParentChildToNode(minNode, minNode.Right);
            }
            Count--;
        }

        private Node<TKey,TValue> FindMinNode(Node<TKey, TValue> root)
        {
            Node<TKey, TValue> node = root;
            while (root != null) {
                node = root;
                root = root.Left; 
            }
            return node;
        }

        /// <summary>
        /// put a node in removedNode.Parent.Child
        /// </summary>
        /// <param name="removedNode"></param>
        /// <param name="node"></param>
        private void SwapParentChildToNode(Node<TKey, TValue> removedNode, Node<TKey,TValue>? node = null)
        {
            if (removedNode.Parent == null) Root = node;
            else if (removedNode.Parent.Left?.Key.CompareTo(removedNode.Key) == 0) removedNode.Parent.Left = node;
            else removedNode.Parent.Right = node;
        }

        public Node<TKey,TValue> Find(Node<TKey, TValue> node)
        {
            var currentNode = Root;
            while(currentNode != null)
            {
                if(node.Key.CompareTo(currentNode.Key) < 0) currentNode = currentNode.Left;
                else if(node.Key.CompareTo(currentNode.Key) > 0) currentNode = currentNode.Right;
                else return currentNode;
            }
            throw new ArgumentException("Such node does not exist!");
        }

        //private Node<TKey, TValue> RotateLeft(Node<TKey, TValue> node)
        //{

        //}

        //private Node<TKey, TValue> BigRotateLeft(Node<TKey, TValue> node)
        //{
        //    RotateRight(node.Right);
        //    RotateLeft(node);
        //}

        //private Node<TKey, TValue> RotateRight(Node<TKey, TValue> node)
        //{
            
        //}

        public void ConsolePrint()
        {
            var list = new List<Node<TKey, TValue>?>() { Root };
            bool isLeaves = false;
            while (!isLeaves)
            {
                var listTemp = new List<Node<TKey, TValue>?>();
                isLeaves = true;
                foreach (var item in list)
                {
                    if(item != null)
                    {
                        isLeaves = false;
                        listTemp.Add(item.Left);
                        listTemp.Add(item.Right);
                        Console.Write(item.Value);
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("X ");
                    }
                }

                list = listTemp;
                Console.WriteLine();
            }
        }
    }
    public class Node<TKey, TValue>
    {
        public Node<TKey, TValue>? Parent { get; set; }
        public Node<TKey, TValue>? Left { get; set; }
        public Node<TKey, TValue>? Right { get; set; }

        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public int Height { get; set; } = 1;

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

    }
}