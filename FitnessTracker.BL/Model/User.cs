using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessTracker.BL.Model
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// BirthDate
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        #endregion

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="gender">Gender</param>
        /// <param name="birthDate">BirthDate</param>
        /// <param name="weight">Weight</param>
        /// <param name="height">Height</param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Check conditionals
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty or null", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Gender cannot be null", nameof(gender));
            }
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException("Wrong date of birth", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentNullException("Weihgt cannot be less than 0", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentNullException("Height cannot be less than 0", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("userName cannot be empty", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
