using AmeliorateAegis.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmeliorateAegis.Services
{
    public interface ICenterService
    {
        bool AddCenter(CenterDTO model);
        bool UpdateCenter(CenterDTO model);
        CenterDTO GetCenter(int CenterID);
        bool DeleteCenter(int CenterID);

        List<CenterDTO> List();
        List<CenterDTO> ListByCity(int cityID);
        List<CenterDTO> ListByRegionalManger(int regionalID);
    }
}
