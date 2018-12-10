using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientsInformation.Models
{
    public class PatientModelData
    {
        public string ForeName { get; set; }
        public string SurName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string HomeNumber { get; set; }
        public string WorkNumber { get; set; }
        public string MobileNumber { get; set; }
    }
}