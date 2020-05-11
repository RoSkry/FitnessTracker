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
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Create new gender
        /// </summary>
        /// <param name="name">Gender name</param>
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
