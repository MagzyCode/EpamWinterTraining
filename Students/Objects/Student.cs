using Orm.Creators;
using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
    /// <summary>
    /// Class describes the Student.
    /// </summary>
    public class Student : BaseModel, IStudent
    {
        /// <summary>
        /// The constructor initializes the Session object.
        /// </summary>
        /// <param name="fullName">Fullname.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="dateofBirth">Date of Birth.</param>
        /// <param name="groupId">Group id.</param>
        public Student(string fullName, string gender, DateTime dateofBirth, int groupId)
        {
            FullName = fullName;
            Gender = gender;
            DateOfBirth = dateofBirth;
            GroupId = groupId;
        }

        /// <summary>
        /// The empty constructor initializes the Student object for fabric method.
        /// </summary>
        public Student()
        {
        }

        /// <summary>
        /// The property stores information about FullName.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The property stores information about Gender.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// The property stores information about DateOfBirth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The property stores information about Group object.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// The property stores information about GroupId.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString() => $"FullName: {FullName}\t Gender: {Gender}\tDateOfBirth: {DateOfBirth.ToShortDateString()}";

        /// <summary>
        /// Method equals two objects.
        /// </summary>
        /// <param name="obj">Equals object.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public override bool Equals(object obj) => obj is Student student &&
                   FullName == student.FullName &&
                   Gender == student.Gender &&
                   DateOfBirth == student.DateOfBirth &&
                   GroupId == student.GroupId;

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() => HashCode.Combine(FullName, Gender, DateOfBirth, GroupId);
    }
}
