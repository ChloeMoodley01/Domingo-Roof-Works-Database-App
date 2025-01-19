using DomingoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomingoApp.Controllers
{
    //(4. Continuation and close off, 2021) and (Dot Net Tutorials, 2021). 
    public class MaterialsController : Controller
    {
        MaterialsDAL matDAL = new MaterialsDAL();

        public IActionResult Index()
        {
            List<MaterialsInformation> matInfo = new List<MaterialsInformation>();
            matInfo = matDAL.GetAllMaterials().ToList();
            return View(matInfo);
        }

        //create
        [HttpGet]       //sends and recieve data between the client and server using the web app
        public IActionResult Create()       //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]      //provides vailadation for any unsafe HTTP
        public IActionResult Create([Bind] MaterialsInformation objMatInfo)
        {
            if (ModelState.IsValid)
            {
                matDAL.CreateMaterials(objMatInfo);
                return RedirectToAction("Create", "Invoice", new { InvoiceController = "" });
            }

            return View(objMatInfo);
        }

        //details
        [Route("Materials/Details/{matID}")]
        [HttpGet]
        public IActionResult Details(int? matID)
        {
            if (matID == null)
            {
                return NotFound();
            }

            MaterialsInformation matInfo = matDAL.GetMaterialsByID(matID);
            if (matInfo == null)
            {
                return NotFound();
            }
            return View(matInfo);
        }

        //update
        [Route("Materials/Update/{matID}")]
        public IActionResult Update(int? matID)
        {
            if (matID == null)
            {
                return NotFound();
            }

            MaterialsInformation matInfo = matDAL.GetMaterialsByID(matID);
            if (matInfo == null)
            {
                return NotFound();
            }
            return View(matInfo);
        }

        [Route("Materials/Update/{matID}")]
        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]      //provides vailadation for any unsafe HTTP
        public IActionResult Update(int? matID, [Bind] MaterialsInformation objMatInfo)
        {
            if (matID == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                matDAL.UpdateMaterials(objMatInfo);
                return RedirectToAction("Index");
            }

            return View(matDAL);
        }

        //delete
        [Route("Materials/Delete/{matID}")]
        public IActionResult Delete(int? matID)
        {
            if (matID == null)
            {
                return NotFound();
            }

            MaterialsInformation matInfo = matDAL.GetMaterialsByID(matID);

            if (matInfo == null)
            {
                return NotFound();
            }

            return View(matInfo);
        }

        [Route("Materials/Delete/{matID}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCust(int? matID)
        {
            matDAL.DeleteMaterials(matID);
            return RedirectToAction("Index");
        }
    }
}
