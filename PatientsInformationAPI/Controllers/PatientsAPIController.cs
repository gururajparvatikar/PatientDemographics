using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PatientsInformationAPI;

namespace PatientsInformationAPI.Controllers
{
    public class PatientsAPIController : ApiController
    {
        private PatientDataBaseEntities db = new PatientDataBaseEntities();

        // GET api/PatientsAPI
        public IQueryable<PatientsInformation> GetPatients()
        {
            return db.PatientsInformations;
        }
        
        // POST api/PatientsAPI
        [ResponseType(typeof(PatientsInformation))]
        public IHttpActionResult PostPatientsInformation(PatientsInformation patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PatientsInformations.Add(patient);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PatientExists(patient.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = patient.ID }, patient);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientExists(int id)
        {
            return db.Patients.Count(e => e.ID == id) > 0;
        }
    }
}