
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AmeliorateAegis.Data;
using AmeliorateAegis.ViewModels;
using AmeliorateAegis.ExternalModels;

namespace AmeliorateAegis.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly RegionalContext _context;
        public BudgetService(RegionalContext context)
        {
            _context = context;
        }

        public bool AddBudget(BudgetDTO model)
        {
            try
            {
                _context.Budget.Add(new Budget
                {
                    BudgetID = model.BudgetID,
                    BudgetDescr = model.BudgetDescr,
                    BudgetAmount = model.BudgetAmount,
                    BalanceAmount = model.BalanceAmount,
                    Date = model.Date

                });

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }

           
        }

        public bool DeleteBudget(int BudgetID)
        {
            var budget = _context.Budget.Find(BudgetID);

            if (budget == null)
                throw new KeyNotFoundException($"Budget with ID: {BudgetID} was not found.");

            _context.Budget.Remove(budget);
            return _context.SaveChanges() > 0;
        }

        public BudgetDTO GetBudget(int BudgetID)
        {

            var budget = _context.Budget.Find(BudgetID);

            if (budget == null)
                throw new KeyNotFoundException($"Budget with ID: {BudgetID} was not found.");


            BudgetDTO model = new BudgetDTO
            {
                BudgetID = budget.BudgetID,
                BudgetDescr = budget.BudgetDescr,
                BudgetAmount = budget.BudgetAmount,
                BalanceAmount = budget.BalanceAmount,
                Date = budget.Date
            };

            return model;
        }

        public List<BudgetDTO> List()
        {
            return _context.Budget.Select(b => new BudgetDTO
            {
                BudgetID = b.BudgetID,
                BudgetDescr = b.BudgetDescr,
                BudgetAmount = b.BudgetAmount,
                BalanceAmount = b.BalanceAmount,
                Date = b.Date

            }).ToList();

        }
    }
}
