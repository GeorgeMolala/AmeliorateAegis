using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Regional.Models
{
    public class BudgetDto
    {
        public int BudgetID { get; set; }
        public string BudgetDescr { get; set; }
        public int RegionalID { get; set; }
    }
}
