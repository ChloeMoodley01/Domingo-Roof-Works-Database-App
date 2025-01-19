using DomingoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Controllers
{
    //(4. Continuation and close off, 2021) and (Dot Net Tutorials, 2021). 
    public class JobTypeController : Controller
    {
        JobTypeDAL jtDAL = new JobTypeDAL();

        public IActionResult Index()
        {
            List<JobTypeInformation> jobTypeInfo = new List<JobTypeInformation>();
            jobTypeInfo = jtDAL.GetAllJobType().ToList();

            return View(jobTypeInfo);
        }

        //update
        [Route("JobType/Update/{jobTypeID}")]
        public IActionResult Update(string jobTypeID)
        {
            if (jobTypeID == null)
            {
                return NotFound();
            }

            JobTypeInformation jobTypeInfo = jtDAL.GetJobTypeByID(jobTypeID);
            if (jobTypeInfo == null)
            {
                return NotFound();
            }
            return View(jobTypeInfo);
        }

        [Route("JobType/Update/{jobTypeID}")]
        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]      //provides vailadation for any unsafe HTTP
        public IActionResult Update(string jobTypeID, [Bind] JobTypeInformation objJobTypeInfo)
        {
            if (jobTypeID == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                jtDAL.UpdateJobType(objJobTypeInfo);
                return RedirectToAction("Index");
            }

            return View(jtDAL);
        }
    }
}
