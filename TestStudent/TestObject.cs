using NUnit.Framework;
using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestStudent
{
    /// <summary>
    /// Class for testing CRUD.
    /// </summary>
    public class TestObject
    {
        /// <summary>
        /// The method tests the method equal and not equal educationSubject.
        /// </summary>
        /// <param name="subjectName">Subject name.</param>
        /// <param name="subjectType">Subject type.</param>
        /// <param name="isEqual">True ore false.</param>
        [TestCase("Drawing", "Exam", true)]
        [TestCase("Math", "Credit", false)]
        public void Equal_EqualAndNotEqual_EducationSubject(string subjectName, string subjectType, bool isEqual)
        {
            var educationalSubject = new EducationalSubject("Drawing", "Exam");

            var expectedEducationalSubject = new EducationalSubject(subjectName, subjectType);

            if (isEqual)
            {
                Assert.AreEqual(expectedEducationalSubject, educationalSubject);
            }
            else
            {
                Assert.AreNotEqual(expectedEducationalSubject, educationalSubject);
            }
        }

        /// <summary>
        /// The method tests the method equal and not equal group.
        /// </summary>
        /// <param name="Name">Group name.</param>
        /// <param name="isEqual">True ore false.</param>
        [TestCase("IP-11", true)]
        [TestCase("IS-11", false)]
        public void Equal_EqualAndNotEqual_Group(string Name, bool isEqual)
        {
            var group = new Group("IP-11");

            var expectedGroup = new Group(Name);

            if (isEqual)
            {
                Assert.AreEqual(expectedGroup, group);
            }
            else
            {
                Assert.AreNotEqual(expectedGroup, group);
            }
        }

        /// <summary>
        /// The method tests the method equal and not equal session.
        /// </summary>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="groupId">Group id.</param>
        /// <param name="isEqual">True ore false.</param>
        [TestCase(11, 4, true)]
        [TestCase(6, 3, false)]
        public void Equal_EqualAndNotEqual_Session(int sessionNumber, int groupId, bool isEqual)
        {
            var session = new Session(11, 4);

            var expectedSession = new Session(sessionNumber, groupId);

            if (isEqual)
            {
                Assert.AreEqual(expectedSession, session);
            }
            else
            {
                Assert.AreNotEqual(expectedSession, session);
            }
        }

        /// <summary>
        /// The method tests the method equal and not equal sessionEducationalSubject.
        /// </summary>
        /// <param name="educationalSubjectId">Educational subject id.</param>
        /// <param name="sessionId">Session id.</param>
        /// <param name="isEqual">True ore false.</param>
        [TestCase(7, 8, true)]
        [TestCase(6, 3, false)]
        public void Equal_EqualAndNotEqual_SessionEducationalSubject(int educationalSubjectId, int sessionId, bool isEqual)
        {
            var date = new DateTime(2020, 11, 09);
            var sessionEducationalSubject = new SessionEducationalSubject(date, 7, 8);

            var expectedSessionEducationalSubject = new SessionEducationalSubject(date, educationalSubjectId, sessionId);

            if (isEqual)
            {
                Assert.AreEqual(expectedSessionEducationalSubject, sessionEducationalSubject);
            }
            else
            {
                Assert.AreNotEqual(expectedSessionEducationalSubject, sessionEducationalSubject);
            }
        }

        /// <summary>
        /// The method tests the method equal and not equal student.
        /// </summary>
        /// <param name="fullName">Student fullname.</param>
        /// <param name="gender">Student gender</param>
        /// <param name="groupId">Group id.</param>
        /// <param name="isEqual">True ore false.</param>
        [TestCase("Saladuhin Pavel Viktorovich", "Male", 1, true)]
        [TestCase("Konovalov Pavel Viktorovich", "Male", 3, false)]
        public void Equal_EqualAndNotEqual_Student(string fullName, string gender, int groupId, bool isEqual)
        {
            var date = new DateTime(1999, 01, 25);
            var student = new Student("Saladuhin Pavel Viktorovich", "Male", date, 1);

            var expecteStudent = new Student(fullName, gender, date, groupId);

            if (isEqual)
            {
                Assert.AreEqual(expecteStudent, student);
            }
            else
            {
                Assert.AreNotEqual(expecteStudent, student);
            }
        }

        /// <summary>
        /// The method tests the method equal and not equal studentResult.
        /// </summary>
        /// <param name="mark">Mark.</param>
        /// <param name="sessionId">Session Id</param>
        /// <param name="SessionEducationalSubjectId">Session educational subject id.</param>
        /// <param name="isEqual">True ore false.</param>
        [TestCase("6", 5, 10, true)]
        [TestCase("1", 8, 2, false)]
        public void Equal_EqualAndNotEqual_StudentResult(string mark, int sessionId, int SessionEducationalSubjectId, bool isEqual)
        {
            var student = new StudentResult("6", 5, 10);

            var expecteStudent = new StudentResult(mark, sessionId, SessionEducationalSubjectId);

            if (isEqual)
            {
                Assert.AreEqual(expecteStudent, student);
            }
            else
            {
                Assert.AreNotEqual(expecteStudent, student);
            }
        }
    }
}
