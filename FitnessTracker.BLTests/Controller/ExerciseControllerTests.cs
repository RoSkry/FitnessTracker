using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessTracker.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using FitnessTracker.BL.Model;
using System.Linq;

namespace FitnessTracker.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //arrange 
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName, rnd.Next(50, 100));
            // act 
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //assert
            Assert.AreEqual(activityName, exerciseController.Activities.First().Name);
        }
    }
}