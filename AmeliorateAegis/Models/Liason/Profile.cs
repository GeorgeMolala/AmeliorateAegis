using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models
{
    public class Profile
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter you birth date")]
        public string DOB { get; set; }

        [Display(Name = "Full Name")]
        public string FullNames { get; set; }

        [Required(ErrorMessage = "Please choose Occupation")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "Please enter physical address")]
        public string PhysicalAddress { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        public string ProfilePicture { get; set; }

        public Profile()
        {
            FullNames = FirstName + " " + LastName;
        }

    }
}
