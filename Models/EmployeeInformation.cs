using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models
{
    //(see 3 Setting up app until Add Employee stored procedure, 2021) and (see ASP.NET Core Crash Course - C# App in One Hour, 2020) showed how to make these set and get methods
    public class EmployeeInformation
    {
        
        public string EmployeeID { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string EmployeeSurname { get; set; }

    }
}
