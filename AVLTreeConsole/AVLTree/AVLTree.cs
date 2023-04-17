using System.Xml.Linq;

namespace AVLTree
{
    public class AVLTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        public Node<TKey, TValue>? Root { get; set; }
        public int Count { get; private set; }

        public TValue this[TKey key] {
            get
            { 
                var node = Find(key) ?? throw new ArgumentException("Key not found");
                return node.Value;
            }
            set
            {
                var node = Find(key) ?? throw new ArgumentException("Key not found");
                node.Value = value;
            }
        } 

        public void Insert(Node<TKey, TValue> node)
        {
            Count++;
            if (Root == null)
            {
                Root = node;
                return;
            }
            var res = FindNodeParent(node.Key);
            node.Parent = res.Key;

            if (res.Value == false && res.Key.Left == null)
            {
                res.Key.Left = node;
            }
            else if (res.Value == true && res.Key.Right == null)
            {
                res.Key.Right = node;
            }
            else
            {
                Count--;
                throw new ArgumentException("Such key is already added");
            }
            FixBalance(node);
        }

        public void Insert(TKey key, TValue value)
        {
            Insert(new Node<TKey, TValue>(key, value));
        }

        public bool Contains(TKey key)
        {
            return Find(key) != null;
        }

        private Node<TKey, TValue>? Find(TKey key)
        {
            var res = FindNodeParent(key);
            Node<TKey, TValue>? foundNode;
            if (res.Value == true) foundNode = res.Key.Right;
            else if (res.Value == false) foundNode = res.Key.Left;
            else foundNode = res.Key ?? Root;

            return foundNode;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns>node parent + direction(true-right child, false - left child, null - node is root)</returns>
        /// <exception cref="ArgumentException"></exception>
        private KeyValuePair<Node<TKey, TValue>, bool?> FindNodeParent(TKey key)
        {
            var currentNode = Root ?? throw new ArgumentNullException("Tree is empty");
            var parent = currentNode;
            bool? direction = null;
            while (currentNode != null)
            {
                parent = currentNode;
                if (key.CompareTo(currentNode.Key) < 0)
                {
                    currentNode = currentNode.Left;
                    direction = false;
                }
                else if (key.CompareTo(currentNode.Key) > 0)
                {
                    currentNode = currentNode.Right;
                    direction = true;
                }
                else
                {
                    parent = currentNode.Parent;
                    break;
                }
            }
            return new KeyValuePair<Node<TKey, TValue>, bool?>(parent, direction);
        }

        public bool Remove(TKey key)
        {
            var removedNode = Find(key);
            if(removedNode == null) return false;
            Count--;

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
                FixBalance(minNode.Parent);
                return true;
            }
            FixBalance(removedNode.Parent);
            return true;
        }

        public bool Remove(Node<TKey, TValue> node)
        {
            return Remove(node.Key);
        }

        private Node<TKey, TValue>? FindMinNode(Node<TKey, TValue>? root)
        {
            Node<TKey, TValue>? node = root;
            while (root != null)
            {
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
        private void SwapParentChildToNode(Node<TKey, TValue>? removedNode, Node<TKey, TValue>? node = null)
        {
            if (removedNode == null) return;
            else if (removedNode.Parent == null) Root = node;
            else if (removedNode.Parent.Left?.Key.CompareTo(removedNode.Key) == 0) removedNode.Parent.Left = node;
            else removedNode.Parent.Right = node;

            if (node != null) node.Parent = removedNode.Parent;
        }

        private int GetHeight(Node<TKey, TValue>? node)
        {
            return node?.Height ?? 0;
        }

        private void FixHeight(Node<TKey, TValue>? node)
        {
            if(node == null) return;
            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        private int BalanceFactor(Node<TKey, TValue> node)
        {
            return GetHeight(node.Right) - GetHeight(node.Left);
        }

        private void FixBalance(Node<TKey, TValue>? node)
        {
            if (node == null) return;
            while (node != null)
            {
                var balance = BalanceFactor(node);
                FixHeight(node);
                if (balance < -1)
                {
                    if (BalanceFactor(node.Left) <= 0) node = RotateRight(node);
                    else node = BigRotateLR(node);
                }
                else if (balance > 1)
                {
                    //Простой поворот выполняется при условии, что высота левого поддерева узла node.Right больше высоты его правого поддерева: h(node.Right.Left)≤h(node.Right.Right).
                    if (BalanceFactor(node.Right) >= 0) node = RotateLeft(node);
                    //Большой поворот применяется при условии h(node.Right.Left)>h(node.Right.Right)
                    else node = BigRotateRL(node);
                }
                node = node.Parent;
            }
        }

        private Node<TKey, TValue> RotateRight(Node<TKey, TValue> root)
        {
            var tmp = root.Left;
            SwapParentChildToNode(root, root.Left);
            root.Left = tmp.Right;
            if (root.Left != null) root.Left.Parent = root;
            tmp.Right = root;
            root.Parent = tmp;

            FixHeight(root);
            FixHeight(tmp.Right);
            return root;
        }

        private Node<TKey, TValue> RotateLeft(Node<TKey, TValue> root)
        {
            var tmp = root.Right;
            SwapParentChildToNode(root, root.Right);
            root.Right = tmp.Left;
            if(root.Right != null) root.Right.Parent = root;
            tmp.Left = root;
            root.Parent = tmp;
            FixHeight(root);
            FixHeight(tmp.Right);
            return root;
        }

        private Node<TKey, TValue> BigRotateRL(Node<TKey, TValue> node)
        {
            RotateRight(node.Right);
            return RotateLeft(node);
        }

        private Node<TKey, TValue> BigRotateLR(Node<TKey, TValue> node)
        {
            RotateLeft(node.Left);
            return RotateRight(node);
        }
    }
    public class Node<TKey, TValue>
    {
        public Node<TKey, TValue>? Parent { get; internal set; }
        public Node<TKey, TValue>? Left { get; internal set; }
        public Node<TKey, TValue>? Right { get; internal set; }

        public TKey Key { get; internal set; }
        public TValue Value { get; set; }

        public int Height { get; internal set; } = 1;

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

    }
}