using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Models
{
	//(see 3 Setting up app until Add Employee stored procedure, 2021) and (see ASP.NET Core Crash Course - C# App in One Hour, 2020) showed how to make these set and get methods
	public class InvoiceInformation
    {
		
		public string JobTypeName { get; set; }


		public decimal DailyRate { get; set; }

		[Required]
		public int CustomerID { get; set; }


		public string CustomerName { get; set; }


		public string CustomerSurname { get; set; }


		public string CustomerAddress { get; set; }

		[Required]
		public string EmployeeID { get; set; }


		public string EmployeeName { get; set; }


		public string EmployeeSurname { get; set; }

		[Required]
		public int JobCardNo { get; set; }

		public int NumOfDays { get; set; }

		[Required]
		public int MaterialsID { get; set; }


		public string MaterialsUsed { get; set; }


		public decimal Subtotal { get; set; }


		public decimal VAT { get; set; }


		public decimal Total { get; set; }

	}
}
