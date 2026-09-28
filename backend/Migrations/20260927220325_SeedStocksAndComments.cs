using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedStocksAndComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Industry", "Purchase", "Symbol", "lastDividend", "marketCap" },
                values: new object[,]
                {
                    { 1, "Apple Inc.", "Consumer Electronics", 227.50m, "AAPL", 1.00m, 3450000000000L },
                    { 2, "Microsoft Corporation", "Software - Infrastructure", 428.10m, "MSFT", 3.32m, 3180000000000L },
                    { 3, "NVIDIA Corporation", "Semiconductors", 135.40m, "NVDA", 0.04m, 3320000000000L },
                    { 4, "Tesla, Inc.", "Auto - Manufacturers", 248.90m, "TSLA", 0.00m, 795000000000L },
                    { 5, "Amazon.com, Inc.", "Specialty Retail", 196.20m, "AMZN", 0.00m, 2060000000000L },
                    { 6, "JPMorgan Chase & Co.", "Banks - Diversified", 238.60m, "JPM", 5.00m, 672000000000L },
                    { 7, "The Coca-Cola Company", "Beverages - Non-Alcoholic", 62.80m, "KO", 1.94m, 270000000000L },
                    { 8, "Costco Wholesale Corporation", "Discount Stores", 905.30m, "COST", 4.64m, 401000000000L }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "StockId", "Title" },
                values: new object[,]
                {
                    { 1, "App Store and iCloud revenue make the margins look great.", new DateTime(2025, 1, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), 1, "Services keep growing" },
                    { 2, "Waiting for a pullback before adding more.", new DateTime(2025, 1, 12, 14, 5, 0, 0, DateTimeKind.Unspecified), 1, "Pricey right now" },
                    { 3, "Cloud growth plus Copilot upsell looks solid.", new DateTime(2025, 1, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, "Azure is the story" },
                    { 4, "Data center revenue is carrying everything.", new DateTime(2025, 1, 18, 16, 45, 0, 0, DateTimeKind.Unspecified), 3, "AI demand" },
                    { 5, "Big swings around earnings, size positions carefully.", new DateTime(2025, 1, 20, 10, 20, 0, 0, DateTimeKind.Unspecified), 3, "Volatile" },
                    { 6, "Price cuts are hurting auto gross margin.", new DateTime(2025, 1, 22, 13, 10, 0, 0, DateTimeKind.Unspecified), 4, "Margins under pressure" },
                    { 7, "Two high-margin engines under a retail business.", new DateTime(2025, 1, 25, 8, 55, 0, 0, DateTimeKind.Unspecified), 5, "AWS + ads" },
                    { 8, "Strong capital position and a reliable dividend.", new DateTime(2025, 1, 28, 15, 30, 0, 0, DateTimeKind.Unspecified), 6, "Best-run bank" },
                    { 9, "60+ years of dividend increases, boring in a good way.", new DateTime(2025, 2, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 7, "Dividend king" },
                    { 10, "Renewal rates above 90% make revenue very predictable.", new DateTime(2025, 2, 3, 17, 15, 0, 0, DateTimeKind.Unspecified), 8, "Membership model" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
