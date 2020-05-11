using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessTracker.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using FitnessTracker.BL.Model;

namespace FitnessTracker.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);

            //act 
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            //assert
            Assert.AreEqual(userName,controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // arrange
            var userName = Guid.NewGuid().ToString();

            //act 
            var controller = new UserController(userName);

            //asert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}
