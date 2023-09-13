using AmeliorateAegis.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmeliorateAegis.Services
{
   public interface IContractService
    {
        bool AddContract(ContractDTO model);
        bool UpdateContract(ContractDTO model);
        ContractDTO GetContract(int ContractID);
        bool DeleteContract(int ContractID);

        List<ContractDTO> List();
        List<ContractDTO> ListByCenter(int centerID);
    }
}
