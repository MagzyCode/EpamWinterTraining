using NUnit.Framework;
using Orm.Creators;
using Students.Creators.Object;
using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestStudent
{
    /// <summary>
    /// Class for testing ModelCreator.
    /// </summary>
    public class TestCreators
    {
        /// <summary>
        /// The field stores information about fabric base model creator.
        /// </summary>
        private FabricBaseModel _fabricBaseModel;

        /// <summary>
        /// The method tests the method create EducationalSubject.
        /// </summary>
        [Test]
        public void Create_CreateEducationalSubject_CreateEducationalSubject()
        {
            _fabricBaseModel = new EducationalSubjectCreator();
            var result = _fabricBaseModel.Create();
            EducationalSubject actualResult = new EducationalSubject();

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method create Group.
        /// </summary>
        [Test]
        public void Create_CreateGroupCreator_CreateGroupCreator()
        {
            _fabricBaseModel = new GroupCreator();
            var result = _fabricBaseModel.Create();
            Group actualResult = new Group();

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method create Session.
        /// </summary>
        [Test]
        public void Create_CreateSessionCreator_CreateSessionCreator()
        {
            _fabricBaseModel = new SessionCreator();
            var result = _fabricBaseModel.Create();
            Session actualResult = new Session();

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method create Session.
        /// </summary>
        [Test]
        public void Create_NotCreateSessionCreator_NotCreateSessionCreator()
        {
            _fabricBaseModel = new SessionCreator();
            var result = _fabricBaseModel.Create();
            Group actualResult = new Group();

            Assert.AreNotEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method create SessionEducationalSubject.
        /// </summary>
        [Test]
        public void Create_CreateSessionEducationalSubjectCreator_CreateSessionEducationalSubjectCreator()
        {
            _fabricBaseModel = new SessionEducationalSubjectCreator();
            var result = _fabricBaseModel.Create();
            SessionEducationalSubject actualResult = new SessionEducationalSubject();

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method create Student.
        /// </summary>
        [Test]
        public void Create_CreateStudentCreator_CreateStudentCreator()
        {
            _fabricBaseModel = new StudentCreator();
            var result = _fabricBaseModel.Create();
            Student actualResult = new Student();

            Assert.AreEqual(result, actualResult);
        }

        /// <summary>
        /// The method tests the method create StudentResult.
        /// </summary>
        [Test]
        public void Create_CreateStudentResultCreator_StudentResultCreator()
        {
            _fabricBaseModel = new StudentResultCreator();
            var result = _fabricBaseModel.Create();
            StudentResult actualResult = new StudentResult();

            Assert.AreEqual(result, actualResult);
        }
    }
}
