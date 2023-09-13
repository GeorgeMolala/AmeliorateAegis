using AmeliorateAegis.Services;
using AmeliorateAegis.Utility;
using AmeliorateAegis.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Areas.Regional.Controllers
{
    [Area("Regional")]
    [Authorize(Roles = SD.RegionalCoordinator)]
    public class ContractController : Controller
    {
        private readonly IContractService _contractService;
        public ContractController(IContractService contractService)
        {
            _contractService = contractService;
        }

        public IActionResult Contracts()
        {
            var contract = _contractService.List();

            return View(contract);
        }

        [HttpGet]
        public IActionResult AddContract()
        {
            return View(new ContractDTO());
        }

        [HttpPost]
        public IActionResult AddContract(ContractDTO contract)
        {
            var isSuccess = _contractService.AddContract(contract);

            if (isSuccess)
                return Redirect("Contracts");

            return View(contract);
        }

        [HttpGet]
        public IActionResult UpdateContract(int ContractID)
        {
            var model = _contractService.GetContract(ContractID);
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateContract(ContractDTO contract)
        {
            var isSuccess = _contractService.UpdateContract(contract);

            if (isSuccess)
                return Redirect("Contracts");

            return View(contract);
        }

        [HttpDelete]
        public IActionResult DeleteContract(int id)
        {
            try
            {
                var result = _contractService.DeleteContract(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}