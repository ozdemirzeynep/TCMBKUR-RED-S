using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TCMB.DATA.Models;

namespace TCMBKUR.SERVICE.Abstraction
{
    public interface ICurrencyService
    {
        public IEnumerable<SelectListItem> GetCurrencyItems();
    }
}
