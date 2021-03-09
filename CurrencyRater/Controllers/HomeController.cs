using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CurrencyRater.Models;
using CurrencyRater.Services.CurrencyRateService;
using CurrencyRate.Providers.HttpProvider;
using CurrencyRater.Models.DomainModels;

namespace CurrencyRater.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyRateGetter _currencyRateGetter;
        string[] valutes = new string[] {"USD","EUR","UAH"};

        public HomeController(ICurrencyRateGetter currencyRateGetter)
        {
            _currencyRateGetter = currencyRateGetter;
        }

        public async Task<IActionResult> Index()
        {
            var response = _currencyRateGetter.GetValutesAsync();
            List<ValuteInfo> valutesList = new List<ValuteInfo>();
            foreach (string valute in valutes)
            {
                var v = _currencyRateGetter.GetValute(response.Result, valute);
                valutesList.Add(new ValuteInfo(v.Name, v.Nominal, v.Value));
            }
            return View("Index",valutesList);
        }
    }
}
