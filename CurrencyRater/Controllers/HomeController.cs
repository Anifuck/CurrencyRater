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
using CurrencyRater.Enums;

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
            var response = await  _currencyRateGetter.GetValutesAsync();
            List<ValuteInfo> valutesList = new List<ValuteInfo>();
            foreach (Valute valute in Enum.GetValues(typeof(Valute)))
            {
                var v = _currencyRateGetter.GetValute(response, valute);
                valutesList.Add(new ValuteInfo(v.Name, v.Nominal, v.Value));
            }
            return View(valutesList);
        }
    }
}
