using System;
using System.Collections.Generic;
using System.Text;

namespace AmeliorateAegis.ViewModels
{
    public class ContractDTO
    {
        public int ContractID { get; set; }
        public string ContractDescr { get; set; }
        public string ContractName { get; set; }
        public int BudgetID { get; set; }
        public decimal Date { get; set; }
        public List<ContractItemsDTO> ContractItems { get; set; }

        // public virtual ICollection<Budget> Budget { get; set; }
    }
}
