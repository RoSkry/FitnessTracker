using FitnessTracker.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FitnessTracker.BL.Controller
{
    /// <summary>
    /// Controller user
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User of app
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user">User</param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            //check
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }


        /// <summary>
        /// Get user data
        /// </summary>
        /// <returns>User</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
            }

            // if user wasn't readen ?
        }

        /// <summary>
        /// Save user
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }

    }
}
