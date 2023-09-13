using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models
{

    [Table("Periods")]
    public class Period
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }

        public Period()
        {
            CreationTime = DateTime.Now;
        }
    }
}
