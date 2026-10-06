using backend.Dtos.Stock;
using backend.Interfaces;
using backend.Mappers;
using backend.Models;
using Newtonsoft.Json;

namespace backend.Service
{
    public class FMPService : IFMPService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public FMPService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;


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
                    var stock = task[0];
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
