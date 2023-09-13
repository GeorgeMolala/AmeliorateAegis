using AmeliorateAegis.Data;
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
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        public ReportsController(ApplicationDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Pupils.ToListAsync());
        }

        public async Task<IActionResult> ViewReport(long id)
        {
            var pupil = await _db.Pupils.Include(x => x.Reports)
                .ThenInclude(e => e.Program)
                .Include(f => f.Reports)
                .ThenInclude(x => x.Period)
                .SingleOrDefaultAsync(x => x.Id == id);

            // Sort Progress According to Term
            var reportVM = new ReportViewModel
            {
                Pupil = pupil,
                Term1 = pupil.Reports.Where(x => x.Period.Name == "Term 1").ToList(),
                Term2 = pupil.Reports.Where(x => x.Period.Name == "Term 2").ToList(),
                Term3 = pupil.Reports.Where(x => x.Period.Name == "Term 3").ToList(),
                Term4 = pupil.Reports.Where(x => x.Period.Name == "Term 4").ToList(),
                TotalAverage = pupil.Reports.Count > 0 ? Math.Round(pupil.Reports.Average(x => x.Mark), 2) : 0
            };
            return View(reportVM);
        }
    }
}
