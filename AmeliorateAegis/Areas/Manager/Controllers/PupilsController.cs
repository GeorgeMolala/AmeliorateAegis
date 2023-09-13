using AmeliorateAegis.Data;
using AmeliorateAegis.Utility;
using AspNetCoreHero.ToastNotification.Abstractions;
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
    public class PupilsController : Controller
    {
        private readonly ApplicationDbContext IdentityDbContext;
        private readonly INotyfService _notyf;
        public PupilsController(ApplicationDbContext context, INotyfService notyf)
        {
            IdentityDbContext = context;
            _notyf = notyf;
        }

        public Models.Pupil m = new Models.Pupil();

        //Get Method to display View
        public async Task<IActionResult> Index()
        {

            return View(await IdentityDbContext.Pupils.ToListAsync());

        }



        // GET: Programme/Create
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["CentreId"] = new SelectList(IdentityDbContext.Centres, "Id", "Name");
            ViewData["ParentsId"] = new SelectList(IdentityDbContext.Parents, "Id", "FirstName");
            ViewData["TeachersId"] = new SelectList(IdentityDbContext.Teachers, "Id", "FirstName");
            return View();
        }

        // POST: Programme/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("FirstName,LastName,DoB,ParentId,CentreId,TeacherId,CreationTime")] Models.Pupil a)
        {
            //ViewData["ParentsId"] = new SelectList(IdentityDbContext.Parents, "Id", "FirstName");
            //ViewData["TeachersId"] = new SelectList(IdentityDbContext.Teachers, "Id", "FirstName");

            if (ModelState.IsValid)
            {
                IdentityDbContext.Add(a);
                await IdentityDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        // GET method: Programme/Edit
        public async Task<IActionResult> Edit(long? id)
        {
            ViewData["CentreId"] = new SelectList(IdentityDbContext.Centres, "Id", "Name");
            ViewData["ParentsId"] = new SelectList(IdentityDbContext.Parents, "Id", "FirstName");
            ViewData["TeachersId"] = new SelectList(IdentityDbContext.Teachers, "Id", "FirstName");
            if (id == null)
                return NotFound();
            var Pupil = await IdentityDbContext.Pupils.FindAsync(id);
            if (Pupil == null)
            {
                return NotFound();
            }
            return View(Pupil);
        }

        // POST method: Programme/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Models.Pupil a, long id)
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
                    if (!PupilExists(((int)a.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Add));
            }
            return View(a);
        }


        //Method : Programme/Details
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var people = await IdentityDbContext.Pupils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (people == null)
            {
                return NotFound();
            }

            return View(people);
        }

        private bool PupilExists(long id)
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
            var pupilFromDb = await IdentityDbContext.Pupils.FirstOrDefaultAsync(k => k.Id == id);
            if (pupilFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            IdentityDbContext.Pupils.Remove(pupilFromDb);
            int v1 = await IdentityDbContext.SaveChangesAsync();
            int v = v1;
            return Json(new { success = true, message = "Successfully Deleted" });
        }

        #endregion
    }
}
