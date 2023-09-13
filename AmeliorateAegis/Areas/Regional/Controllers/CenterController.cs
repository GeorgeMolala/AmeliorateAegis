using AmeliorateAegis.Services;
using AmeliorateAegis.Utility;
using AmeliorateAegis.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Regional.Controllers
{
    [Area("Regional")]
    [Authorize(Roles = SD.RegionalCoordinator)]
    public class CenterController : Controller
    {
        private readonly ICenterService _centerService;
        public CenterController(ICenterService centerService)
        {
            _centerService = centerService;
        }

        public IActionResult Centers()
        {
            var center = _centerService.List();

            return View(center);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new CenterDTO());
        }

        [HttpPost]
        public IActionResult Add(CenterDTO center)
        {
            var isSuccess = _centerService.AddCenter(center);

            if (isSuccess)
                return Redirect("Centers");

            return View(center);
        }

        [HttpGet]
        public IActionResult UpdateCenter(int CenterID)
        {
            var model = _centerService.GetCenter(CenterID);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateCenter(CenterDTO center)
        {
            var isSuccess = _centerService.UpdateCenter(center);

            if (isSuccess)
                return Redirect("Centers");

            return View(center);
        }

        [HttpDelete]
        public IActionResult DeleteCenter(int id)
        {
            try
            {
                var result = _centerService.DeleteCenter(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
