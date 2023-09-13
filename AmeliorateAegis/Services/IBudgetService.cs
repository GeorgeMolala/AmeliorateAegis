using AmeliorateAegis.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmeliorateAegis.Services
{
    public interface IBudgetService
    {
        bool AddBudget(BudgetDTO model);

        //not updating the budget
        // bool UpdateBudget(BudgetDTO model);
        BudgetDTO GetBudget(int BudgetID);

        bool DeleteBudget(int BudgetID);
        List<BudgetDTO> List();
    } 
}  