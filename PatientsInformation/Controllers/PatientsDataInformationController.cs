using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientsInformation.Controllers
{
    public class PatientsDataInformationController : Controller
    {
        //
        // GET: /PatientsDataInformation/
        public ActionResult Index()
        {

            return View();
        }

        //
        // GET: /PatientsDataInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /PatientsDataInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PatientsDataInformation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PatientsDataInformation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /PatientsDataInformation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /PatientsDataInformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PatientsDataInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
