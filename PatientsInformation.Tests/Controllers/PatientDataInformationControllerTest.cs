using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatientsInformationAPI.Controllers;
using PatientsInformationAPI.Models;
using PatientsInformationAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PatientsInformation.Tests.Controllers
{
    [TestClass]
    public class PatientDataInformationControllerTest
    {
        PatientDataModel patientDataModel1 = null;
        PatientDataModel patientDataModel2 = null;
        PatientDataModel patientDataModel3 = null;
        PatientDataModel patientDataModel4 = null;
        PatientDataModel patientDataModel5 = null;

        List<PatientDataModel> patientDataModels = null;
        InMemoryPatientRepository patientssRepo = null;       
        PatientDataInformationController controller = null;

        public PatientDataInformationControllerTest()
        {
            // Lets create some sample PatientDataModels
            patientDataModel1 = new PatientDataModel { ForeName = "AA", SurName = "BB", Gender = "Male" };
            patientDataModel2 = new PatientDataModel { ForeName = "CC", SurName = "DD", Gender = "Female" };
            patientDataModel3 = new PatientDataModel { ForeName = "EE", SurName = "FF", Gender = "Male" };
            patientDataModel4 = new PatientDataModel { ForeName = "GG", SurName = "HH", Gender = "Female" };
            patientDataModel5 = new PatientDataModel { ForeName = "II", SurName = "JJ", Gender = "Male" };

            patientDataModels = new List<PatientDataModel>
            {
                patientDataModel1,
                patientDataModel2,
                patientDataModel3,
                patientDataModel4
            };

            // Lets create our dummy repository
            patientssRepo = new InMemoryPatientRepository(patientDataModels);

            // Now lets create the PatientDataInformationController object to test and pass our patientDataModels
            controller = new PatientDataInformationController(patientssRepo);
        }

        [TestMethod]
        public void Index()
        {
            // Lets call the action method now
            ViewResult result = controller.Index() as ViewResult;

            // Now lets verify whether the result contains our patient entries or not
            var model = (List<PatientDataModel>)result.ViewData.Model;

            CollectionAssert.Contains(model, patientDataModel1);
            CollectionAssert.Contains(model, patientDataModel2);
            CollectionAssert.Contains(model, patientDataModel3);
            CollectionAssert.Contains(model, patientDataModel4);

            // Uncomment the below line and the test will start failing
            // CollectionAssert.Contains(model, patientDataModel5);
        }

        [TestMethod]
        public void Create()
        {
            // Lets create a valid PatientDataModel object to add into
            PatientDataModel newPatientDataModel = new PatientDataModel { ForeName = "AAA", SurName="BBB", Gender="Male"};

            // Lets call the action method now            
            controller.create(newPatientDataModel);

            // get the list of PatientDataModels
            List<PatientDataModel> patientDataModels = (List<PatientDataModel>)patientssRepo.GetAll();

            CollectionAssert.Contains(patientDataModels, newPatientDataModel);
        }
    }
}
