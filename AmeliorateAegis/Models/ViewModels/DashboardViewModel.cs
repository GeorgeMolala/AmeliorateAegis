using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.ViewModels
{
    public class DashboardVModel
    {
        public IEnumerable<Pupil> Pupils { get; set; } = new List<Pupil>();
        public int PupilCount { get; set; }
        public int ParentCount { get; set; }
        public int LessonCount { get; set; }
    }
}
