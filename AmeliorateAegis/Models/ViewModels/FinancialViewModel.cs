using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.ViewModels
{
    public class FinancialViewModel
    {

        [Required(ErrorMessage = "Please enter Amount")]
        [Display(Name = "Amount")]
        [StringLength(100)]
        public string amount { get; set; }

        [Required(ErrorMessage = "Please enter cost description")]
        [Display(Name = "Cost Description")]
        [StringLength(100)]
        public string regionCost { get; set; }

        [Display(Name = "Center Name")]
        public string centerName { get; set; }

        [Required(ErrorMessage = "Please enter your intials and surname")]
        public string Prov { get; set; }

        [Required(ErrorMessage = "Please add comment")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Please enter region")]
        public string Region { get; set; }

        public double totalAmount { get; set; }

        [DataType(DataType.Date)]
        public string Day { get; set; }
    }
}
