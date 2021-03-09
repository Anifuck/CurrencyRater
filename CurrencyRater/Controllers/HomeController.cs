using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
