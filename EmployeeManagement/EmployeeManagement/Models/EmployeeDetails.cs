using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    /// <summary>
    /// Entity Model Of Employee Management
    /// </summary>
    public class EmployeeDetails
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }

        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }



    }
}