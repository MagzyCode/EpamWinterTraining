using EpamWinterTraining.Collection;
using System;

namespace EpamWinterTraining.SubjectArea
{
    public class TestResult : IBinaryTreeElement<TestResult>
    {
        /// <summary>
        /// Unique student number.
        /// </summary>
        private protected int _studentNumber;
        /// <summary>
        /// Mark for the test.
        /// </summary>
        private protected int _mark;
        /// <summary>
        /// Name of the test.
        /// </summary>
        private protected string _testName;
        /// <summary>
        /// Name of the test.
        /// </summary>
        private protected DateTime _dateОfСompletion;

        /// <summary>
        /// Minimum mark for the test.
        /// </summary>
        public const int MIN_TEST_RESULT = 0;
        /// <summary>
        /// Maximum mark for the test.
        /// </summary>
        public const int MAX_TEST_RESULT = 100;
        /// <summary>
        /// The maximum length of the name of the test.
        /// </summary>
        public const int MAX_TEST_NAME_LENGTH = 500;
        /// <summary>
        /// The minimum date on which testing could take place.
        /// </summary>
        public static readonly DateTime MIN_TEST_DATE = new DateTime(1970, 1, 1, 0, 0, 0);

        /// <summary>
        /// Initializes a TestResult object.
        /// </summary>
        public TestResult()
        { }

        /// <summary>
        /// Initializes a TestResult object.
        /// </summary>
        /// <param name="studentNumber">Unique student number.</param>
        /// <param name="testName">Name of the test.</param>
        /// <param name="dateOfCompletion">Name of the test.</param>
        /// <param name="mark">Unique student number.</param>
        public TestResult(int studentNumber, string testName, DateTime dateOfCompletion, int mark)
        {
            StudentNumber = studentNumber;
            TestName = testName;
            DateОfСompletion = dateOfCompletion;
            Mark = mark;
        }

        /// <summary>
        /// Unique student number.
        /// </summary>
        public int StudentNumber
        {
            get
            {
                return _studentNumber;
            }

            set
            {
                if (value >= 1)
                {
                    _studentNumber = value;
                }
                else
                {
                    throw new Exception("Невозможное значение для студенческого номера.");
                }
            }
        }
        /// <summary>
        /// Unique student number.
        /// </summary>
        public int Mark
        {
            get
            {
                return _mark;
            }

            set
            {
                if ((value >= MIN_TEST_RESULT) && (value <= MAX_TEST_RESULT))
                {
                    _mark = value;
                }
                else
                {
                    throw new Exception("Невозможное значение для оценки за тест.");
                }
            }
        }
        /// <summary>
        /// Name of the test.
        /// </summary>
        public DateTime DateОfСompletion
        {
            get
            {
                return _dateОfСompletion;
            }

            set
            {
                _dateОfСompletion = value <= MIN_TEST_DATE
                    ? throw new Exception("Некорректная дата проведения тестирования")
                    : value;
            }
        }
        /// <summary>
        /// Name of the test.
        /// </summary>
        public string TestName
        {
            get
            {
                return _testName.Clone() as string;
            }

            set
            {
                if (value != null)
                {
                    _testName = value.Length > MAX_TEST_NAME_LENGTH
                        ? throw new Exception("Превышено максимальное количество символов для незвания теста.")
                        : value;
                }
            }

        }
        /// <summary>
        /// Link to the left child.
        /// </summary>
        public TestResult Left { get; set; }
        /// <summary>
        /// Link to the right child.
        /// </summary>
        public TestResult Right { get; set; }

        /// <summary>
        /// Operation "more", comparing student numbers.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>
        /// Returns true when the student number of 
        /// one result is greater than the other.
        /// </returns>
        public static bool operator >(TestResult left, TestResult right)
        {
            if ((left == null) || (right == null))
            {
                return false;
            }

            var result = left.StudentNumber > right.StudentNumber;
            return result;
        }

        /// <summary>
        /// Operation "more", comparing student numbers.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>
        /// Returns true when the student number 
        /// of one result is smaller than the other.
        /// </returns>
        public static bool operator <(TestResult left, TestResult right)
        {
            if (!(left > right))
            {
                var result = left.StudentNumber != right.StudentNumber;
                return result;
            }
            return false;

        }
    }
}
