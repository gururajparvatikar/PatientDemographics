using PatientsInformationAPI.Models;
using PatientsInformationAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PatientsInformationAPI.Controllers
{
    public class PatientDataInformationController : Controller
    {
        readonly IPatientRepository repository;
 
        //inject dependency
       public PatientDataInformationController(IPatientRepository repository)
        {
            this.repository = repository; 
        }
        //
        // GET: /PatientDataInformation/
        public ActionResult Index()
        {            
            var patients = repository.GetAll();            
            return View(patients);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(PatientDataModel student)
        {
            if(!ModelState.IsValid)
            {
                return View(student);
            }            
            
            var data = repository.Add(student);

            if(data == null)
            {
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View(student);
            }
            return RedirectToAction("Index");
        }
	}
}