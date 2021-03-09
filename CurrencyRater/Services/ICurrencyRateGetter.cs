using CurrencyRater.Enums;
using CurrencyRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyRater.Services.CurrencyRateService
{
    public interface ICurrencyRateGetter
    {
        public Task<ExchangeRateResponseData> GetValutesAsync();
        public ExchangeRateInfo GetValute(ExchangeRateResponseData exchangeRateResponseData, Valute key);
    }
}
