using backend.Dtos.Stock;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace backend.Service
{
    public class FMPService : IFMPService
    {
        // Quotes are cached briefly so page reloads don't burn the FMP daily quota
        private static readonly TimeSpan QuoteCacheDuration = TimeSpan.FromMinutes(1);

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMemoryCache _cache;
        public FMPService(HttpClient httpClient, IConfiguration configuration, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _config = configuration;
            _cache = cache;


        }

        public async Task<FMPQuote?> GetQuoteAsync(string symbol)
        {
            var cacheKey = $"quote:{symbol.ToUpper()}";
            if (_cache.TryGetValue(cacheKey, out FMPQuote? cached))
            {
                return cached;
            }

            // The free plan only allows /quote for some symbols, but /profile also carries the price
            var quote = await FetchFirstAsync<FMPQuote>("quote", symbol);
            if (quote == null)
            {
                var profile = await FetchFirstAsync<FMPStock>("profile", symbol);
                if (profile != null && profile.price > 0)
                {
                    quote = new FMPQuote
                    {
                        symbol = profile.symbol,
                        name = profile.companyName,
                        price = (decimal)profile.price,
                        change = (decimal)profile.change,
                        changePercentage = (decimal)profile.changePercentage,
                        marketCap = profile.marketCap,
                        volume = profile.volume
                    };
                }
            }

            if (quote != null)
            {
                _cache.Set(cacheKey, quote, QuoteCacheDuration);
            }
            return quote;
        }

        private async Task<T?> FetchFirstAsync<T>(string endpoint, string symbol) where T : class
        {
            try
            {
                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/stable/{endpoint}?symbol={symbol.ToUpper()}&apikey={_config["FMPKey"]}");
                if (!result.IsSuccessStatusCode)
                {
                    return null;
                }

                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T[]>(content)?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching {endpoint} for {symbol}: {ex.Message}");
                return null;
            }
        }
        public async Task<Stock?> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/stable/profile?symbol={symbol.ToUpper()}&apikey={_config["FMPKey"]}");
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock = task?.FirstOrDefault();
                    if (stock == null)
                    {
                        return null;
                    }
                    return stock.ToStockFromFMP();
                }
                return null;
            }
            catch (Exception ex)
            {

                // Log the exception (you can use a logging framework like Serilog, NLog, etc.)
                Console.WriteLine($"Error fetching stock data: {ex.Message}");
                return null;
            }
        }
    }
}
