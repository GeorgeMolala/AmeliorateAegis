using AmeliorateAegis.Models.Regionals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.Visitors
{
    public class ScheduleVisit
    {
        [Key]
        public int Id { get; set; }
        public string VisitDescr { get; set; }
        public DateTime? Date { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string ReasonForVisit { get; set; }
        [ForeignKey(nameof(RegionalId))]
        public RegionalCoordinator Regional { get; set; }
        public string? RegionalId { get; set; }
    }
}
