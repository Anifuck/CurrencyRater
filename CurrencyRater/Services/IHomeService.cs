using CurrencyRater.Models.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrencyRater.Services
{
    public interface IHomeService
    {
        public Task<List<ValuteInfo>> GetActualRateAsync();
    }
}
