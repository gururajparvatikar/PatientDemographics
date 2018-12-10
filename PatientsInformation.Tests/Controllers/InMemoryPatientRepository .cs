using PatientsInformationAPI.Models;
using PatientsInformationAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsInformation.Tests.Controllers
{
    class InMemoryPatientRepository : IPatientRepository
    {
        List<PatientDataModel> _db = null;

        public InMemoryPatientRepository(List<PatientDataModel> patientDataModels)
        {
            _db = patientDataModels;           
        }
        
        public IList<PatientDataModel> GetAll()
        {
            return _db.ToList();
        }

        public PatientDataModel Add(PatientDataModel item)
        {
            _db.Add(item);
            return item;
        }
    }
}
