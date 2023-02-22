using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TCMB.DATA.Models;
using TCMBKUR.SERVICE.Abstraction;
using System.Xml;
using TCMB.DATA.Context;
using TCMB.DATA.ViewModels;

namespace TCMBKUR.SERVICE.Concrete
{
    public class TcmbService : ITcmbService
    {
        //TODO : httpclient'i burada DI ile al
        private readonly IHttpClientFactory _tcmbClientFactory;
        private readonly DataContext _dataContext;
        private readonly ICacheService _cacheService;

        public TcmbService(DataContext dataContext, IHttpClientFactory tcmbClientFactory, ICacheService cacheService)
        {
            _dataContext = dataContext;
            _tcmbClientFactory = tcmbClientFactory;
            _cacheService = cacheService;
        }

        public decimal CurrencyCalculate(RequestViewModel dto)
        {
            var responseData = new ResponseData();
            decimal result = 0;
            RequestData req = _dataContext.RequestData.FirstOrDefault(x => x.Tarih.Date == dto.Tarih.Date);
            if (req != null)
            {

                var alisKuru = _dataContext.ResponseDataKur.FirstOrDefault(x => x.RequestDataId == req.Id).AlisKuru;
                result = alisKuru * alisKuru;
                return result;

            }
            else
            {
                GetDailyCurrencyDataByDate(dto);
            }
            return result;  //bundan emin değilim.
        }




        public RequestViewModel GetDailyCurrencyDataByDate(RequestViewModel dto)
        {
            RequestData newReq = new RequestData()
            {
                Tarih=dto.Tarih
            };
            _dataContext.RequestData.Add(newReq);  //sorgu yapılan tarihi kaydettik.
            DateTime dateTime = dto.Tarih;
            string newStringDate = dateTime.ToString("MMddyyyy");
            string month = newStringDate.Substring(0, 2);
            string day = newStringDate.Substring(2, 2);
            //string day = "10";
            string year = newStringDate.Substring(4, 4);
            string tcmb = string.Format("http://www.tcmb.gov.tr/kurlar/{2}{1}/{0}{1}{2}.xml", day, month, year);
            XmlDocument doc = new XmlDocument();
            doc.Load(tcmb);
            XmlNodeList nodelist = doc.SelectNodes("Tarih_Date"); // get all <testcase> nodes
            foreach (XmlNode node in nodelist[0].ChildNodes)
            {
                ResponseDataKur kur = new ResponseDataKur();
                kur.Adi = node["Isim"].InnerText; //adı
                kur.Kodu = node.Attributes["Kod"].Value;
                kur.Birimi = byte.Parse(node["Unit"].InnerText); //birimi
                kur.RequestData = newReq;
                _dataContext.ResponseDataKur.Add(kur); //bu tarihe ait kurları dbye kaydettik.
                _cacheService.GetOrAdd("Currencies", () => { return kur; });



            }
            
            _dataContext.SaveChanges();
            
            CurrencyCalculate(dto);
            return dto;
        }

        public async Task<string> GetDataFromTCMB(DateTime requestDate)
        {
            string newStringDate = requestDate.ToString("MMddyyyy");
            string month = newStringDate.Substring(0, 2);
            string day = newStringDate.Substring(2, 2);
            string year = newStringDate.Substring(4, 4);

            var client = _tcmbClientFactory.CreateClient("tcmbClient");
            string result = await client.GetStringAsync(string.Format("{2}{1}/{0}{1}{2}.xml", day, month, year));
            return result;
        }

    }
}
