using System;
using System.Collections.Generic;
using System.Text;

namespace AmeliorateAegis.ViewModels
{
    public class ContractItemsDTO
    {
        public int ContractItemID { get; set; }
        public string ContractItem { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public int ContractID { get; set; }
    }
}
