using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCMBKUR.WEB.Models
{
    public class RequestDataViewModel
    {
        public decimal Lira { get; set; }
        public string KurKodu { get; set; }
        public DateTime Tarih { get; set; }
    }
}
