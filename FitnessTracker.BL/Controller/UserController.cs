﻿using FitnessTracker.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FitnessTracker.BL.Controller
{
    /// <summary>
    /// Controller user
    /// </summary>
    public class UserController : BaseController
    {
        /// <summary>
        /// Users of app
        /// </summary>
        public List<User> Users { get; }

        public User CurrentUser { get; set; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user">User</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("userName cannot be empty", nameof(userName));
            }
            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }


        /// <summary>
        /// Get list of users
        /// </summary>
        /// <returns>Users</returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            // Check

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Save user
        /// </summary>
        public void Save()
        {
            Save( Users);
        }

    }
}
