using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyRater.Models.DomainModels
{
    public class ValuteInfo
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public ValuteInfo(string name, long nominal, decimal value)
        {
            Name = name;
            Value = value / nominal;
        }
    }
}
