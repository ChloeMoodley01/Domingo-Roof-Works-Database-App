using DomingoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Controllers
{
    //(4. Continuation and close off, 2021) and (Dot Net Tutorials, 2021). 
    public class EmployeeController : Controller
    {
        EmployeeDAL empDAL = new EmployeeDAL();

        public IActionResult Index()
        {
            List<EmployeeInformation> empInfo = new List<EmployeeInformation>();
            empInfo = empDAL.GetAllEmployee().ToList();

            return View(empInfo);
        }

        //create employee
        [HttpGet]       //sends and recieve data between the client and server using the web app
        public IActionResult Create()       //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]      //provides vailadation for any unsafe HTTP
        public IActionResult Create([Bind] EmployeeInformation objEmpInfo)
        {
            if (ModelState.IsValid)
            {
                empDAL.CreateEmployee(objEmpInfo);
                return RedirectToAction("Index");
            }

            return View(objEmpInfo);
        }

        //employee details
        [Route("Employee/Details/{empID}")]
        [HttpGet]
        public IActionResult Details(string empID)
        {
            if (empID == null)
            {
                return NotFound();
            }

            EmployeeInformation empInfo = empDAL.GetEmployeeByID(empID);
            if (empInfo == null)
            {
                return NotFound();
            }
            return View(empInfo);
        }

        //update employee
        [Route("Employee/Update/{empID}")]
        public IActionResult Update(string empID)
        {
            if (empID == null)
            {
                return NotFound();
            }

            EmployeeInformation empInfo = empDAL.GetEmployeeByID(empID);
            if (empInfo == null)
            {
                return NotFound();
            }
            return View(empInfo);
        }

        [Route("Employee/Update/{empID}")]
        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]      //provides vailadation for any unsafe HTTP
        public IActionResult Update(string empID, [Bind] EmployeeInformation objEmpInfo)
        {
            if (empID == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                empDAL.UpdateEmployee(objEmpInfo);
                return RedirectToAction("Index");
            }

            return View(empDAL);
        }

        //delete employee
        [Route("Employee/Delete/{empID}")]
        public IActionResult Delete(string empID)
        {
            if (empID == null)
            {
                return NotFound();
            }

            EmployeeInformation empInfo = empDAL.GetEmployeeByID(empID);

            if (empInfo == null)
            {
                return NotFound();
            }

            return View(empInfo);
        }

        //delete
        [Route("Employee/Delete/{empID}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(string empID)
        {
            empDAL.DeleteEmployee(empID);
            return RedirectToAction("Index");
        }
    }
}
