using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AmeliorateAegis.ViewModels
{
    public class BudgetDTO
    {
        public int BudgetID { get; set; }
        public string BudgetDescr { get; set; }
        public int RegionalID { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public DateTime Date { get; set; }
    }
}
