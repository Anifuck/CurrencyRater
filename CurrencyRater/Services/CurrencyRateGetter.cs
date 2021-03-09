using CurrencyRater.Models;
using CurrencyRater.Providers.HttpProvider;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CurrencyRater.Services.CurrencyRateService
{
    public class CurrencyRateGetter : ICurrencyRateGetter
    {
        public IHttpProvider _provider;
        public string exchangeRateUrl = "https://www.cbr-xml-daily.ru/daily_json.js";

        public CurrencyRateGetter(IHttpProvider provider)
        {
            _provider = provider;
        }

        public async Task<ExchangeRateResponseData> GetValutesAsync()
        {
            var exchangeRate = await _provider.GetAsync(exchangeRateUrl);
            var exchangeRateResponseData = JsonConvert.DeserializeObject<ExchangeRateResponseData>(exchangeRate);
            return exchangeRateResponseData;
        }

        public ExchangeRateInfo GetValute(ExchangeRateResponseData exchangeRateResponseData, string key)
        {
            return exchangeRateResponseData.Valute[key];
        }
        
    }
}
