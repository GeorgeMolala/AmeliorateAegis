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
using System.Security.Claims;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = SD.Teacher)]
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        public AttendanceController(ApplicationDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            var attendance = await _db.Attendances.Where(x => x.CreationTime.Date == DateTime.Now.Date).ToListAsync();

            // get all pupils
            var pupils = await _db.Pupils.ToListAsync();
            List<PupilAttendanceViewModel> pupilAttendance = new List<PupilAttendanceViewModel>();
            pupils.ForEach(p =>
            {
                var pupil = new PupilAttendanceViewModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    IsAttended = attendance.Find(x => x.PupilId == p.Id) != null

                };
                pupilAttendance.Add(pupil);
            });
            return View(pupilAttendance);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAttendance(bool isChecked, long pupilId)
        {
            if (isChecked)
            {
                var currentAttendance = await _db.Attendances.FirstOrDefaultAsync(x => x.PupilId == pupilId && x.CreationTime.Date == DateTime.Now.Date);
                if (currentAttendance == null)
                {
                    var newRecord = new Attendance
                    {
                        PupilId = pupilId,
                        TeacherId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                    };
                    _db.Add(newRecord);
                    await _db.SaveChangesAsync();
                    _notyf.Success("Updated Successfully", 2);
                    return new JsonResult(new { status = "Success", message = "Updated Successfully" });
                }
            }
            else
            {
                var currentAttendance = await _db.Attendances.FirstOrDefaultAsync(x => x.PupilId == pupilId && x.CreationTime.Date == DateTime.Now.Date);
                if (currentAttendance != null)
                {
                    _db.Remove(currentAttendance);
                    await _db.SaveChangesAsync();
                    _notyf.Success("Updated Successfully", 2);
                    return new JsonResult(new { status = "Success", message = "Updated Successfully" });
                }

            }
            return RedirectToAction(nameof(Attendance));
        }
    }
}
