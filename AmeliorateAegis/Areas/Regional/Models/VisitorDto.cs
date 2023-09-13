using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Regional.Models
{
    public class VisitorDto
    {
        public int ScheduleVisitID { get; set; }
        public string VisitDescr { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string ReasonForVisit { get; set; }
    }
}
