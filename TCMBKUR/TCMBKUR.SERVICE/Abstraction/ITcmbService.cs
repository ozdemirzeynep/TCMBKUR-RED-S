using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCMB.DATA.Models;
using TCMB.DATA.ViewModels;

namespace TCMBKUR.SERVICE.Abstraction
{
    public interface ITcmbService
    {
        //public int GetDailyCurrencyDataByDate();
        public decimal CurrencyCalculate(RequestViewModel dto);
        public RequestViewModel GetDailyCurrencyDataByDate(RequestViewModel dto);
        Task<string> GetDataFromTCMB(DateTime requestDate);
    }
}
