using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AmeliorateAegis.Services;
using AmeliorateAegis.ViewModels;
using Microsoft.AspNetCore.Authorization;
using AmeliorateAegis.Utility;

namespace AmeliorateAegis.Areas.Regional.Controllers
{
    [Area("Regional")]
    [Authorize(Roles = SD.RegionalCoordinator)]
    public class VisitorController : Controller
    {
        private readonly IVisitorService _visitorService;
        //private readonly UserManager<IdentityUser> _userManager;
        public VisitorController(IVisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        public IActionResult Visitors()
        {
            var visitor = _visitorService.List();

            return View(visitor);
        }

        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View(new VisitorDTO());
        }

        [HttpPost]
        public IActionResult AddVisitor(VisitorDTO visitor)
        {
            var isSuccess = _visitorService.AddVisitor(visitor);

            if (isSuccess)
                return Redirect("Visitors");

            return View(visitor);
        }
        [HttpGet]
        public IActionResult UpdateVisitor(int ScheduleVisitID)
        {
            var model = _visitorService.GetVisitor(ScheduleVisitID);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateVisitor(VisitorDTO visitor)
        {
            var isSuccess = _visitorService.UpdateVisitor(visitor);

            if (isSuccess)
                return Redirect("Visitors");

            return View(visitor);
        }

        [HttpDelete]
        public IActionResult DeleteVisitor(int id)
        {
            try
            {
                var result = _visitorService.DeleteVisitor(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
