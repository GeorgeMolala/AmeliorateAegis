using AmeliorateAegis.Data;
using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Manager.Controllers
{
    [Area("Manager")]

    [Authorize(Roles = SD.RegionalManager)]
    public class ProgrammesController : Controller
    {

        private readonly ApplicationDbContext IdentityDbContext;

        public ProgrammesController(ApplicationDbContext context)
        {
            IdentityDbContext = context;
        }

        public Models.Programme m = new Models.Programme();

        //Get Method to display View
        public async Task<IActionResult> Index1(int pg = 1)
        {

            //var Programme = await IdentityDbContext.Programmes.ToListAsync();
            //const int pageSize = 10;
            //if (pg < 1)
            //    pg = 1;
            //int recsCount = Programme.Count();
            //var pager =new Pager( recsCount,pg, pageSize);
            //int recSkip = (pg - 1) * pageSize;

            //var data = Programme.Skip(recSkip).Take(pager.PageSize).ToList();
            //this.ViewBag.Pager = pager;
            //return View(Programme);
            return View(await IdentityDbContext.Programmes.ToListAsync());
            //return View(data);
        }



        // GET: Programme/Create
        [HttpGet]
        public IActionResult AddP()
        {
            return View();
        }

        // POST: Programme/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddP([Bind("Name,Description,Centre,CreationTime")] Models.Programme a)
        {

            if (ModelState.IsValid)
            {
                IdentityDbContext.Add(a);
                await IdentityDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index1));
            }
            return View();

        }

        // GET method: Programme/Edit
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();
            var Programme = await IdentityDbContext.Programmes.FindAsync(id);
            if (Programme == null)
            {
                return NotFound();
            }
            ViewData["CentreId"] = new SelectList(IdentityDbContext.Centres, "Id", "Id", Program.CentreId);

            return View(Programme);
        }

        // POST method: Programme/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Models.Programme a)
        {
            //a.Choice = "Active";
            if (id != a.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    IdentityDbContext.Update(a);
                    await IdentityDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgrammeExists(((int)a.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(AddP));
            }
            return View(a);
        }


        //Method : Programme/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await IdentityDbContext.Programmes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        private bool ProgrammeExists(int id)
        {
            return IdentityDbContext.Programmes.Any(k => k.Id == id);
        }

        //Disposing Method
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                IdentityDbContext.Dispose();
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
            var programFromDb = await IdentityDbContext.Programmes.FirstOrDefaultAsync(k => k.Id == id);
            if (programFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            IdentityDbContext.Programmes.Remove(programFromDb);
            await IdentityDbContext.SaveChangesAsync();
            return Json(new { success = true, message = "Successfully Deleted" });
        }

        #endregion
    }
}
