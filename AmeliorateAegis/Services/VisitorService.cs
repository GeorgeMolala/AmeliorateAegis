using AmeliorateAegis.Data;
using AmeliorateAegis.ExternalModels;
using AmeliorateAegis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmeliorateAegis.Services
{
    public class Visitorservice: IVisitorService
    {
        private readonly ApplicationDbContext _context;
        public Visitorservice(ApplicationDbContext context)
        {
            _context = context;
        }
        //adding
        public bool AddVisitor(VisitorDTO model)
        {
            try
            {
                _context.ScheduleVisits.Add(new Models.Visitors.ScheduleVisit
                {
                    //reactivated the ID
                    Id = model.ScheduleVisitID,
                    VisitDescr = model.VisitDescr,
                    Date = model.Date,
                    //Time = model.Time,
                    Duration = model.Duration,
                    ReasonForVisit = model.ReasonForVisit,
                    //added here and DTO
                    //RegionalID = model.RegionalID,
                });

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //delete
        public bool DeleteVisitor(int ScheduleVisitID)
        {
            var visitor = _context.ScheduleVisits.Find(ScheduleVisitID);

            if (visitor == null)
                throw new KeyNotFoundException($"Visit with ID: {ScheduleVisitID} was not found.");

            _context.ScheduleVisits.Remove(visitor);
            return _context.SaveChanges() > 0;
        }

        public VisitorDTO GetVisitor(int ScheduleVisitID)
        {

            var visitor = _context.ScheduleVisits.Find(ScheduleVisitID);

            if (visitor == null)
                throw new KeyNotFoundException($"Visit with ID: {ScheduleVisitID} was not found.");


            VisitorDTO model = new VisitorDTO
            {
                ScheduleVisitID = visitor.Id,
                VisitDescr = visitor.VisitDescr,
                Date = visitor.Date,
                //Time = visitor.Time,
                Duration = visitor.Duration,
                ReasonForVisit = visitor.ReasonForVisit,
                //Added  id here
                //RegionalID = visitor.RegionalID,
            };

            return model;
        }
        //update
        public bool UpdateVisitor(VisitorDTO model)
        {
            var visitor = _context.ScheduleVisits.Find(model.ScheduleVisitID);

            if (visitor == null)
                throw new KeyNotFoundException($"Visit with ID: {model.ScheduleVisitID} was not found.");
            
            //visitor.ScheduleVisitID = model.ScheduleVisitID;
            visitor.VisitDescr = model.VisitDescr;
            visitor.Date = model.Date;
            //visitor.Time = model.Time;
            visitor.Duration = model.Duration;
            visitor.ReasonForVisit = model.ReasonForVisit;

            return _context.SaveChanges() > 0;

        }

        public List<VisitorDTO> List()
        {
            return _context.ScheduleVisits.Select(v => new VisitorDTO
            {
                ScheduleVisitID = v.Id,
                VisitDescr = v.VisitDescr,
                Date = v.Date,
                //Time = v.Time,
                Duration = v.Duration,
                ReasonForVisit = v.ReasonForVisit                
            }).ToList();
        }

        public List<VisitorDTO> ListByDate(int ScheduleVisitID)
        {
            throw new NotImplementedException();
        }

        public List<VisitorDTO> ListByRegionalManger(int regionalID)
        {
            throw new NotImplementedException();
        }

    }
}
