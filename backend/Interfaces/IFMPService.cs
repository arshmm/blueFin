using backend.Dtos.Stock;
using backend.Models;

namespace backend.Interfaces
{
    public interface IFMPService
    {
        Task<Stock?> FindStockBySymbolAsync(string symbol);

        Task<FMPQuote?> GetQuoteAsync(string symbol);

    }
}
