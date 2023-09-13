using AmeliorateAegis.Models.Teachers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models
{
    [Table("LessonPlans")]
    public class LessonPlan
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "Please select Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = "Please select End Time")]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Required]
        public DayOfWeek Day { get; set; }
        public LessonPlanStatus Status { get; set; }

        [Required]
        public string Description { get; set; }
        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }
        public string TeacherId { get; set; }

        public LessonPlan()
        {
            CreationTime = DateTime.Now;
            Status = LessonPlanStatus.Done;
        }
    }
}
