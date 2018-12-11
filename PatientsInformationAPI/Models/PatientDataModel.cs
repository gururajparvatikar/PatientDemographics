using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PatientsInformationAPI.Models
{
    public class PatientDataModel
    {
        [Display(Name = "Forename")]
        [Required(ErrorMessage = "Forename required")]
        [MaxLength(50, ErrorMessage = "Forename: Maximum 50 chars")]
        [MinLength(3, ErrorMessage = "Forename: Minimum 3 chars")]
        public string ForeName { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Surname required")]
        [MaxLength(50, ErrorMessage = "Surname: Maximum 50 chars")]
        [MinLength(2, ErrorMessage = "Surname: Minimum 2 chars")]
        public string SurName { get; set; }

        [Display(Name = "Date of birth")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[/](0[1-9]|1[012])[/]\d{4}$",
            ErrorMessage = "Date of Birth should be in dd/mm/yyyy format")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender required")]
        public string Gender { get; set; }

        [Display(Name = "Home Number")]
        [MaxLength(50, ErrorMessage = "HomeNumber: Maximum 50 chars")]
        public string HomeNumber { get; set; }

        [Display(Name = "Work Number")]
        [MaxLength(50, ErrorMessage = "WorkNumber: Maximum 50 chars")]
        public string WorkNumber { get; set; }

        [Display(Name = "Mobile Number")]
        [MaxLength(50, ErrorMessage = "MobileNumber: Maximum 50 chars")]
        public string MobileNumber { get; set; }
    }
}