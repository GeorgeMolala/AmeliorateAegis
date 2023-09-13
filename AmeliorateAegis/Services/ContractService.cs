
using AmeliorateAegis.Data;
using AmeliorateAegis.ExternalModels;
using AmeliorateAegis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmeliorateAegis.Services
{
    public class ContractService : IContractService
    {
        private readonly RegionalContext _context;
        public ContractService(RegionalContext context)
        {
            _context = context;
        }
        public bool AddContract(ContractDTO model)
        {
            try
            {
                _context.Contract.Add(new Contract
                {
                    ContractID = model.ContractID,
                    ContractDescr = model.ContractDescr,
                    
                    ContractName = model.ContractName

                });

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteContract(int ContractID)
        {
            var contract = _context.Contract.Find(ContractID);

            if (contract == null)
                throw new KeyNotFoundException($"Contract with ID: {ContractID} was not found.");

            _context.Contract.Remove(contract);
            return _context.SaveChanges() > 0;
        }
        public ContractDTO GetContract(int ContractID)
        {

            var contract = _context.Contract.Find(ContractID);

            if (contract == null)
                throw new KeyNotFoundException($"Contract with ID: {ContractID} was not found.");


            ContractDTO model = new ContractDTO
            {
                ContractID = contract.ContractID,
                ContractDescr = contract.ContractDescr,
                ContractName = contract.ContractName
               
            };
            return model;
        }


        public List<ContractDTO> List()
        {
            return _context.Contract.Select(c => new ContractDTO
            {
                ContractID = c.ContractID,
                ContractDescr = c.ContractDescr,
                ContractName = c.ContractName
                
            }).ToList();
        }
        public List<ContractDTO> ListByCenter(int centerID)
        {
            throw new NotImplementedException();
        }
        public bool UpdateContract(ContractDTO model)
        {
            var contract = _context.Contract.Find(model.ContractID);

            if (contract == null)
                throw new KeyNotFoundException($"Contract with ID: {model.ContractID} was not found.");

            contract.ContractID = model.ContractID;
            contract.ContractDescr = model.ContractDescr;
            contract.ContractName = model.ContractName;
          
            return _context.SaveChanges() > 0;

        }
    }
}
