using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.ViewModels
{
    public class PortfolioViewModel
    {
        public Pupil Pupil { get; set; }
        public IEnumerable<Programme> Programmes { get; set; } = new List<Programme>();
        public IEnumerable<Period> Periods { get; set; } = new List<Period>();
        public ProgressReport Progress { get; set; }
    }
}
