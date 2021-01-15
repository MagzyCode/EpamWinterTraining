using EpamWinterTraining.Collection;
using EpamWinterTraining.SubjectArea;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestFifthTask
{
    public class TestBinaryTreeFunctional
    {
        private BinaryTree<TestResult> _tree;
        public const int TEST_NUMBER_OF_ELEMENTS = 15;

        [SetUp]
        public void Setup()
        {
            _tree = new BinaryTree<TestResult>();
            for (int i = 0; i < TEST_NUMBER_OF_ELEMENTS; i++)
            {
                var test = new TestResult()
                {
                    StudentNumber = i * 10 + 1,
                    Mark = new Random().Next(TestResult.MIN_TEST_RESULT, TestResult.MAX_TEST_RESULT),
                    TestName = Guid.NewGuid().ToString(),
                    DateОfСompletion = DateTime.Now
                };
                _tree.Add(test);
            }
        }

        [TestCase(ExpectedResult = 15)]
        public int TestBinaryTreeAddition()
        {
            return _tree.ToList().Count;
        }

        [TestCase(ExpectedResult = true)]
        public bool TestBinaryTreeGetMinAndMax()
        {
            var min = _tree.GetMin(_tree.Root).StudentNumber;
            var max = _tree.GetMax(_tree.Root).StudentNumber;

            var minCor = _tree.ToList().Select(i => i.StudentNumber).Min();
            var maxCor = _tree.ToList().Select(i => i.StudentNumber).Max();
            if ((min == minCor) && (max == maxCor))
            {
                return true;
            }
            return false;
        }

        [TestCase(ExpectedResult = 14)]
        public int TestBinaryTreeRemove()
        {
            var randomNumber = new Random().Next(1, _tree.Count);
            var getRandomElement = _tree.ToList().Skip(randomNumber).Take(1).ToList();
            _tree.Remove(getRandomElement[0]);
            return _tree.Count;
        }

        [TestCase(ExpectedResult = true)]
        public bool TestBinatyTreeBalancing()
        {
            _tree.Rebalance();
            var balanceFactor = _tree.GetBalanceFactor(_tree.Root);
            return balanceFactor < 2;
        }

        [TestCase(ExpectedResult = 15)]
        public int TestBinaryTreeSaveInFile()
        {
            _tree.SaveTreeToXmlFile();
            var newTree = BinaryTree<TestResult>.GetTreeFromFile();
            return newTree.Count;
        }

        [TestCase(1, ExpectedResult = true)]
        [TestCase(28, ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        public bool TestBinarySearch(int studentNumber)
        {
            var required = _tree.BinarySearch(studentNumber);
            if (required != null)
            {
                var result = required.StudentNumber == studentNumber;
                return result;
            }
            return false;
        }
    }
}
