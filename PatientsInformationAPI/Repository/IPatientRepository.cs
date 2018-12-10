using PatientsInformationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientsInformationAPI.Repository
{
    public interface IPatientRepository
    {
        IList<Models.PatientDataModel> GetAll();
        PatientDataModel Add(PatientDataModel item);
    }
}
