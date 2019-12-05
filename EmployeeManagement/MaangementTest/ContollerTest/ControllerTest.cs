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
    public class ControllerTest
    {
        EmpMgtController empMgtController = new EmpMgtController();
        EmployeeManager employeeManager = new EmployeeManager();

       
        [TestMethod]
        public void GetAllDetails()
        {
            empMgtController.Request = new HttpRequestMessage();
            empMgtController.Configuration = new HttpConfiguration();
            //Act
            var result=  empMgtController.GetemployeeDetails();
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode,System.Net.HttpStatusCode.OK);
           
            
        }

        [TestMethod]
        public void PostData()
        {
            EmployeeDetails employeeDetails = new EmployeeDetails() { Id=7,Username="charan",Password="charan",EmailID="abcd@gmail.com",DateOfBirth="12/03/2019",SecurityQuestion="how are you",SecurityAnswer="fine",FullName="SAI charan"};
            empMgtController.Request = new HttpRequestMessage();
            empMgtController.Configuration = new HttpConfiguration();
            var result = empMgtController.PostEmployee(employeeDetails);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.Created);
        }
        


        [TestMethod]
        public void GetEmployyeByID()
        {
           
            empMgtController.Request = new HttpRequestMessage();
            empMgtController.Configuration = new HttpConfiguration();
            var result = empMgtController.GetByEmpId(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void GetEmployyeByID1()
        {

            empMgtController.Request = new HttpRequestMessage();
            empMgtController.Configuration = new HttpConfiguration();
            var result = empMgtController.GetByEmpId(14);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void DeleteEmployeewithNotFound()
        {

            empMgtController.Request = new HttpRequestMessage();
            empMgtController.Configuration = new HttpConfiguration();
            var result = empMgtController.DeleteEmployee(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.NotFound);
        }


        [TestMethod]
        public void DeleteEmployeewithFound()
        {

            empMgtController.Request = new HttpRequestMessage();
            empMgtController.Configuration = new HttpConfiguration();
            var result = empMgtController.DeleteEmployee(50);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        public void AuthWithFound()
        {
            EmployeeDetails employeeDetails = new EmployeeDetails() { Username="Charan",Password="Charan"};
            empMgtController.Request = new HttpRequestMessage();
            empMgtController.Configuration = new HttpConfiguration();
            var result = empMgtController.Authentication(employeeDetails);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.Created);
        }

        [TestMethod]
        public void AuthWithNotFound()
        {
            EmployeeDetails employeeDetails = new EmployeeDetails() { Username = "charan1111", Password = "Charan111" };
            empMgtController.Request = new HttpRequestMessage();
            empMgtController.Configuration = new HttpConfiguration();
            var result = empMgtController.Authentication(employeeDetails);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.StatusCode, System.Net.HttpStatusCode.NotFound);
        }

       
       
       
       
       

    }
}
