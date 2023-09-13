using AmeliorateAegis.Areas.Regional.Models;
using AmeliorateAegis.Services;
using AmeliorateAegis.Utility;
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
    public class CentresController : Controller
    {
        //private readonly ICenterService _centreService;

        //public CentresController(ICenterService centreService)
        //{
        //    _centreService = centreService;
        //}
        //public IActionResult List()
        //{
        //    var centre = _centreService.List();

        //    return View(centre);
        //}

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    return View(new CentreDto());
        //}

        //[HttpPost]
        //public IActionResult Add(CentreDto centre)
        //{
        //    var isSuccess = _centreService.AddCenter(centre);

        //    if (isSuccess)
        //        return Redirect("Centers");

        //    return View(centre);
        //}
    }
}
