using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models
{
    public class JobTypeInformation
    {
        //(see 3 Setting up app until Add Employee stored procedure, 2021) and (see ASP.NET Core Crash Course - C# App in One Hour, 2020) showed how to make these set and get methods

        [Required]
        public string JobTypeName { get; set; }

        [Required]
        public decimal DailyRate { get; set; }

        public string DailyRateString { get; set; }

        public void setDailyRateString (decimal rate) 
        {
            DailyRateString = rate.ToString();
        }

    }
}
