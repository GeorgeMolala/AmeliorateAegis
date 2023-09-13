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

namespace AmeliorateAegis.Areas.Manager.Controllers
{
    [Area("Manager")]

    [Authorize(Roles = SD.RegionalManager)]
    public class DashboardController : Controller
    {
        //private readonly ApplicationDbContext _db;
        //private readonly INotyfService _notyf;
        //public DashboardController(ApplicationDbContext db, INotyfService notyf)
        //{
        //    _db = db;
        //    _notyf = notyf;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    //var pupils = await _db.Pupils.OrderByDescending(x => x.CreationTime).Take(8).ToListAsync();
            
        //    //var dashboardVM = new DashboardVModel
        //    //{
               
        //    //    Pupils = pupils,
        //    //    PupilCount = await _db.Pupils.CountAsync(),
        //    //    ParentCount = await _db.Parents.CountAsync(),
        //    //    LessonCount = await _db.LessonPlans.CountAsync()
               
        //    //};
           
         
        //    return View(dashboardVM);
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
