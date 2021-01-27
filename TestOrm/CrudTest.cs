using NUnit.Framework;
using Students.Objects;
using Students.WorkWithOrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestOrm
{
    /// <summary>
    /// Class for testing CRUD.
    /// </summary>
    public class CrudTest
    {
        private string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        /// <summary>
        /// The method tests the method add and delete when student.
        /// </summary>
        [Test]
        public void Add_AddStudentToDataBase_AddStudent()
        {
            StudentDbContext studentDBContext = new StudentDbContext(_connectionString);
            var student = new List<Student>()
            {
                new Student()
                {
                    FullName = "Saladuhin Pavel Viktorovich",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1999, 01, 25),
                    GroupId = 1
                }
            };

            studentDBContext.Student.Add(student);

            List<Student> resultList = studentDBContext.Student.GetCollection();
            studentDBContext.Student.Remove(studentDBContext.Student.GetCollection().Last().Id);

            Assert.AreEqual(resultList.Last(), student[0]);
        }

        /// <summary>
        /// The method tests the method add and delete group.
        /// </summary>
        [Test]
        public void Add_AddAndDeleteGroupToDataBase_AddAndDaleteGroup()
        {
            StudentDbContext studentDBContext = new StudentDbContext(_connectionString);
            var group = new List<Group>()
            {
                new Group()
                {
                    Name = "PM-22"
                }
            };

            studentDBContext.Group.Add(group);

            List<Group> resultList = studentDBContext.Group.GetCollection();
            studentDBContext.Group.Remove(studentDBContext.Group.GetCollection().Last().Id);

            Assert.AreEqual(resultList.Last(), group[0]);
        }

        /// <summary>
        /// The method tests the method add and delete educationalSubject.
        /// </summary>
        [Test]
        public void Add_AddAndDeleteEducationalSubjectToDataBase_AddAndDaleteEducationalSubject()
        {
            StudentDbContext studentDBContext = new StudentDbContext(_connectionString);
            var educationalSubject = new List<EducationalSubject>()
            {
                new EducationalSubject()
                {
                    SubjectName = "Drawing",
                    SubjectType = "Exam"
                }
            };

            studentDBContext.EducationalSubject.Add(educationalSubject);

            List<EducationalSubject> resultList = studentDBContext.EducationalSubject.GetCollection();
            studentDBContext.EducationalSubject.Remove(studentDBContext.EducationalSubject.GetCollection().Last().Id);

            Assert.AreEqual(resultList.Last(), educationalSubject[0]);
        }

        /// <summary>
        /// The method tests the method add and delete session.
        /// </summary>
        [Test]
        public void Add_AddAndDeleteSessionToDataBase_AddAndDaleteSession()
        {
            StudentDbContext studentDBContext = new StudentDbContext(_connectionString);
            var session = new List<Session>()
            {
                new Session()
                {
                    SessionNumber = 1,
                    GroupId = 5
                }
            };

            studentDBContext.Session.Add(session);

            List<Session> resultList = studentDBContext.Session.GetCollection();
            studentDBContext.Session.Remove(studentDBContext.Session.GetCollection().Last().Id);

            Assert.AreEqual(resultList.Last(), session[0]);
        }

        /// <summary>
        /// The method tests the method add and delete sessionEducationalSubject.
        /// </summary>
        [Test]
        public void Add_AddAndDeleteSessionEducationalSubjectToDataBase_AddAndDeleteSessionEducationalSubject()
        {
            StudentDbContext studentDBContext = new StudentDbContext(_connectionString);
            var sessionEducationalSubject = new List<SessionEducationalSubject>()
            {
                new SessionEducationalSubject()
                {
                    Date = new DateTime(2020, 08, 15),
                    EducationalSubjectId = 3,
                    SessionId = 4
                }
            };

            studentDBContext.SessionEducationalSubject.Add(sessionEducationalSubject);

            List<SessionEducationalSubject> resultList = studentDBContext.SessionEducationalSubject.GetCollection();
            studentDBContext.SessionEducationalSubject.Remove(studentDBContext.SessionEducationalSubject.GetCollection().Last().Id);

            Assert.AreEqual(resultList.Last(), sessionEducationalSubject[0]);
        }

        /// <summary>
        /// The method tests the method add and delete studentResult.
        /// </summary>
        [Test]
        public void Add_AddAndDeleteStudentResultToDataBase_AddAndDeleteStudentResult()
        {
            StudentDbContext studentDBContext = new StudentDbContext(_connectionString);
            var studentResult = new List<StudentResult>()
            {
                new StudentResult()
                {
                    StudentId = 8,
                    Mark = "10",
                    SessionEducationalSubjectId = 5
                }
            };

            studentDBContext.StudentResult.Add(studentResult);

            List<StudentResult> resultList = studentDBContext.StudentResult.GetCollection();
            studentDBContext.StudentResult.Remove(studentDBContext.StudentResult.GetCollection().Last().Id);

            Assert.AreEqual(resultList.Last(), studentResult[0]);
        }

        /// <summary>
        /// The method tests the method Change.
        /// </summary>
        [Test]
        public void Chenge_Student_StudentChenges()
        {
            StudentDbContext studentDBContext = new StudentDbContext(_connectionString);
            var student = new Student()
            {
                FullName = "Saladuhin Pavel Viktorovich",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 01, 25),
                GroupId = 1
            };

            var newStudent = new Student()
            {
                FullName = "Saladuhina Valentina Olegovna",
                Gender = "Woman",
                DateOfBirth = new DateTime(20, 11, 15),
                GroupId = 2
            };

            studentDBContext.Student.Add(student);
            studentDBContext.Student.Сhange(studentDBContext.Student.GetCollection().Last().Id, newStudent);
            Student result = studentDBContext.Student.GetCollection().Last();
            studentDBContext.Student.Remove(studentDBContext.Student.GetCollection().Last().Id);

            Assert.AreEqual(result, newStudent);
        }

        /// <summary>
        /// The method tests the method Delete object.
        /// </summary>
        [Test]
        public void Delete_DeleteObject_DeleteObject()
        {
            StudentDbContext studentDBContext = new StudentDbContext(_connectionString);
            var student = new Student()
            {
                FullName = "Ukupnik Pavel Viktorovich",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 01, 25),
                GroupId = 1
            };

            studentDBContext.Student.Add(student);

            studentDBContext.Student.Remove(studentDBContext.Student.GetCollection().Last().Id);

            var result = studentDBContext.Student.GetCollection();

            Assert.AreNotEqual(result.Last(), student);
        }
    }
}
