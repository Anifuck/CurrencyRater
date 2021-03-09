using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyRater.Models
{
    public class ExchangeRateResponseData
    {
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public Dictionary<string, ExchangeRateInfo> Valute { get; set; }
    }
}
