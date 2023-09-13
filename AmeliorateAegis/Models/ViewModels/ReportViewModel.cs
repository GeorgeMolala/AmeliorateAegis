using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.ViewModels
{
    public class ReportViewModel
    {
        public Pupil Pupil { get; set; }
        public IEnumerable<ProgressReport> Term1 { get; set; }
        public IEnumerable<ProgressReport> Term2 { get; set; }
        public IEnumerable<ProgressReport> Term3 { get; set; }
        public IEnumerable<ProgressReport> Term4 { get; set; }
        public double TotalAverage { get; set; }
    }
}
