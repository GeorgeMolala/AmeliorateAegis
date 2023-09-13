
using AmeliorateAegis.Data;
using AmeliorateAegis.ExternalModels;
using AmeliorateAegis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmeliorateAegis.Services
{
    public class CenterService: ICenterService
    {
        private readonly RegionalContext _context;
        public CenterService(RegionalContext context)
        {
            _context = context;
        }

        public bool AddCenter(CenterDTO model)
        {
            try
            {
                _context.Center.Add(new Center
                {
                    CenterID = model.CenterID,
                    CenterCode = model.CenterCode,
                    CenterName = model.CenterName,
                    Addressline1 = model.Addressline1,
                    Addressline2 = model.Addressline2,
                    City = model.City,
                    Province = model.Province,
                    Suburb = model.Suburb

                });

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCenter(int CenterID)
        {
            var center = _context.Center.Find(CenterID);

            if (center == null)
                throw new KeyNotFoundException($"Center with ID: {CenterID} was not found.");

            _context.Center.Remove(center);
            return _context.SaveChanges() > 0;

            //  var center = _context.Center.Find(CenterID);
            // If(center != null)
            // _context.Center.Remove(center);



        }

        public CenterDTO GetCenter(int CenterID)
        {

            var center = _context.Center.Find(CenterID);

            if (center == null)
                throw new KeyNotFoundException($"Center with ID: {CenterID} was not found.");


            CenterDTO model = new CenterDTO
            {
                CenterID = center.CenterID,
                CenterCode = center.CenterCode,
                CenterName = center.CenterName,
                Addressline1 = center.Addressline1,
                Addressline2 = center.Addressline2,
                City = center.City,
                Province = center.Province,
                Suburb = center.Suburb
            };

            return model;
        }

        public List<CenterDTO> List()
        {
            return _context.Center.Select(s => new CenterDTO
            {
                CenterCode = s.CenterCode,
                CenterID = s.CenterID,
                CenterName = s.CenterName,
                Addressline1 = s.Addressline1,
                Addressline2 = s.Addressline2,
                City = s.City,
                Province = s.Province,
                Suburb = s.Suburb
            }).ToList();
        }

        public List<CenterDTO> ListByCity(int cityID)
        {
            throw new NotImplementedException();
        }

        public List<CenterDTO> ListByRegionalManger(int regionalID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCenter(CenterDTO model)
        {
            var center = _context.Center.Find(model.CenterID);

            if (center == null)
                throw new KeyNotFoundException($"Center with ID: {model.CenterID} was not found.");

            center.CenterCode = model.CenterCode;
            center.CenterName = model.CenterName;
            center.Addressline1 = model.Addressline1;
            center.Addressline2 = model.Addressline2;
            center.City = model.City;
            center.Province = model.Province;
            center.Suburb = model.Suburb;
            return _context.SaveChanges() > 0;

        }
    }
}
