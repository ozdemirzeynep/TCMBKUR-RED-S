using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TCMB.DATA.Models;
using TCMB.DATA.ViewModels;
using TCMBKUR.SERVICE.Abstraction;
using TCMBKUR.WEB.Models;


namespace TCMBKUR.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IUserRepository _userRepository;
        private readonly ITcmbService _tcmbService;
        private readonly ICurrencyService _currencyService;

        public HomeController(ILogger<HomeController> logger, ITcmbService tcmbService, ICurrencyService currencyService)
        {
            _logger = logger;
            _tcmbService = tcmbService;
            _currencyService = currencyService;
        }

        public IActionResult Index(RequestViewModel dto)
        {
            //ViewBag.tl = model.Tl;
            _tcmbService.CurrencyCalculate(dto);

            //_tcmbService.CurrencyCalculate(req);


            return View();
            //RequestData req = new RequestData()
            //{
            //    Tarih = DateTime.Now,
            //};  
            //_tcmbService.CurrencyCalculate(req);
            //return View(req);
        }

        public async Task<IActionResult> Privacy()
        {
            string result = await _tcmbService.GetDataFromTCMB(new DateTime(2022, 11, 14));
            return Ok(result);
        }


        public IActionResult GetCurrency()
        {
            var result = _currencyService.GetCurrencyItems();
            return new JsonResult(result);
        }

        public  IActionResult GetResultCalculate(RequestViewModel dto)
        {
            decimal result =  _tcmbService.CurrencyCalculate(dto);
            return Ok(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
