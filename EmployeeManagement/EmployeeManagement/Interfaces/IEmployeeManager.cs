using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeHelper
{
    /// <summary>
    /// Interface for the employee management 
    /// </summary>
   public interface IEmployeeManager
    {
        /// <summary>
        /// Get all the employee details
        /// </summary>
        /// <returns></returns>
        List<EmployeeDetails> Getemployees();

        /// <summary>
        /// Get employee details id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        EmployeeDetails GetemployeesByID(int Id);

        /// <summary>
        /// Add the Employee to Database 
        /// </summary>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        bool PostEmployeeDetails(EmployeeDetails employeeDetails);
        /// <summary>
        /// Delete's the employee with mentioned id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteEmployeeDetails(int id);
        /// <summary>
        /// Authenticates the employee
        /// </summary>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        bool AuthenticationUser(EmployeeDetails employeeDetails);

    }
}
