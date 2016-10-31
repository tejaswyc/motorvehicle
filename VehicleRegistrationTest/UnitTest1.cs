using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MotorVehicleRegistration.Controllers;
using Model;
using System.Web.Mvc;
using Microsoft.CSharp.RuntimeBinder;

namespace VehicleRegistrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginTest()
        {
            LoginUserController obj_login = new LoginUserController();
            LoginDetail obj_logDetails = new LoginDetail();
            obj_logDetails.Username = "james@gmail.com";
            obj_logDetails.Password = "jame";
            obj_login.Logins(obj_logDetails);
            var result = obj_login.InvalidLogin() as ViewResult;
            Assert.AreEqual("Invalid Username or Password",result.ViewBag.message);
        }
    }
}
