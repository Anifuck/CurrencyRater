using CurrencyRater.Providers.HttpProvider;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CurrencyRate.Providers.HttpProvider
{
    public class HttpProvider : IHttpProvider
    {
        public async Task<string> GetAsync(string url)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
