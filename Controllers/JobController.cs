using DomingoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Controllers
{
    //(4. Continuation and close off, 2021) and (Dot Net Tutorials, 2021). 
    public class JobController : Controller
    {
        JobDAL jDAL = new JobDAL();
        public IActionResult Index()
        {
            List<JobInformation> jobInfo = new List<JobInformation>();
            jobInfo = jDAL.GetAllJob().ToList();

            return View(jobInfo);
        }

        //create job card
        [HttpGet]       //sends and recieve data between the client and server using the web app
        public IActionResult Create()       //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]      //provides vailadation for any unsafe HTTP
        public IActionResult Create([Bind] JobInformation objJobInfo)
        {
            if (ModelState.IsValid)
            {
                jDAL.CreateJob(objJobInfo);
                return RedirectToAction("Create", "Materials", new { MaterialsController = "" });
            }

            return View(objJobInfo);
        }

        //details of job
        [Route("Job/Details/{jobID}")]
        [HttpGet]
        public IActionResult Details(int? jobID)
        {
            if (jobID == null)
            {
                return NotFound();
            }

            JobInformation jobInfo = jDAL.GetJobByID(jobID);
            if (jobInfo == null)
            {
                return NotFound();
            }
            return View(jobInfo);
        }

        //update job
        [Route("Job/Update/{jobID}")]
        public IActionResult Update(int? jobID)
        {
            if (jobID == null)
            {
                return NotFound();
            }

            JobInformation jobInfo = jDAL.GetJobByID(jobID);
            if (jobInfo == null)
            {
                return NotFound();
            }
            return View(jobInfo);
        }

        [Route("Job/Update/{jobID}")]
        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]     //provides vailadation for any unsafe HTTP
        public IActionResult Update(int? jobID, [Bind] JobInformation objJobInfo)
        {
            if (jobID == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                jDAL.UpdateJob(objJobInfo);
                return RedirectToAction("Index");
            }

            return View(jDAL);
        }

        //delete job
        [Route("Job/Delete/{jobID}")]
        public IActionResult Delete(int? jobID)
        {
            if (jobID == null)
            {
                return NotFound();
            }

            JobInformation jobInfo = jDAL.GetJobByID(jobID);

            if (jobInfo == null)
            {
                return NotFound();
            }

            return View(jobInfo);
        }

        //delete
        [Route("Job/Delete/{jobID}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteJob(int? jobID)
        {
            jDAL.DeleteJob(jobID);
            return RedirectToAction("Index");
        }


    }
}
