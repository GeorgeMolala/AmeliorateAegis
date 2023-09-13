using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models
{
    [Table("Pro_Centres")]
    public class ProgrammeCentre
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public Programme Program { get; set; }
        public long ProgramId { get; set; }
        [ForeignKey(nameof(CentreId))]
        public Centre Centre { get; set; }
        public long CentreId { get; set; }
        public ProgrammeCentre()
        {
            CreationTime = DateTime.Now;
        }
    }
}
