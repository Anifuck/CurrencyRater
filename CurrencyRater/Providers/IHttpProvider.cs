using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyRater.Providers.HttpProvider
{
    public interface IHttpProvider
    {
        Task<string> GetAsync(string url);
    }
}
