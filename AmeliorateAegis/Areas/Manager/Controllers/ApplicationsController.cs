using AmeliorateAegis.Areas.Parent.Models;
using AmeliorateAegis.Data;
using AmeliorateAegis.Models.Applications;
using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Manager.Controllers
{
    [Area("Manager")]

    [Authorize(Roles = SD.RegionalManager)]
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var applications = await _db.Applications
                .Include(x => x.Pupil)
                .Include(x => x.Centre)
                .ToListAsync();
            return View(applications);
        }
        //Create application
        public IActionResult Create()
        {
            ViewData["CentreId"] = new SelectList(_db.Centres, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationInput application)
        {
            if (ModelState.IsValid)
            {
                var pupilInput = application.Pupil;
                pupilInput.CentreId = application.CentreId;
                pupilInput.ParentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var pupil = await _db.Pupils.AddAsync(pupilInput);

                await _db.SaveChangesAsync();

                var input = new Application
                {
                    CentreId = application.CentreId,
                    PupilId = pupil.Entity.Id,
                    ParentId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    Status = ApplicationStatus.PENDING
                };
                _db.Add(input);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CentreId"] = new SelectList(_db.Centres, "Id", "Name", application.CentreId);
            return View(application);
        }

        public async Task<IActionResult> View(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _db.Applications
                .Include(x => x.Pupil)
                .Include(x => x.Centre)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            ViewData["CentreId"] = new SelectList(_db.Centres, "Id", "Name");
            return View(application);
        }

        // POST: Parent/Applications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(long? Id, Application application)
        {
            if (Id != application.Id)
            {
                return NotFound();
            }
            var applicationFromDb = await _db.Applications.FirstOrDefaultAsync(x => x.Id == Id);
            if (applicationFromDb != null)
            {
                applicationFromDb.Status = ApplicationStatus.ACCEPTED;
                _db.Applications.Update(applicationFromDb);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(View));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decline(long? Id, Application application)
        {
            if (Id != application.Id)
            {
                return NotFound();
            }
            var applicationFromDb = await _db.Applications.FirstOrDefaultAsync(x => x.Id == Id);
            if (applicationFromDb != null)
            {
                applicationFromDb.Status = ApplicationStatus.REJECTED;
                _db.Applications.Update(applicationFromDb);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(View));
        }
    }
}
