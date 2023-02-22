using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCMB.DATA.Models
{
    public class ResponseData
    {
        public int Id { get; set; }
        public List<ResponseDataKur> Data { get; set; }
        public string Hata { get; set; }
    }
}
