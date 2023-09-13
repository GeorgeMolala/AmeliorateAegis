using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Public.Controllers
{
    [Area("Public")]
    public class CentresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
