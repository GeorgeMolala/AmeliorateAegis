using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models
{
    public class Meeting
    {
        public int MeetingID { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please select a date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        [Display(Name = "Time")]
        [Required(ErrorMessage = "Please select time")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Display(Name = "Reason")]
        [Required(ErrorMessage = "Please select reason")]
        public string Reason { get; set; }


    }
}
