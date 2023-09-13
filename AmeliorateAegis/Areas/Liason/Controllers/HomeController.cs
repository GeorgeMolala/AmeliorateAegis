using AmeliorateAegis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace AmeliorateAegis.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index(string id)
        {
            return View(viewName: id);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }


    }
}
