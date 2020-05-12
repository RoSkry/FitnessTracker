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
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //arrange 
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(5, 500), rnd.Next(5, 500), rnd.Next(5, 500), rnd.Next(5, 500));

            // act 
            eatingController.Add(food, 100);

            //assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}