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
    public class LessonController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly INotyfService _notyf;
        public LessonController(ApplicationDbContext db, INotyfService notyf)
        {
            _db = db;
            _notyf = notyf;
        }

        public async Task<IActionResult> Index()
        {
            var lessonVM = new LessonViewModel
            {
                LessonPlans = await _db.LessonPlans.ToListAsync()
            };
            return View(lessonVM);
        }

        // Lessons
        [HttpPost]
        public async Task<IActionResult> CreateLesson(LessonViewModel lessonVm)
        {
            if (ModelState.IsValid)
            {
                var exists = await _db.LessonPlans.FirstOrDefaultAsync(x => x.Day == lessonVm.Lesson.Day && x.StartTime == lessonVm.Lesson.StartTime);
                if (exists != null)
                {
                    _notyf.Error("There's Already A Lesson Scheduled for the selected time");

                    return new JsonResult(new { status = "Eroro", message = "An Error Occurred" });
                }

                var lesson = new LessonPlan
                {
                    Description = lessonVm.Lesson.Description,
                    TeacherId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    StartTime = lessonVm.Lesson.StartTime,
                    Day = lessonVm.Lesson.Day,
                    EndTime = lessonVm.Lesson.EndTime
                };
                _db.Add(lesson);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index), lessonVm);
        }
    }
}
