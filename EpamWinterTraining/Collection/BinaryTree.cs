using EpamWinterTraining.SubjectArea;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EpamWinterTraining.Collection
{
    public class BinaryTree<T> where T : TestResult, IBinaryTreeElement<T>, new()
    {
        /// <summary>
        /// Root of the binary tree.
        /// </summary>
        private T _root;

        /// <summary>
        /// Initializes a BinaryTree<T> object.
        /// </summary>
        public BinaryTree()
        { }

        /// <summary>
        /// Represents a property for accessing 
        /// the root of a binary tree.
        /// </summary>
        public T Root
        {
            get
            {
                return _root;
            }

            set
            {
                _root = value;
            }
        }
        /// <summary>
        /// Maximum level of the binary tree.
        /// </summary>
        public int Depth
        {
            get
            {
                return GetDepth(_root);
            }
        }
        /// <summary>
        /// The number of elements in the binary tree.
        /// </summary>
        public int Count
        {
            get
            {
                return ToList().Count;
            }
        }

        /// <summary>
        /// Brings the binary tree to a balanced view.
        /// </summary>
        public void Rebalance()
        {
            while (!IsTreeBalanced(_root))
            {
                GetRebalance(ref _root);
            }

        }
        /// <summary>
        /// Represents a binary tree as a list.
        /// </summary>
        /// <returns>
        /// Returns a list of all elements in the binary tree.
        /// </returns>
        public List<T> ToList()
        {
            var allElements = new List<T>();
            GetElementsFromTree(Root, ref allElements);
            return allElements;
        }
        /// <summary>
        /// Adds a new element to the binary tree.
        /// </summary>
        /// <param name="test">Test result.</param>
        public void Add(T test)
        {
            if (test == null)
            {
                throw new NullReferenceException("Невозможно добавить null в бинарное дерево");
            }

            if (Root == null)
            {
                Root = test;
            }
            else
            {
                var startPoint = Root;
                while (true)
                {
                    if (test > startPoint)
                    {
                        if (startPoint.Right == null)
                        {
                            startPoint.Right = test;
                            break;
                        }
                        startPoint = startPoint.Right as T;
                    }
                    else if (test < startPoint)
                    {
                        if (startPoint.Left == null)
                        {
                            startPoint.Left = test;
                            break;
                        }
                        startPoint = startPoint.Left as T;
                    }
                    else
                    {
                        throw new Exception("В бинарном дереве могу находится только уникальные элементы.");
                    }
                }
            }


        }

        /// <summary>
        /// Search for testing by student number.
        /// </summary>
        /// <param name="studentNumber">The number of the student.</param>
        /// <returns>The number of the student.</returns>
        public T BinarySearch(int studentNumber)
        {
            var startPoint = _root;
            while (true)
            {

                if (startPoint == null)
                {
                    return null;
                }

                if (startPoint.StudentNumber > studentNumber)
                {
                    startPoint = startPoint.Left as T;
                }
                else if (startPoint.StudentNumber < studentNumber)
                {
                    startPoint = startPoint.Right as T;
                }
                else
                {
                    return startPoint;
                }

            }
        }


        /// <summary>
        /// Gets the difference in depths of subtrees.
        /// </summary>
        /// <param name="root">Tree root.</param>
        /// <returns>The difference in depths of subtrees</returns>
        public int GetBalanceFactor(T root)
        {
            var balanceFactor = Math.Abs(GetDepth(root.Right as T) - GetDepth(root.Left as T));
            return balanceFactor;
        }
        /// <summary>
        /// Deleting the test result 
        /// from the binary tree.
        /// </summary>
        /// <param name="test">The test result to delete.</param>
        public void Remove(T test)
        {
            if (test == null)
            {
                throw new NullReferenceException("Значения для удаления не можеть быть null.");
            }

            if ((test.Left == null) && (test.Right == null))
            {
                ChangePatherHeir(test);
            }
            else if ((test.Left != null) && (test.Right == null))
            {
                ChangePatherHeir(test, test.Left as T);
            }
            else if (((test.Left == null) && (test.Right != null)) ||
                ((test.Left != null) && (test.Right != null) &&
                (test.Right.Left == null)))
            {
                ChangePatherHeir(test, test.Right as T);
            }
            else
            {
                var newHeir = GetMin(test.Right as T);
                ChangePatherHeir(newHeir, newHeir.Right as T);
                ChangePatherHeir(test, newHeir, true);
            }

        }
        /// <summary>
        /// Gets the maximum depth of the binary tree.
        /// </summary>
        /// <param name="root">Root of the binary tree.</param>
        /// <returns>The depth of the tree.</returns>
        public int GetDepth(T root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + Math.Max(GetDepth(root.Left as T), GetDepth(root.Right as T));
        }
        /// <summary>
        /// Checks the tree for balance.
        /// </summary>
        /// <param name="root">Root of the binary tree.</param>
        /// <returns>
        /// Returns true if the root subtrees differ 
        /// by no more than 2 levels in depth, 
        /// or if the root is equal to null. 
        /// In all other cases, it returns false.
        /// </returns>
        public bool IsTreeBalanced(T root)
        {
            if (root == null)
            {
                return true;
            }

            var balanceCoefficient = Math.Abs(GetDepth(root.Left as T) - GetDepth(root.Right as T));
            if (balanceCoefficient < 2)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Gets the minimum element of the binary tree.
        /// </summary>
        /// <param name="treeRoot">Root of the binary tree.</param>
        /// <returns>Returns the minimum element.</returns>
        public T GetMin(T treeRoot)
        {
            if (treeRoot == null)
            {
                return treeRoot;
            }

            T startPoint = treeRoot;
            for (; startPoint.Left != null; startPoint = (T)startPoint.Left) ;
            return startPoint;
        }
        /// <summary>
        /// Gets the maximum element of the binary tree.
        /// </summary>
        /// <param name="treeRoot">Makes a turn to the right (left) of the tree around the node.</param>
        /// <returns>Returns the maximum element.</returns>
        public T GetMax(T treeRoot)
        {
            if (treeRoot == null)
            {
                return treeRoot;
            }

            T startPoint = treeRoot;
            for (; startPoint.Right != null; startPoint = (T)startPoint.Right) ;
            return startPoint;
        }
        /// <summary>
        /// Makes a turn to the right 
        /// of the tree around the node.
        /// </summary>
        /// <param name="root">Makes a turn to the right (left) of the tree around the node.</param>
        public void RotateRight(ref T root)
        {
            var previousRoot = root;
            var freshRoot = root.Left;
            previousRoot.Left = freshRoot.Right;
            freshRoot.Right = previousRoot;
            root = freshRoot as T;

        }
        /// <summary>
        /// Makes a turn to the left
        /// of the tree around the node.
        /// </summary>
        /// <param name="root">Makes a turn to the right (left) of the tree around the node.</param>
        public void RotateLeft(ref T root)
        {
            var previousRoot = root;
            var freshRoot = root.Right;
            previousRoot.Right = freshRoot.Left;
            freshRoot.Left = previousRoot;
            root = freshRoot as T;
        }
        /// <summary>
        /// Saves the binary tree to an xml file.
        /// </summary>
        /// <param name="path">Path to the saved file.</param>
        public void SaveTreeToXmlFile(string path = @"tree.xml")
        {
            var xmlFormatter = new XmlSerializer(typeof(T));
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            xmlFormatter.Serialize(stream, _root);
        }
        /// <summary>
        /// Retrieves a binary tree from an xml file.
        /// </summary>
        /// <param name="path">Path to the file to pull out.</param>
        /// <returns>Returns a binary tree.</returns>
        public static BinaryTree<T> GetTreeFromFile(string path = @"tree.xml")
        {
            var xmlFormatter = new XmlSerializer(typeof(T));
            using var stream = new FileStream(path, FileMode.OpenOrCreate);
            var root = xmlFormatter.Deserialize(stream) as T;
            var tree = new BinaryTree<T>()
            {
                Root = root
            };
            return tree;
        }

        /// <summary>
        /// Changes the root that has passed one balancing cycle.
        /// </summary>
        /// <param name="root">Root of the binary tree.</param>
        private void GetRebalance(ref T root)
        {
            if (root == null)
            {
                return;
            }

            var depthOfLeftTree = GetDepth(root.Left as T);
            var depthOfRightTree = GetDepth(root.Right as T);

            if (depthOfLeftTree > depthOfRightTree)
            {
                RotateRight(ref _root);
            }
            else
            {
                RotateLeft(ref _root);
            }
        }
        /// <summary>
        /// Traverses all tree elements recursively 
        /// and adds them to the list.
        /// </summary>
        /// <param name="element">The current element of the tree traversal.</param>
        /// <param name="allElements">List of items.</param>
        private void GetElementsFromTree(T element, ref List<T> allElements)
        {
            if (element == null)
            {
                return;
            }

            if (element != null)
            {
                allElements.Add(element);
            }
            GetElementsFromTree(element.Left as T, ref allElements);
            GetElementsFromTree(element.Right as T, ref allElements);
        }
        /// <summary>
        /// Replaces an element with a new one.
        /// </summary>
        /// <param name="heir">The element to replace.</param>
        /// <param name="newHeir">The element with which to replace it.</param>
        /// <param name="isTwoHeirs">Specified for complex replacements.</param>
        private void ChangePatherHeir(T heir, T newHeir = null, bool isTwoHeirs = false)
        {
            var startPoint = Root;
            while (true)
            {
                if ((startPoint.Left == heir) || (startPoint.Right == heir))
                {
                    if (startPoint > heir)
                    {
                        startPoint.Left = newHeir;
                        if (isTwoHeirs)
                        {
                            newHeir.Left = heir.Left;
                            newHeir.Right = heir.Right;
                        }
                        heir.Left = null;
                        heir.Right = null;
                        break;
                    }
                    else
                    {
                        startPoint.Right = newHeir;
                        if (isTwoHeirs)
                        {
                            newHeir.Left = heir.Left;
                            newHeir.Right = heir.Right;
                        }
                        heir.Left = null;
                        heir.Right = null;
                        break;
                    }

                }

                if (startPoint > heir)
                {
                    startPoint = startPoint.Left as T;
                }
                else
                {
                    startPoint = startPoint.Right as T;
                }
            }

        }
    }
}
