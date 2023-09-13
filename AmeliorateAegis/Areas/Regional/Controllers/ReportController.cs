using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmeliorateAegis.Areas.Regional.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using AmeliorateAegis.Services;
using AmeliorateAegis.ViewModels;
using Microsoft.AspNetCore.Authorization;
using AmeliorateAegis.Utility;

namespace AmeliorateAegis.Areas.Regional.Controllers
{
    [Area("Regional")]
    [Authorize(Roles = SD.RegionalCoordinator)]
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;
        private readonly IViewRenderService _viewRenderService;
        private readonly IConverter converter;
        private readonly ICenterService _centerService;
        private readonly IVisitorService _visitorService;
        private readonly IContractService _contractService;

        public ReportController(IReportService reportService, IViewRenderService viewRenderService, IConverter converter, ICenterService centerService, IVisitorService visitorService, IContractService contractService)
        {
            _reportService = reportService;
            _viewRenderService = viewRenderService;
            this.converter = converter;
            _centerService = centerService;
            _visitorService = visitorService;
            _contractService = contractService;

        }
        public IActionResult Reports()
        {
            var report = _reportService.GetCenterReportData();
            //var report2 = _visitorService.GetVisitorReportData();

            return View(report);
        }

        public async Task<IActionResult> DownloadBudgetReport(int BudgetID)
        {
            var data = new BudgetReportDTO(); //_reportService.GetBudgetReportData(BudgetID);
            var result = await _viewRenderService.RenderToStringAsync("Report/ReportPage", data);
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = $"Budget Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = result,
                HeaderSettings = { FontName = "Arial",
                FontSize = 9,
                Right = "Page [page] of [toPage]",
                Line = true },
                LoadSettings = new LoadSettings { BlockLocalFileAccess = false }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            return File(converter.Convert(pdf), "application/pdf");
        }

        public async Task<IActionResult> DownloadCenterReport(int CenterID)
        {
            var data = _centerService.List();
            var result = await _viewRenderService.RenderToStringAsync("Report/CenterReportPage", data);
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = $"Center Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = result,
                HeaderSettings = { FontName = "Arial",
                FontSize = 9,
                Right = "Page [page] of [toPage]",
                Line = true },
                LoadSettings = new LoadSettings { BlockLocalFileAccess = false }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            return File(converter.Convert(pdf), "application/pdf");
        }

        public async Task<IActionResult> DownloadContractReport(int contractID)
        {
            var data = _contractService.GetContract(contractID);
            var result = await _viewRenderService.RenderToStringAsync("Report/ContractReportPage", data);
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = $"Contract"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = result,
                HeaderSettings = { FontName = "Arial",
                FontSize = 9,
                Right = "Page [page] of [toPage]",
                Line = true },
                LoadSettings = new LoadSettings { BlockLocalFileAccess = false }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            return File(converter.Convert(pdf), "application/pdf");
        }
        public async Task<IActionResult> DownloadVisitorReport(int ScheduledVisitID)
        {
            var data = new VisitorDTO(); //_reportService.GetVisitorReportData(ScheduledVisitID);
            var result = await _viewRenderService.RenderToStringAsync("Report/VisitorReportPage", data);
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = $"Scheduled Visit List"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = result,
                HeaderSettings = { FontName = "Arial",
                FontSize = 9,
                Right = "Page [page] of [toPage]",
                Line = true },
                LoadSettings = new LoadSettings { BlockLocalFileAccess = false }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            return File(converter.Convert(pdf), "application/pdf");
        }

    }

}