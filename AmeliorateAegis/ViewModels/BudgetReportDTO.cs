using System;
using System.Collections.Generic;
using System.Text;

namespace AmeliorateAegis.ViewModels
{
    public class BudgetReportDTO
    {
        public int BudgetID { get; set; }
        public string BudgetDescr { get; set; }
        public int RegionalID { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public DateTime Date { get; set; }
        public ContractDTO Contract { get; set; }
        
    }
}
