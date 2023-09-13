using Microsoft.AspNetCore.Mvc;
using AmeliorateAegis.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics;
using AmeliorateAegis.ViewModels;
using Microsoft.AspNetCore.Hosting;
using AmeliorateAegis.Data;
using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Authorization;

namespace AmeliorateAegis.Controllers
{
    [Area("Liason")]
    [Authorize(Roles = SD.ProvincialLiason)]
    public class FinancialController : Controller
    {

        private readonly ApplicationDbContext IdentityDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public FinancialController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            IdentityDbContext = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> FinancialTable()
        {
            var financial = await IdentityDbContext.Financials.ToListAsync();
            return View(financial);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddFinance()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFinance(FinancialViewModel model)
        {
            if (ModelState.IsValid)
            {

                Financial financial = new Financial
                {
                    amount = model.amount,
                    regionCost = model.regionCost,
                    Day = model.Day,
                    centerName = model.centerName,
                    Prov = model.Prov,
                    Comment = model.Comment,
                    Region = model.Region,
                    totalAmount = model.totalAmount,
                };
                IdentityDbContext.Add(financial);
                await IdentityDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(FinancialTable));
            }
            return View();
        }


        #region API calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await IdentityDbContext.Financials.ToListAsync() });

        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var financialFromDb = await IdentityDbContext.Financials.FirstOrDefaultAsync(k => k.FinancialId == id);
            if (financialFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            IdentityDbContext.Financials.Remove(financialFromDb);
            await IdentityDbContext.SaveChangesAsync();
            return Json(new { success = true, message = "Successfully Deleted" });
        }

        #endregion


    }
}
