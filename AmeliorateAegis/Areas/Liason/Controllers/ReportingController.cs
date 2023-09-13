using AmeliorateAegis.Models;
using AmeliorateAegis.Reports;
using AmeliorateAegis.Utility;
using AmeliorateAegis.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmeliorateAegis.Controllers
{
    [Area("Liason")]
    [Authorize(Roles = SD.ProvincialLiason)]
    public class ReportingController : Controller
    {
        private readonly IWebHostEnvironment _oHostEnvironment;
        public ReportingController( IWebHostEnvironment oHostEnvironment)
        {
            _oHostEnvironment = oHostEnvironment;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrintFinancial(int param)
        {
            List<Financial> oFinancials = new List<Financial>();
            for (int i = 1; i <= 10; i++)
            {
                Financial oFinancial = new Financial();
                oFinancial.FinancialId = i;
                oFinancial.centerName = "Life-Hope ECD center" ;
                oFinancial.regionCost = "Learning materials";
                oFinancial.amount = "R15000" ;
                oFinancials.Add(oFinancial);

            }

            FinancialReport rpt = new FinancialReport (_oHostEnvironment);
            return File(rpt.Report(oFinancials), "application/pdf");
        }
    }
}
