using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeManagement.ContextClass
{
    /// <summary>
    /// DataBase Context
    /// </summary>
    public class EmployeeContext:DbContext
    {
        public EmployeeContext():base("EmployeeManagement")
        {

        }
        public DbSet<EmployeeDetails> employeeDetails { get; set; }
    }
}