﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace AmeliorateAegis.ExternalModels
{
    public partial class Budget
    {
        public int BudgetID { get; set; }
        public string BudgetDescr { get; set; }
        public int RegionalID { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public DateTime Date { get; set; }
    }
}