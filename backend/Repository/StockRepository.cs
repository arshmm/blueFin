using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.Stock;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _db;
        public StockRepository(ApplicationDBContext context)
        {
            _db = context;
        }
        public Task<List<Stock>> GetAllAsync()
        {
            return _db.Stocks.ToListAsync();


        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _db.Stocks.FindAsync(id);
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _db.Stocks.AddAsync(stock);
            await _db.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stock)
        {
            var stockModel = await _db.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            stockModel.Symbol = stock.Symbol;
            stockModel.CompanyName = stock.CompanyName;
            stockModel.Purchase = stock.Purchase;
            stockModel.lastDividend = stock.lastDividend;
            stockModel.Industry = stock.Industry;
            stockModel.marketCap = stock.marketCap;

            await _db.SaveChangesAsync();

            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _db.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stockModel == null)
            {
                return null;
            }

            _db.Stocks.Remove(stockModel);
            await _db.SaveChangesAsync();

            return stockModel;
        }

    }
}