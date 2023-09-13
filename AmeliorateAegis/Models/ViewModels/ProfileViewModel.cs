using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.ViewModels
{
    public class ProfileViewModel
    {

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullNames { get; set; }

        [Required(ErrorMessage = "Please enter date of birth")]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Please choose Occupation")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Please enter physical address")]
        public string PhysicalAddress { get; set; }


        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }

    }
}
