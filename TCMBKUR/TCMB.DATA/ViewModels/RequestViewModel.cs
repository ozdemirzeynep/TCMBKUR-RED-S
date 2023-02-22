using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TCMB.DATA.ViewModels
{
    public class RequestViewModel
    {
        public decimal Lira { get; set; }
        public DateTime Tarih { get; set; }
        public string KurKodu { get; set; }
        public string SelectedCurrencyId { get; set; }
        public IEnumerable<SelectListItem> Currencies { get; set; }
    }
}
