using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using AmeliorateAegis.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using AmeliorateAegis.ViewModels;
using AmeliorateAegis.Data;
using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Authorization;

namespace AmeliorateAegis.Controllers
{
    //[Route("api/[controller]")]
    [Area("Liason")]
    [Authorize(Roles = SD.ProvincialLiason)]
    public class RegionalsController : Controller
    {

        private readonly ApplicationDbContext IdentityDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public RegionalsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            IdentityDbContext = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> RegionalManager()
        {
            var regional = await IdentityDbContext.Regionals.ToListAsync();
            return View(regional);
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(RegionalViewModel model)
        {
            if (ModelState.IsValid)
            {

                Regional regional = new Regional
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                };
                IdentityDbContext.Add(regional);
                await IdentityDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //private readonly ApplicationDbContext _dbContext;

        //[BindProperty]

        //public Regional Regional { get; set; }
        //public RegionalsController(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //public IActionResult RegionalManager()
        //{
        //    return View();
        //}


        //public IActionResult Insert(int? id)
        //{

        //    Regional = new Regional();
        //    if (id == null)
        //    {
        //        //create
        //        return View(Regional);
        //    }

        //    //update
        //    Regional = _dbContext.Regionals.FirstOrDefault(u => u.RegionalId == id);
        //    if (Regional == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(Regional);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Insert()
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (Regional.RegionalId == 0)
        //        {
        //            //create
        //            _dbContext.Regionals.Add(Regional);
        //        }
        //        else
        //        {
        //            _dbContext.Regionals.Update(Regional);
        //        }
        //        _dbContext.SaveChanges();
        //        return RedirectToAction("RegionalManager");
        //    }
        //    return View(Regional);

        //}


        #region API calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await IdentityDbContext.Regionals.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var regionalFromDb = await IdentityDbContext.Regionals.FirstOrDefaultAsync(u => u.RegionalId == id);
            if (regionalFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            IdentityDbContext.Regionals.Remove(regionalFromDb);
            await IdentityDbContext.SaveChangesAsync();
            return Json(new { success = true, message = "Successfully Deleted" });
        }

        #endregion


    }
}
