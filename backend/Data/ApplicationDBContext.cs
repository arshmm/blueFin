using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Stock>().HasData(
                new Stock { Id = 1, Symbol = "AAPL", CompanyName = "Apple Inc.", Purchase = 227.50m, lastDividend = 1.00m, Industry = "Consumer Electronics", marketCap = 3450000000000 },
                new Stock { Id = 2, Symbol = "MSFT", CompanyName = "Microsoft Corporation", Purchase = 428.10m, lastDividend = 3.32m, Industry = "Software - Infrastructure", marketCap = 3180000000000 },
                new Stock { Id = 3, Symbol = "NVDA", CompanyName = "NVIDIA Corporation", Purchase = 135.40m, lastDividend = 0.04m, Industry = "Semiconductors", marketCap = 3320000000000 },
                new Stock { Id = 4, Symbol = "TSLA", CompanyName = "Tesla, Inc.", Purchase = 248.90m, lastDividend = 0.00m, Industry = "Auto - Manufacturers", marketCap = 795000000000 },
                new Stock { Id = 5, Symbol = "AMZN", CompanyName = "Amazon.com, Inc.", Purchase = 196.20m, lastDividend = 0.00m, Industry = "Specialty Retail", marketCap = 2060000000000 },
                new Stock { Id = 6, Symbol = "JPM", CompanyName = "JPMorgan Chase & Co.", Purchase = 238.60m, lastDividend = 5.00m, Industry = "Banks - Diversified", marketCap = 672000000000 },
                new Stock { Id = 7, Symbol = "KO", CompanyName = "The Coca-Cola Company", Purchase = 62.80m, lastDividend = 1.94m, Industry = "Beverages - Non-Alcoholic", marketCap = 270000000000 },
                new Stock { Id = 8, Symbol = "COST", CompanyName = "Costco Wholesale Corporation", Purchase = 905.30m, lastDividend = 4.64m, Industry = "Discount Stores", marketCap = 401000000000 }
            );

            builder.Entity<Comment>().HasData(
                new Comment { Id = 1, StockId = 1, Title = "Services keep growing", Content = "App Store and iCloud revenue make the margins look great.", CreatedOn = new DateTime(2025, 1, 10, 9, 30, 0) },
                new Comment { Id = 2, StockId = 1, Title = "Pricey right now", Content = "Waiting for a pullback before adding more.", CreatedOn = new DateTime(2025, 1, 12, 14, 5, 0) },
                new Comment { Id = 3, StockId = 2, Title = "Azure is the story", Content = "Cloud growth plus Copilot upsell looks solid.", CreatedOn = new DateTime(2025, 1, 15, 11, 0, 0) },
                new Comment { Id = 4, StockId = 3, Title = "AI demand", Content = "Data center revenue is carrying everything.", CreatedOn = new DateTime(2025, 1, 18, 16, 45, 0) },
                new Comment { Id = 5, StockId = 3, Title = "Volatile", Content = "Big swings around earnings, size positions carefully.", CreatedOn = new DateTime(2025, 1, 20, 10, 20, 0) },
                new Comment { Id = 6, StockId = 4, Title = "Margins under pressure", Content = "Price cuts are hurting auto gross margin.", CreatedOn = new DateTime(2025, 1, 22, 13, 10, 0) },
                new Comment { Id = 7, StockId = 5, Title = "AWS + ads", Content = "Two high-margin engines under a retail business.", CreatedOn = new DateTime(2025, 1, 25, 8, 55, 0) },
                new Comment { Id = 8, StockId = 6, Title = "Best-run bank", Content = "Strong capital position and a reliable dividend.", CreatedOn = new DateTime(2025, 1, 28, 15, 30, 0) },
                new Comment { Id = 9, StockId = 7, Title = "Dividend king", Content = "60+ years of dividend increases, boring in a good way.", CreatedOn = new DateTime(2025, 2, 1, 12, 0, 0) },
                new Comment { Id = 10, StockId = 8, Title = "Membership model", Content = "Renewal rates above 90% make revenue very predictable.", CreatedOn = new DateTime(2025, 2, 3, 17, 15, 0) }
            );
        }
    }
}