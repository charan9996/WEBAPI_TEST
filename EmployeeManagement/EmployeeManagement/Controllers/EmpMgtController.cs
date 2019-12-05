using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Routing;
using EmployeeManagement.ContextClass;
using EmployeeManagement.Models;
using EmployeeHelper;

namespace EmployeeManagement.Controllers
{
    /// <summary>
    /// Api Controllers for EmployeeManagement
    /// </summary>
    public class EmpMgtController : ApiController
    {
       // readonly IEmployeeManager employeeManager;
       //// / <summary>
       // /// Constructer for Dependecy Injection
       // /// </summary>
       // public EmpMgtController(IEmployeeManager _employeeManager)
       // {
       //     employeeManager = _employeeManager;
       // }
        private EmployeeManager employeeManager = new EmployeeManager();
        /// <summary>
        /// Get Detials of All Employees
        /// </summary>
        /// <returns></returns>
        // GET: api/EmpMgt
        [HttpGet]
        [Route("api/EmpMgt/getAllEmpDetails")]
        
        public HttpResponseMessage GetemployeeDetails()
        {
           List<EmployeeDetails> employeeDetails= employeeManager.Getemployees();

            if (employeeDetails.Count == 0)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There are no Details in the DataBase");
            else
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new ObjectContent(typeof(List<EmployeeDetails>), employeeDetails, GlobalConfiguration.Configuration.Formatters.JsonFormatter) };

        }
        /// <summary>
        /// Get Employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/EmpMgt/5
        [HttpGet]
        [Route("api/EmpMgt/getByEmpId/{id}")]
        public HttpResponseMessage GetByEmpId(int id)
        {
            EmployeeDetails employeeDetails = employeeManager.GetemployeesByID(id);
            if (employeeDetails == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There are no Details in the DataBase");
            }
            else
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new ObjectContent(typeof(EmployeeDetails), employeeDetails, GlobalConfiguration.Configuration.Formatters.JsonFormatter) };
            }
        }

        
        /// <summary>
        /// Post details into database
        /// </summary>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        // POST: api/EmpMgt
        [HttpPost]
        [Route("api/EmpMgt/addEmp")]
        public HttpResponseMessage PostEmployee(EmployeeDetails employeeDetails)
        {
            if ( ModelState==null ||employeeDetails == null )
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Input data mismatch");
            }
            var employeeResponse=employeeManager.PostEmployeeDetails(employeeDetails);

           if(employeeResponse==false)
            { 

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "There is some issue at server side. Please check the log");
            }
           else 
            {  
                return Request.CreateErrorResponse(HttpStatusCode.Created, "Employee Details Inserted Successfully");
            }

        }
        /// <summary>
        /// Delete an User with specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/EmpMgt/5
        [HttpDelete]
        [Route("api/EmpMgt/deleteEmp/{id}")]
        public HttpResponseMessage DeleteEmployee(int id)
        {

            var employeeDetails = employeeManager.DeleteEmployeeDetails(id);


            if (employeeDetails == false)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No user exits with given id: " + id);

            }

            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Employee data deleted successfully");
            }
        }



        /// <summary>
        /// Controller for Authentication
        /// </summary>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/EmpMgt/checkLogin")]
        public HttpResponseMessage Authentication(EmployeeDetails employeeDetails)
        {
            var authUser = employeeManager.AuthenticationUser(employeeDetails);
            if (authUser == true)
                return Request.CreateResponse(HttpStatusCode.Created, "Employee has authenticated successfully");
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Username and Password");
        }
    }
}