using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AmeliorateAegis.ViewModels
{
    public class VisitorDTO
    {
        
        public int ScheduleVisitID { get; set; }
        [Required(ErrorMessage = "Visit Decription is required")]
        public string VisitDescr { get; set; }
        [Required(ErrorMessage = "Date and Time is required")]
        public DateTime? Date { get; set; }
        //public string Time { get; set; }
        [Required(ErrorMessage = "Duration is required")]
        public string Duration { get; set; }
        [Required(ErrorMessage = "Reason For Visit is required")]
        public string ReasonForVisit { get; set; }
        //public int? RegionalID { get; set; }
    }
}
