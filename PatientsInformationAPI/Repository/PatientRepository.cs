using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Xml.Serialization;

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
                    var url = HttpContext.Current.Request.Url.AbsoluteUri;
                    string urlSubstring = string.Empty;

                    int index = url.IndexOf("PatientDataInformation");
                    if (index > 0) 
                    { 
                        urlSubstring = url.Substring(0, index); 
                    }
                    else 
                    { 
                        urlSubstring = url; 
                    }

                    client.BaseAddress = new Uri(urlSubstring);

                    //client.BaseAddress = new Uri("http://localhost:39505/api/");
                    //HTTP GET
                    var responseTask = client.GetAsync("api/PatientsAPI");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        //var readTask = result.Content.ReadAsAsync<IList<Models.PatientDataModel>>();
                        var readTask = result.Content.ReadAsAsync<IList<Models.PatientsInformationModel>>();
                        readTask.Wait();

                        //
                        if (readTask.Result != null && readTask.Result.Count > 0)
                        {
                            patients = new List<Models.PatientDataModel>();
                            foreach (var patientsInfo in readTask.Result)
                            {
                                var patientsDataModel = new Models.PatientDataModel();
                                var stringReader = new System.IO.StringReader(patientsInfo.PatientsInformationXML.ToString());
                                var serializer = new XmlSerializer(typeof(Models.PatientDataModel));
                                patientsDataModel = serializer.Deserialize(stringReader) as Models.PatientDataModel;
                                patients.Add(patientsDataModel);
                            }
                        }
                        //patients = readTask.Result;
                        return patients;                        
                        //

                        
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
                    var url = HttpContext.Current.Request.Url.AbsoluteUri;
                    string urlSubstring = string.Empty;

                    int index = url.IndexOf("PatientDataInformation");
                    if (index > 0)
                    {
                        urlSubstring = url.Substring(0, index);
                    }
                    else
                    {
                        urlSubstring = url;
                    }

                    client.BaseAddress = new Uri(urlSubstring);

                    //
                    var stringwriter = new System.IO.StringWriter();
                    var serializer = new XmlSerializer(item.GetType());
                    serializer.Serialize(stringwriter, item);
                    string xmlPatientsData = stringwriter.ToString();
                    var patientsInformationModel = new Models.PatientsInformationModel();
                    patientsInformationModel.PatientsInformationXML = xmlPatientsData;
                    //

                    //HTTP POST
                    //var postTask = client.PostAsJsonAsync<Models.PatientDataModel>("api/PatientsAPI", item);
                    var postTask = client.PostAsJsonAsync<Models.PatientsInformationModel>("api/PatientsAPI", patientsInformationModel);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return item;                        
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