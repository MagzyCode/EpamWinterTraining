using Students.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.WorkWithOrm
{
    /// <summary>
    /// Class set  relation for objects.
    /// </summary>
    public class SetRelation
    {
        /// <summary>
        /// Method set relation for Session.
        /// </summary>
        /// <param name="sessions">List session objects.</param>
        /// <param name="groups">List group objects.</param>
        /// <returns>List session objects.</returns>
        public static List<Session> SetSessionRelation(List<Session> sessions, List<Group> groups)
        {
            var bindSessions = new List<Session>();
            Session tempSession = null;
            foreach (Session item in sessions)
            {
                tempSession = item;
                tempSession.Group = groups.Where(obj => obj.Id == item.GroupId).Select(item => item).FirstOrDefault();
                bindSessions.Add(tempSession);
            }

            return bindSessions;
        }

        /// <summary>
        /// Method set relation for Student.
        /// </summary>
        /// <param name="students">List student objects.</param>
        /// <param name="groups">List group objects.</param>
        /// <returns>List student objects.</returns>
        public static List<Student> SetStudentRelation(List<Student> students, List<Group> groups)
        {
            var bindStudents = new List<Student>();
            Student tempStudent = null;
            foreach (Student item in students)
            {
                tempStudent = item;
                tempStudent.Group = groups.Where(obj => obj.Id == item.GroupId).Select(item => item).FirstOrDefault();
                bindStudents.Add(tempStudent);
            }

            return bindStudents;
        }

        /// <summary>
        /// Method set relation for StudentResult.
        /// </summary>
        /// <param name="studentResults">List studentResult objects.</param>
        /// <param name="students">List student objects.</param>
        /// <param name="educationalSubjects">List educationalSubject objects.</param>
        /// <returns>List studentResult objects.</returns>
        public static List<StudentResult> SetStudentResultRelation(List<StudentResult> studentResults, List<Student> students, List<SessionEducationalSubject> educationalSubjects)
        {
            var bindStudentResults = new List<StudentResult>();
            StudentResult tempStudentResult = null;
            foreach (StudentResult item in studentResults)
            {
                tempStudentResult = item;
                tempStudentResult.Student = students.Where(obj => obj.Id == item.StudentId).Select(item => item).FirstOrDefault();
                tempStudentResult.SessionEducationalSubject = educationalSubjects.Where(obj => obj.Id == item.SessionEducationalSubjectId).Select(item => item).FirstOrDefault();
                bindStudentResults.Add(tempStudentResult);
            }

            return bindStudentResults;
        }

        /// <summary>
        /// Method set relation for SessionEducationalSubject.
        /// </summary>
        /// <param name="studentResults">List studentResult objects.</param>
        /// <param name="session">List student objects.</param>
        /// <param name="educationalSubject">List educationalSubject objects.</param>
        /// <returns>List sessionEducationalSubject objects.</returns>
        public static List<SessionEducationalSubject> SetSessionEducationalSubjectRelation(List<SessionEducationalSubject> studentResults, List<Session> session, List<EducationalSubject> educationalSubject)
        {
            var bindStudentResults = new List<SessionEducationalSubject>();
            SessionEducationalSubject tempStudentResult = null;
            foreach (SessionEducationalSubject item in studentResults)
            {
                tempStudentResult = item;
                tempStudentResult.Session = session.Where(obj => obj.Id == item.SessionId).Select(item => item).FirstOrDefault();
                tempStudentResult.EducationalSubject = educationalSubject.Where(obj => obj.Id == item.EducationalSubjectId).Select(item => item).FirstOrDefault();
                bindStudentResults.Add(tempStudentResult);
            }

            return bindStudentResults;
        }
    }
}
