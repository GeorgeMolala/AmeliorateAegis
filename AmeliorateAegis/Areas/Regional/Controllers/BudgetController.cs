using AmeliorateAegis.Services;
using AmeliorateAegis.Utility;
using AmeliorateAegis.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Regional.Controllers
{
    [Area("Regional")]
    [Authorize(Roles = SD.RegionalCoordinator)]
    public class BudgetController : Controller
    {
        private readonly IBudgetService _budgetService;
        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        public IActionResult Budgets()
        {
            var budget = _budgetService.List();

            return View(budget);
        }
        [HttpGet]
        public IActionResult AddBudget()
        {
            return View(new BudgetDTO());
        }
        [HttpPost]
        public IActionResult AddBudget(BudgetDTO budget)
        {
            var isSuccess = _budgetService.AddBudget(budget);

            if (isSuccess)
                return Redirect("Budgets");

            return View(budget);
        }
        [HttpDelete]
        public IActionResult DeleteBudget(int id)
        {
            try
            {
                var result = _budgetService.DeleteBudget(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
