using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.ViewModels
{
    public class AttendanceViewModel
    {
        public IEnumerable<Pupil> Pupils { get; set; }
        public Attendance Attendance { get; set; }
    }
}
