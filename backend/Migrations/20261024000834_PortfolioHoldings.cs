using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class PortfolioHoldings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AvgCost",
                table: "Portfolios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchasedOn",
                table: "Portfolios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Shares",
                table: "Portfolios",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "24912af2-fe71-5b9c-ae70-54ce47a06df4", 2 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 428.10m, null, 8m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "24912af2-fe71-5b9c-ae70-54ce47a06df4", 6 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 238.60m, null, 10m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "40fa6713-d2fa-52ac-b193-de5554240488", 1 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 227.50m, null, 15m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "40fa6713-d2fa-52ac-b193-de5554240488", 3 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 135.40m, null, 40m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "40fa6713-d2fa-52ac-b193-de5554240488", 4 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 248.90m, null, 12m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "40fa6713-d2fa-52ac-b193-de5554240488", 5 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 196.20m, null, 20m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", 6 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 238.60m, null, 10m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", 7 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 62.80m, null, 50m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", 8 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 905.30m, null, 4m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "73aaeeb2-7674-5108-a974-9312dcfd454a", 1 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 227.50m, null, 15m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "73aaeeb2-7674-5108-a974-9312dcfd454a", 5 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 196.20m, null, 20m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "73aaeeb2-7674-5108-a974-9312dcfd454a", 8 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 905.30m, null, 4m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "744f4311-22b4-5a24-b0f1-3e985835dda1", 1 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 227.50m, null, 15m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "744f4311-22b4-5a24-b0f1-3e985835dda1", 2 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 428.10m, null, 8m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "744f4311-22b4-5a24-b0f1-3e985835dda1", 3 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 135.40m, null, 40m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "8eb8512f-7564-56e0-80e1-35e8256e1973", 7 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 62.80m, null, 50m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "9b3f00f0-fe42-5221-8fce-8171332a4851", 4 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 248.90m, null, 12m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "9b3f00f0-fe42-5221-8fce-8171332a4851", 5 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 196.20m, null, 20m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "b5683003-fdf4-59cb-b121-048d94b77a9f", 2 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 428.10m, null, 8m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "b5683003-fdf4-59cb-b121-048d94b77a9f", 7 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 62.80m, null, 50m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "b5683003-fdf4-59cb-b121-048d94b77a9f", 8 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 905.30m, null, 4m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "c129d2e4-7e79-5811-a736-66117ca1c8ff", 3 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 135.40m, null, 40m });

            migrationBuilder.UpdateData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "c129d2e4-7e79-5811-a736-66117ca1c8ff", 4 },
                columns: new[] { "AvgCost", "PurchasedOn", "Shares" },
                values: new object[] { 248.90m, null, 12m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgCost",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "PurchasedOn",
                table: "Portfolios");

            migrationBuilder.DropColumn(
                name: "Shares",
                table: "Portfolios");
        }
    }
}
