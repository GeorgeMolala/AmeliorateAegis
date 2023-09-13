using AmeliorateAegis.Data;
using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Parent.Controllers
{
    [Area("Parent")]
    [Authorize(Roles = SD.Parent)]
    public class ChildrenController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ChildrenController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var children = await _db.Pupils
                .Where(x => x.ParentId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                .ToListAsync();

            return View(children);
        }
    }
}
