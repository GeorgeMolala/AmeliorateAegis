using AmeliorateAegis.Models.ViewModels;
using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdmin)]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var roleVm = new RoleViewModel
            {
                Roles= roles
            };
            return View(roleVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleVM)
        {
            if (roleVM.Input.Name != null && !await _roleManager.RoleExistsAsync(roleVM.Input.Name))
            {
                await _roleManager.CreateAsync(new IdentityRole(roleVM.Input.Name.Trim()));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
