using CurrencyRater.Enums;
using CurrencyRater.Models.DomainModels;
using CurrencyRater.Services.CurrencyRateService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyRater.Services
{
    public class HomeService : IHomeService
    {
        private readonly ICurrencyRateGetter _currencyRateGetter;
        public HomeService(ICurrencyRateGetter currencyRateGetter)
        {
            _currencyRateGetter = currencyRateGetter;
        }
        public async Task<List<ValuteInfo>> GetActualRateAsync()
        {
            var response = await _currencyRateGetter.GetValutesAsync();
            List<ValuteInfo> valutesList = new List<ValuteInfo>();
            foreach (Valute valute in Enum.GetValues(typeof(Valute)))
            {
                var v = _currencyRateGetter.GetValute(response, valute);
                valutesList.Add(new ValuteInfo(v.Name, v.Nominal, v.Value));
            }
            return valutesList;
        }
    }

}
