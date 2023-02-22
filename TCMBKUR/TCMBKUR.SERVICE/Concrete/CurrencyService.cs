using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TCMB.DATA.Context;
using TCMBKUR.SERVICE.Abstraction;

namespace TCMBKUR.SERVICE.Concrete
{
    public class CurrencyService: ICurrencyService
    {
        private readonly DataContext _dataContext;
        public CurrencyService(DataContext dataContext)
        {
            _dataContext = dataContext;       
        }



        public IEnumerable<SelectListItem> GetCurrencyItems()
        {
            List<SelectListItem> currencies = _dataContext.Kurlar.AsNoTracking()
             .OrderBy(n => n.Id)
             .Select(n =>
                 new SelectListItem
                 {
                     Value = n.Id.ToString(),
                     Text = n.Name
                 }).ToList();

            return new SelectList(currencies, "Value", "Text");
        }

    }
}
