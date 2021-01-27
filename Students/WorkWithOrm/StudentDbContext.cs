using Orm.Orm;
using Students.Creators.Object;
using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.WorkWithOrm
{
    /// <summary>
    /// Class stores information about StudentDbContext and set relation.
    /// </summary>
    public class StudentDbContext : DbContext
    {
        /// <summary>
        /// The constructor initializes the StudentDbContext.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        public StudentDbContext(string connectionString) : base(connectionString)
        {
            SessionEducationalSubject = CustomDbSet<SessionEducationalSubject>.GetInstance(ConnectionString, "SessionEducationalSubjects", new SessionEducationalSubjectCreator());
            EducationalSubject = CustomDbSet<EducationalSubject>.GetInstance(ConnectionString, "EducationalSubjects", new EducationalSubjectCreator());
            Group = CustomDbSet<Group>.GetInstance(ConnectionString, "Groups", new GroupCreator());
            Session = CustomDbSet<Session>.GetInstance(ConnectionString, "Sessions", new SessionCreator());
            Student = CustomDbSet<Student>.GetInstance(ConnectionString, "Students", new StudentCreator());
            StudentResult = CustomDbSet<StudentResult>.GetInstance(ConnectionString, "StudentResults", new StudentResultCreator());

            SetRelation();
        }

        /// <summary>
        /// The property stores information about CustomDbSet SessionEducationalSubject.
        /// </summary>
        public CustomDbSet<SessionEducationalSubject> SessionEducationalSubject { get; set; }

        /// <summary>
        /// The property stores information about CustomDbSet EducationalSubject.
        /// </summary>
        public CustomDbSet<EducationalSubject> EducationalSubject { get; set; }

        /// <summary>
        /// The property stores information about CustomDbSet Group.
        /// </summary>
        public CustomDbSet<Group> Group { get; set; }

        /// <summary>
        /// The property stores information about CustomDbSet Session.
        /// </summary>
        public CustomDbSet<Session> Session { get; set; }

        /// <summary>
        /// The property stores information about CustomDbSet Student.
        /// </summary>
        public CustomDbSet<Student> Student { get; set; }

        /// <summary>
        /// The property stores information about CustomDbSet StudentResult.
        /// </summary>
        public CustomDbSet<StudentResult> StudentResult { get; set; }

        /// <summary>
        /// The method set relation for propertys.
        /// </summary>
        private void SetRelation()
        {
            Student.Collection = WorkWithOrm.SetRelation.SetStudentRelation(Student.Collection, Group.Collection);

            Session.Collection = WorkWithOrm.SetRelation.SetSessionRelation(Session.Collection, Group.Collection);

            SessionEducationalSubject.Collection = WorkWithOrm.SetRelation.SetSessionEducationalSubjectRelation(
                SessionEducationalSubject.Collection, Session.Collection, EducationalSubject.Collection);

            StudentResult.Collection = WorkWithOrm.SetRelation.SetStudentResultRelation(
                StudentResult.Collection, Student.Collection, SessionEducationalSubject.Collection);
        }
    }
}
