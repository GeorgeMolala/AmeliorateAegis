using AmeliorateAegis.Data;
using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Manager.Controllers
{
    [Area("Manager")]

    [Authorize(Roles = SD.RegionalManager)]
    public class RegionsController : Controller
    {
        private readonly ApplicationDbContext IdentityDbContext;

        public RegionsController(ApplicationDbContext context)
        {
            IdentityDbContext = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            return View(await IdentityDbContext.Centres.ToListAsync());

        }
        public IActionResult Add()
        {

            return View();
        }

        // POST: Region,centree/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Name,Code,AddressLine1,AddressLine2,Surbub,City,Province,CreationTime")] Models.Centre a)
        {

            if (ModelState.IsValid)
            {
                IdentityDbContext.Add(a);
                await IdentityDbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

        }
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
                return NotFound();
            var centres = await IdentityDbContext.Centre.FindAsync(id);
            if (centres == null)
            {
                return NotFound();
            }
            ViewData["CentreId"] = new SelectList(IdentityDbContext.Centres, "Id", "Id", Program.CentreId);

            return View(centres);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Models.Centre a)
        {
            //a.Choice = "Active";
            if (id != a.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    IdentityDbContext.Update(a);
                    await IdentityDbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentreExists(((int)a.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Add));
            }
            return View(a);
        }

        private bool CentreExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}
