using Orm.Creators;
using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
     /// <summary>
    /// Class describes the SessionEducationalSubject.
    /// </summary>
    public class SessionEducationalSubject : BaseModel, ISessionEducationalSubject
    {
        /// <summary>
        /// The constructor initializes the Session object.
        /// </summary>
        /// <param name="date">Exam date.</param>
        /// <param name="educationalSubjectId">Educational Subject id.</param>
        /// <param name="sessionId">Session id.</param>
        public SessionEducationalSubject(DateTime date, int educationalSubjectId, int sessionId)
        {
            Date = date;
            EducationalSubjectId = educationalSubjectId;
            SessionId = sessionId;
        }

        /// <summary>
        /// The empty constructor initializes the SessionEducationalSubject object for fabric method.
        /// </summary>
        public SessionEducationalSubject()
        {
        }

        /// <summary>
        /// The property stores information about EducationalSubjectId.
        /// </summary>
        public int EducationalSubjectId { get; set; }

        /// <summary>
        /// The property stores information about EducationalSubject object.
        /// </summary>
        public EducationalSubject EducationalSubject { get; set; }

        /// <summary>
        /// The property stores information about Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The property stores information about SessionId.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// The property stores information about Session object.
        /// </summary>
        public Session Session { get; set; }

        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString() => $"EducationalSubjectId: {EducationalSubjectId}\t SessionId: {SessionId}\t Date: {Date.ToShortDateString()}";

        /// <summary>
        /// Method equals two objects.
        /// </summary>
        /// <param name="obj">Equals object.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public override bool Equals(object obj) => obj is SessionEducationalSubject subject &&
                   EducationalSubjectId == subject.EducationalSubjectId &&
                   Date == subject.Date &&
                   SessionId == subject.SessionId;

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() => HashCode.Combine(EducationalSubjectId, Date, SessionId);
    }
}
