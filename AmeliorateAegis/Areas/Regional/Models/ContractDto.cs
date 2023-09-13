using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Regional.Models
{
    public class ContractDto
    {
        public int ContractID { get; set; }
        public string ContractDescr { get; set; }
        public string ContractName { get; set; }

        // public virtual ICollection<Budget> Budget { get; set; }
    }
}
