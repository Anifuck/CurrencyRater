using CurrencyRater.Enums;
using CurrencyRater.Models;
using CurrencyRater.Providers.HttpProvider;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CurrencyRater.Services.CurrencyRateService
{
    public class CurrencyRateGetter : ICurrencyRateGetter
    {
        public IHttpProvider _provider;
        private readonly IConfiguration _configuration;

        public CurrencyRateGetter(IHttpProvider provider, IConfiguration configuration)
        {
            _provider = provider;
            _configuration = configuration;
        }

        public async Task<ExchangeRateResponseData> GetValutesAsync()
        {
            string exchangeRateUrl = _configuration["ExchangeRateUrl"];
            var exchangeRate = await _provider.GetAsync(exchangeRateUrl);
            var exchangeRateResponseData = JsonConvert.DeserializeObject<ExchangeRateResponseData>(exchangeRate);
            return exchangeRateResponseData;
        }

        public ExchangeRateInfo GetValute(ExchangeRateResponseData exchangeRateResponseData, Valute key)
        {
            var valuteKey = key.ToString("G");
            return exchangeRateResponseData.Valute[valuteKey];
        }
        
    }
}
