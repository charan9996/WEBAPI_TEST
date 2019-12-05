using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ContextClass;

namespace EmployeeHelper
{
    /// <summary>
    /// Bussiness Layer Class for Logic
    /// </summary>
    public class EmployeeManager : IEmployeeManager
    {
        private EmployeeContext employeeContext = new EmployeeContext();
        /// <summary>
        /// Returns the List of Employees
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDetails> Getemployees()
        {
            return employeeContext.employeeDetails.ToList();
        }
        /// <summary>
        /// Gets the Employees By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EmployeeDetails GetemployeesByID(int Id)
        {
            EmployeeDetails employeeDetails = employeeContext.employeeDetails.Find(Id);

            return employeeDetails;
            
        }
        /// <summary>
        /// Post the Data into the Database
        /// </summary>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        public bool PostEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            {
                employeeContext.employeeDetails.Add(employeeDetails);
                employeeContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Delete the Employees 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEmployeeDetails (int id)
        {

            try
            {
                EmployeeDetails employeeDetails = employeeContext.employeeDetails.Find(Convert.ToInt32(id));
                employeeContext.employeeDetails.Remove(employeeDetails);
                employeeContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Authenticates based on the details passed to function
        /// </summary>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
       public bool AuthenticationUser(EmployeeDetails employeeDetails)
        {
            var listOfEmployees = employeeContext.employeeDetails.ToList();

            foreach(var list in listOfEmployees)
            {
                if (list.Username == employeeDetails.Username && list.Password== employeeDetails.Password)
                    return true;
            }
            return false;
        }
    }
}
