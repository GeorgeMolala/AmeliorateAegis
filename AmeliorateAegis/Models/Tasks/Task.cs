using AmeliorateAegis.Models.Regionals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Models.Tasks
{
    public class Task
    {
        public int TaskID { get; set; }
        public string TaskDescr { get; set; }

        public virtual ICollection<Manage> Manage { get; set; }

        public Task()
        {
            Manage = new HashSet<Manage>();
        }
    }
}
