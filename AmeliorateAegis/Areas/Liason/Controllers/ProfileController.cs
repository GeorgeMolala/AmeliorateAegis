using AmeliorateAegis.Data;
using AmeliorateAegis.Models;
using AmeliorateAegis.Utility;
using AmeliorateAegis.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Controllers
{
    [Area("Liason")]
    [Authorize(Roles = SD.ProvincialLiason)]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProfileController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            dbContext = context;
            webHostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var profile = await dbContext.Profiles.ToListAsync();
            return View(profile);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Profile profile = new Profile

                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FullNames = model.FirstName + " " + model.LastName,
                    Occupation = model.Occupation,
                    DOB = model.DOB,
                    PhoneNo = model.PhoneNo,
                    PhysicalAddress = model.PhysicalAddress,
                    ProfilePicture = uniqueFileName,

                };
                dbContext.Add(profile);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(ProfileViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
