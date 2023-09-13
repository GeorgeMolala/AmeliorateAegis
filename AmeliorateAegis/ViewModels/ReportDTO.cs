using System;
using System.Collections.Generic;
using System.Text;

namespace AmeliorateAegis.ViewModels
{
    public class ReportDTO
    {
        public int ReportID { get; set; }
        public string ReportDescr { get; set; }
        public DateTime? Date { get; set; }
        //public TimeSpan? Time { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }

        //public virtual ICollection<Manage> Manage { get; set; }
    }
}
