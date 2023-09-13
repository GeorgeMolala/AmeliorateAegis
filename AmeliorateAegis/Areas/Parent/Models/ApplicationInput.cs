using AmeliorateAegis.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Parent.Models
{
    public class ApplicationInput
    {
        [Display(Name = "Center")]
        [Required]
        public long CentreId { get; set; }

        public Pupil Pupil { get; set; }

    }
}
