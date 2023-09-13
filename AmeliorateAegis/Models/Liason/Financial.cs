using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmeliorateAegis.Models
{
    
    public class Financial
    {
        [Key]
        public int FinancialId { get; set; }
        public string amount { get; set; }
        public string regionCost { get; set; }

        [DataType(DataType.Date)]
        public string Day { get; set; }

        public string centerName { get; set; }

        public string Prov { get; set; }


        [Required]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Please choose regions")]
        public string Region { get; set; }

        public double totalAmount { get; set; }
    }
}
