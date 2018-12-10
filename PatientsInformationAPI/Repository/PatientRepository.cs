using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace PatientsInformationAPI.Repository
{
    public class PatientRepository:IPatientRepository
    {
        public IList<Models.PatientDataModel> GetAll()
        {
            IList<Models.PatientDataModel> patients = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:39505/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("PatientsAPI");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IList<Models.PatientDataModel>>();
                        readTask.Wait();

                        patients = readTask.Result;

                        return patients;
                    }
                    else //web api sent error response 
                    {
                        //log response status here..

                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }            
        }

        public Models.PatientDataModel Add(Models.PatientDataModel item)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:39505/api/");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Models.PatientDataModel>("PatientsAPI", item);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return item;
                        //return RedirectToAction("GetPatientsData");
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }          
        }
    }
}