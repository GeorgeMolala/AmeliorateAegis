using AmeliorateAegis.Models.Parents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.Applications
{
    [Table("Applications")]
    public class Application
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModifiedTime { get; set; }

        [ForeignKey(nameof(ParentId))]
        public Parent Parent { get; set; }
        [Required]
        public string ParentId { get; set; }

        [ForeignKey(nameof(PupilId))]
        public Pupil Pupil { get; set; }
        [Required]
        public long PupilId { get; set; }

        [ForeignKey(nameof(CentreId))]
        public Centre Centre { get; set; }

        [Required]
        public long CentreId { get; set; }

        [Required]
        public ApplicationStatus Status { get; set; }
        public Application()
        {
            CreationTime = DateTime.Now;
            ModifiedTime = DateTime.Now;
        }
    }
}
