using Orm.Creators;
using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
    /// <summary>
    /// Class describes the Group.
    /// </summary>
    public class Group : BaseModel, IGroup
    {
        /// <summary>
        /// The constructor initializes the Group object.
        /// </summary>
        /// <param name="name">Group name.</param>
        public Group(string name)
        {
            Name = name;
        }

        /// <summary>
        /// The empty constructor initializes the Group object for fabric method.
        /// </summary>
        public Group()
        {

        }

        /// <summary>
        /// The property stores information about Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString() => $"Group Name: {Name}\t";

        /// <summary>
        /// Method equals two objects.
        /// </summary>
        /// <param name="obj">Equals object.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public override bool Equals(object obj) => obj is Group group && Name == group.Name;

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() => HashCode.Combine(Name);
    }
}
