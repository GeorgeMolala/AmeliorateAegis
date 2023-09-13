using AmeliorateAegis.Models.Teachers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models
{
    [Table("ProgressReports")]
    public class ProgressReport
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey(nameof(PupilId))]
        public Pupil Pupil { get; set; }
        public long PupilId { get; set; }
        [ForeignKey(nameof(PeriodId))]
        public Period Period { get; set; }
        public long PeriodId { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public Programme Program { get; set; }
        public long ProgramId { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }
        public string TeacherId { get; set; }
        public double Mark { get; set; }
    }
}
