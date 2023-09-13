
using AmeliorateAegis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmeliorateAegis.Services
{
    public interface IReportService
    {
        List<CenterDTO> GetCenterReportData();
        BudgetReportDTO GetBudgetReportData(int BudgetID);
    }
}
