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
using CurrencyRater.Services;

namespace CurrencyRater.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var valutesList = await _homeService.GetActualRateAsync();
            return View(valutesList);
        }
    }
}
