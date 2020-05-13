using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        /// <summary>
        /// Create new gender
        /// </summary>
        /// <param name="name">Gender name</param>
        /// 
        public Gender()
        {

        }
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null");
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
