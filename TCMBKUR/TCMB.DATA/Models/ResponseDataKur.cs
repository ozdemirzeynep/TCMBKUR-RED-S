using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCMB.DATA.Models
{
    public class ResponseDataKur
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Kodu { get; set; }
        public int? Birimi { get; set; }
        public decimal AlisKuru { get; set; }
        public DateTime Tarih { get; set; }

        //public decimal? SatisKuru { get; set; }
        //public decimal? EfektifAlisKuru { get; set; }
        //public decimal? EfektifSatisKuru { get; set; }
        public int RequestDataId { get; set; }
        public RequestData RequestData { get; set; }

    }
}
