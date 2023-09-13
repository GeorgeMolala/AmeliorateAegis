using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.Teachers
{
    public class Teacher : ApplicationUser
    {
        public DateTime? DoB { get; set; }
        public string Qualification { get; set; }

        public ICollection<Pupil> Pupils { get; set; }
    }
}
