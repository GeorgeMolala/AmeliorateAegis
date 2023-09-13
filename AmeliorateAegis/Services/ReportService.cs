using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AmeliorateAegis.Data;
using AmeliorateAegis.ViewModels;

namespace AmeliorateAegis.Services
{
    public class ReportService : IReportService
    {
        private readonly RegionalContext _context;
        public ReportService(RegionalContext context)
        {
            _context = context;
        }

        public List<CenterDTO> GetCenterReportData()
        {
            throw new NotImplementedException();
        }
        public BudgetReportDTO GetBudgetReportData(int BudgetID)
        {
            var BudgetReportData = (from rowB in _context.Budget
                                    join rowC in _context.Contract on rowB.BudgetID equals rowC.BudgetID
                                    where rowB.BudgetID == BudgetID
                                    select new BudgetReportDTO
                                    {
                                        BudgetID = rowB.BudgetID,
                                        BudgetDescr = rowB.BudgetDescr,
                                        BudgetAmount  = rowB.BudgetAmount,
                                        BalanceAmount = rowB.BalanceAmount,
                                        Date = rowB.Date,
                                        Contract = new ContractDTO
                                        {
                                            ContractID = rowC.ContractID,
                                            ContractDescr = rowC.ContractDescr,
                                            ContractName = rowC.ContractName,
                                            Date = rowC.Date,
                                            ContractItems = (from rowCI in _context.ContractItems
                                                             where rowCI.ContractID == rowC.ContractID
                                                             select new ContractItemsDTO
                                                             { 
                                                                 ContractItem = rowCI.ContractItem,
                                                                 Date = rowCI.Date,
                                                                 Quantity = rowCI.Quantity,
                                                                 TotalAmount = rowCI.TotalAmount
                                                             }).ToList()
                                        }
                                    }) ;
            return BudgetReportData.FirstOrDefault();
        }
    }
}
    

