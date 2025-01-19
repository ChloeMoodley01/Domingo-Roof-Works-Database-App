using DomingoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Controllers
{
    //(4. Continuation and close off, 2021) and (Dot Net Tutorials, 2021). 
    public class InvoiceController : Controller
    {
        InvoiceDAL inDAL = new InvoiceDAL();

        //get all
        public IActionResult Index()
        {
            List<InvoiceInformation> inInfo = new List<InvoiceInformation>();
            inInfo = inDAL.GetAllInvoice().ToList();

            return View(inInfo);
        }

        //create
        [HttpGet]       //sends and recieve data between the client and server using the web app
        public IActionResult Create()       //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]      //provides vailadation for any unsafe HTTP
        public IActionResult Create([Bind] InvoiceInformation objInInfo)
        {
            if (ModelState.IsValid)
            {
                inDAL.CreateInvoice(objInInfo);
                return RedirectToAction("Index");
            }

            return View(objInInfo);
        }

        //details
        [Route("Invoice/Details/{inID}")]
        [HttpGet]
        public IActionResult Details(int? inID)
        {
            if (inID == null)
            {
                return NotFound();
            }

            List<InvoiceInformation> inInfo = new List<InvoiceInformation>();
            inInfo = inDAL.GetInvoiceByID(inID).ToList();
            if (inInfo == null)
            {
                return NotFound();
            }
            return View(inInfo);
        }


    }
}
