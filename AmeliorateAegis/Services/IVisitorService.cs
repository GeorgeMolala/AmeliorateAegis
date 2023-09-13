
using AmeliorateAegis.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmeliorateAegis.Services
{
    public interface IVisitorService
    {
        bool AddVisitor(VisitorDTO model);
        bool UpdateVisitor(VisitorDTO model);
        VisitorDTO GetVisitor(int ScheduleVisitID);
        bool DeleteVisitor(int ScheduleVisitID);

        List<VisitorDTO> List();
        List<VisitorDTO> ListByDate(int ScheduleVisitID);
        List<VisitorDTO> ListByRegionalManger(int regionalID);
    }
}
