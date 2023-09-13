using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AmeliorateAegis.Data;
using AmeliorateAegis.Models;

namespace AmeliorateAegis.Areas.Manager.Controllers
{
    [Area("Manager")]

    [Authorize(Roles = SD.RegionalManager)]
    public class RepportController : Controller
    {
        private readonly ApplicationDbContext IdentityDbContext;

        public RepportController(ApplicationDbContext context)
        {
            IdentityDbContext = context;
        }

        public Models.Programme m = new Models.Programme();
        public Models.Pupil p = new Models.Pupil();
        public Models.Centre c = new Models.Centre();

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List()
        {
            return View(await IdentityDbContext.Pupils.ToListAsync());
        }
        public async Task<IActionResult> Program()
        {
            return View(await IdentityDbContext.Programmes.ToListAsync());
        }
        public async Task<IActionResult> Teacher()
        {
            return View(await IdentityDbContext.Centres.ToListAsync());
        }
        public async Task<IActionResult> Period()
        {
            return View(await IdentityDbContext.Periods.ToListAsync());
        }
        public async Task<IActionResult> Enrollment()
        {
            return View(await IdentityDbContext.ProgramEnrollments.ToListAsync());
        }
        public async Task<IActionResult> Attendance()
        {
            return View(await IdentityDbContext.ProgramCentre.ToListAsync());
        }
        #region API calls
        [HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Json(new { data = await IdentityDbContext.Financials.ToListAsync() });

        //}


        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var pupilFromDb = await IdentityDbContext.Pupils.FirstOrDefaultAsync(k => k.Id == id);
            if (pupilFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            IdentityDbContext.Pupils.Remove(pupilFromDb);
            await IdentityDbContext.SaveChangesAsync();
            return Json(new { success = true, message = "Successfully Deleted" });
        }

        #endregion
    }
}
