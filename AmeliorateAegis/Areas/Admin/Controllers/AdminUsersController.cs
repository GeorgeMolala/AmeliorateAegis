using AmeliorateAegis.Data;
using AmeliorateAegis.Models;
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
    public class AdminUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;

        public AdminUsersController(
            UserManager<ApplicationUser> userManager,
             ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModel = new UserViewModel();

            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.PhoneNumber = user.PhoneNumber;
                thisViewModel.Roles = await GetUserRoles(user);
                userViewModel.Users.Add(thisViewModel);
            }
            userViewModel.Roles = await GetAllRoles();
            return View(userViewModel);
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        private async Task<List<string>> GetAllRoles()
        {
            return new List<string>(await _db.Roles.Select(x => x.Name).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = userVM.Input.Name,
                    LastName = userVM.Input.LastName,
                    PhoneNumber = userVM.Input.PhoneNumber,
                    UserName = userVM.Input.Email,
                    Email = userVM.Input.Email
                };
                var result = await _userManager.CreateAsync(user, userVM.Input.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, userVM.Input.Role);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(nameof(Index), userVM);
        }
    }
}
