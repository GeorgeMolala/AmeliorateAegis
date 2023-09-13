using AmeliorateAegis.Data;
using AmeliorateAegis.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Manager.Controllers
{
    [Area("Manager")]

    [Authorize(Roles = SD.RegionalManager)]
    public class ParentsController : Controller
    {
        private readonly ApplicationDbContext IdentityDbContext;

        public ParentsController(ApplicationDbContext context)
        {
            IdentityDbContext = context;
        }


        public async Task<IActionResult> IndexAsync()
        {
            return View(await IdentityDbContext.Parents.ToListAsync());

        }
        #region API calls
        [HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    return Json(new { data = await IdentityDbContext.Financials.ToListAsync() });

        //}


        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var pupilFromDb = await IdentityDbContext.Pupils.FirstOrDefaultAsync(k => k.Id == id);
            if (pupilFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            IdentityDbContext.Pupils.Remove(pupilFromDb);
            await IdentityDbContext.SaveChangesAsync();
            return Json(new { success = true, message = "Successfully Deleted" });
        }

        #endregion
    }
}
