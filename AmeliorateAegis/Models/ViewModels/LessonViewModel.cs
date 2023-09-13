using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.ViewModels
{
    public class LessonViewModel
    {
        public LessonPlan Lesson { get; set; }
        public IEnumerable<LessonPlan> LessonPlans { get; set; } = new List<LessonPlan>();
    }
}
