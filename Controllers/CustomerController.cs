using DomingoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Controllers
{
    //(4. Continuation and close off, 2021) and (Dot Net Tutorials, 2021). 
    public class CustomerController : Controller
    {
        CustomerDAL custDAL = new CustomerDAL();    //object to call methods from other models

        //method to show all of the customers information on the web page (get all customer information)
        public IActionResult Index()
        {
            List<CustomerInformation> custInfo = new List<CustomerInformation>();
            custInfo = custDAL.GetAllCustomers().ToList();

            return View(custInfo);
        }

        //create customer
        [HttpGet]       //sends and recieve data between the client and server using the web app
        public IActionResult Create()       //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]      //provides vailadation for any unsafe HTTP
        public IActionResult Create([Bind] CustomerInformation objcustInfo)
        {
            if (ModelState.IsValid)
            {
                custDAL.CreateCustomer(objcustInfo);
                return RedirectToAction("Create", "Job", new { JobController = "" });
            }

            return View(objcustInfo);
        }



        //customer details
        [Route("Customer/Details/{custID}")]
        [HttpGet]
        public IActionResult Details (int? custID)
        {
            if (custID == null)
            {
                return NotFound();
            }

            CustomerInformation custInfo = custDAL.GetCustomerByID(custID);
            if (custInfo == null)
            {
                return NotFound();
            }
            return View(custInfo);
        }

        //update customer
        [Route("Customer/Update/{custID}")]
        public IActionResult Update(int? custID)
        {
            if (custID == null)
            {
                return NotFound();
            }

            CustomerInformation custInfo = custDAL.GetCustomerByID(custID);
            if (custInfo == null)
            {
                return NotFound();
            }
            return View(custInfo);
        }

        [Route("Customer/Update/{custID}")]
        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]      //provides vailadation for any unsafe HTTP
        public IActionResult Update(int? custID, [Bind] CustomerInformation objcustInfo)
        {
            if (custID == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                custDAL.UpdateCustomer(objcustInfo);
                return RedirectToAction("Index");
            }

            return View(custDAL);
        }

        //delete customer
        [Route("Customer/Delete/{custID}")]
        public IActionResult Delete(int? custID)
        {
            if (custID == null)
            {
                return NotFound();
            }

            CustomerInformation custInfo = custDAL.GetCustomerByID(custID);

            if (custInfo == null)
            {
                return NotFound();
            }

            return View(custInfo);
        }

        //delete
        [Route("Customer/Delete/{custID}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCust(int? custID)
        {
            custDAL.DeleteCustomer(custID);
            return RedirectToAction("Index");
        }
    }

}
