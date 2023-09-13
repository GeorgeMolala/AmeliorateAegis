using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.Parents
{
    public class Parent : ApplicationUser
    {
        public DateTime DoB { get; set; }
        public ICollection<Pupil> Pupils { get; set; }
    }
}
