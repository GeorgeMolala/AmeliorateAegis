using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmeliorateAegis.ViewModels
{
    public class CenterDTO
    {
        public int CenterID { get; set; }
        [Required(ErrorMessage ="Center Code is required")]
        public string CenterCode { get; set; }
        [Required(ErrorMessage = "Center Name is required")]
        public string CenterName { get; set; }
        [Required(ErrorMessage = "Address Line 1 is required")]
        public string Addressline1 { get; set; }
        [Required(ErrorMessage = "Address line 2 is required")]
        public string Addressline2 { get; set; }
        [Required(ErrorMessage = "Suburb is required")]
        public string Suburb { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Province is required")]
        public string Province { get; set; }
    }
}
