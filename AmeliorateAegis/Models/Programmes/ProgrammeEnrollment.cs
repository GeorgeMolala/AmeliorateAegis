using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models
{
    [Table("Pro_Enrollments")]
    public class ProgrammeEnrollment
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        [ForeignKey(nameof(PupilId))]
        public Pupil Pupil { get; set; }
        public long PupilId { get; set; }
        [ForeignKey(nameof(ProgrammeId))]
        public Programme Programme { get; set; }
        public long ProgrammeId { get; set; }
        public ProgrammeEnrollment()
        {
            CreationTime = DateTime.Now;
        }
    }
}
