using System;
using System.Net.Http;
using System.Web.Http;
using EmployeeHelper;
using EmployeeManagement.Controllers;
using EmployeeManagement.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaangementTest
{
    [TestClass]
    public class ManagerTest
    {
       
        EmployeeManager employeeManager = new EmployeeManager();


     
      
 
        [TestMethod]
        public void GetAllManagerDetailsByID()
        {

            //Act
            var result = employeeManager.GetemployeesByID(14);
            //Assert
            Assert.IsNotNull(result);
            int Id = result.Id;
            Assert.AreEqual(14, result.Id);

        }
        [TestMethod]
        public void PostManagerData()
        {
            EmployeeDetails employeeDetails = new EmployeeDetails() { Username = "Myself", Password = "L2", EmailID = "v@gmail.com", DateOfBirth = "29/09/1996", SecurityQuestion = "whom the most", SecurityAnswer = "Her", FullName = "yoyo" };

            var result = employeeManager.PostEmployeeDetails(employeeDetails);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteNotDetails()
        {


            var result = employeeManager.DeleteEmployeeDetails(1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteDetails()
        {
           

            var result = employeeManager.DeleteEmployeeDetails(51);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void AuthWithNotFoundManager()
        {
            EmployeeDetails employeeDetails = new EmployeeDetails() { Username = "charan1111", Password = "Charan111" };

            var result = employeeManager.AuthenticationUser(employeeDetails);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void AuthFoundManager()
        {
            EmployeeDetails employeeDetails = new EmployeeDetails() { Username = "Charan", Password = "Charan" };

            var result = employeeManager.AuthenticationUser(employeeDetails);

            Assert.IsTrue(result);
        }

    }
}
