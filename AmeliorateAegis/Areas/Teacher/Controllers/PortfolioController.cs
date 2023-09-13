using AmeliorateAegis.Data;
using AmeliorateAegis.Models;
using AmeliorateAegis.Models.ViewModels;
using AmeliorateAegis.Utility;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = SD.Teacher)]
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        public PortfolioController(ApplicationDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Pupils.ToListAsync());
        }

        public async Task<IActionResult> ViewPortfolio(long id)
        {
            var pupil = await _db.Pupils.Include(x => x.Reports)
                .ThenInclude(e => e.Program)
                .Include(f => f.Reports)
                .ThenInclude(x => x.Period)
                .SingleOrDefaultAsync(x => x.Id == id);

            //sort progress report by term
            var sortedReports = pupil.Reports.OrderBy(x => x.Period.Name).ToList();
            pupil.Reports = sortedReports;

            PortfolioViewModel modelVM = new PortfolioViewModel()
            {
                Pupil = pupil,
                Periods = _db.Periods.ToList().OrderBy(x => x.Name),
                Programmes = _db.Programmes.ToList()
            };
            return View(modelVM);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolio(PortfolioViewModel modelVM)
        {
            if (ModelState.IsValid)
            {
                var progress = new ProgressReport
                {
                    Mark = modelVM.Progress.Mark,
                    ProgramId = modelVM.Progress.ProgramId,
                    PupilId = modelVM.Progress.PupilId,
                    TeacherId = modelVM.Progress.TeacherId,
                    PeriodId = modelVM.Progress.PeriodId
                };

                var currentItem = await _db.ProgressReports.FirstOrDefaultAsync(x => x.PupilId == progress.PupilId && x.PeriodId == progress.PeriodId && x.ProgramId == progress.ProgramId);
                if (currentItem == null)
                {
                    _db.Add(progress);
                    await _db.SaveChangesAsync();
                }
                else
                {
                    _notyf.Error("Results Already Added For the Selected Programme");
                }
                return RedirectToAction(nameof(ViewPortfolio), new { id = modelVM.Progress.PupilId });
            }
            return View(modelVM);
        }
    }
}
