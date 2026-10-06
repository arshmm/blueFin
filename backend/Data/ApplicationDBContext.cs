using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

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
                new Comment { Id = 1, StockId = 1, AppUserId = "744f4311-22b4-5a24-b0f1-3e985835dda1", Title = "Services keep growing", Content = "App Store and iCloud revenue make the margins look great.", CreatedOn = new DateTime(2025, 1, 10, 9, 30, 0) }, // investor111
                new Comment { Id = 2, StockId = 1, AppUserId = "40fa6713-d2fa-52ac-b193-de5554240488", Title = "Pricey right now", Content = "Waiting for a pullback before adding more.", CreatedOn = new DateTime(2025, 1, 12, 14, 5, 0) }, // investor444
                new Comment { Id = 3, StockId = 2, AppUserId = "24912af2-fe71-5b9c-ae70-54ce47a06df4", Title = "Azure is the story", Content = "Cloud growth plus Copilot upsell looks solid.", CreatedOn = new DateTime(2025, 1, 15, 11, 0, 0) }, // investor666
                new Comment { Id = 4, StockId = 3, AppUserId = "c129d2e4-7e79-5811-a736-66117ca1c8ff", Title = "AI demand", Content = "Data center revenue is carrying everything.", CreatedOn = new DateTime(2025, 1, 18, 16, 45, 0) }, // investor777
                new Comment { Id = 5, StockId = 3, AppUserId = "744f4311-22b4-5a24-b0f1-3e985835dda1", Title = "Volatile", Content = "Big swings around earnings, size positions carefully.", CreatedOn = new DateTime(2025, 1, 20, 10, 20, 0) }, // investor111
                new Comment { Id = 6, StockId = 4, AppUserId = "9b3f00f0-fe42-5221-8fce-8171332a4851", Title = "Margins under pressure", Content = "Price cuts are hurting auto gross margin.", CreatedOn = new DateTime(2025, 1, 22, 13, 10, 0) }, // investor222
                new Comment { Id = 7, StockId = 5, AppUserId = "73aaeeb2-7674-5108-a974-9312dcfd454a", Title = "AWS + ads", Content = "Two high-margin engines under a retail business.", CreatedOn = new DateTime(2025, 1, 25, 8, 55, 0) }, // investor888
                new Comment { Id = 8, StockId = 6, AppUserId = "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", Title = "Best-run bank", Content = "Strong capital position and a reliable dividend.", CreatedOn = new DateTime(2025, 1, 28, 15, 30, 0) }, // investor333
                new Comment { Id = 9, StockId = 7, AppUserId = "8eb8512f-7564-56e0-80e1-35e8256e1973", Title = "Dividend king", Content = "60+ years of dividend increases, boring in a good way.", CreatedOn = new DateTime(2025, 2, 1, 12, 0, 0) }, // investor555
                new Comment { Id = 10, StockId = 8, AppUserId = "b5683003-fdf4-59cb-b121-048d94b77a9f", Title = "Membership model", Content = "Renewal rates above 90% make revenue very predictable.", CreatedOn = new DateTime(2025, 2, 3, 17, 15, 0) } // investor999
            );

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole { Id = "b571161c-e363-423d-8a12-a9ed229f36f2", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "f1a00ccb-9902-4b15-8213-63824d53d020", Name = "User", NormalizedName = "USER" }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            List<AppUser> users = new List<AppUser>
            {
                new AppUser { Id = "744f4311-22b4-5a24-b0f1-3e985835dda1", UserName = "investor111", NormalizedUserName = "INVESTOR111", Email = "investor111@blueFin.com", NormalizedEmail = "INVESTOR111@BLUEFIN.COM", EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAEGY0ya6tJ6CSVrBqjA2noC4ohN/GUQ6M8A+SbKnvvVOA+XkabPY3RXBr3IvrMZltVw==", SecurityStamp = "5589919A33A15D3DA3F0EAB0424CEA85", ConcurrencyStamp = "db75469f-297f-5874-a015-ced29ddf52e0" },
                new AppUser { Id = "9b3f00f0-fe42-5221-8fce-8171332a4851", UserName = "investor222", NormalizedUserName = "INVESTOR222", Email = "investor222@blueFin.com", NormalizedEmail = "INVESTOR222@BLUEFIN.COM", EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAEJaZ492bvhrjBQC204qJnp9kQY4Xq53a80w0KiOyoyGJwDHfiZLz7YDfe0pzCyAjYQ==", SecurityStamp = "C48610F05E3F5B1CAE80F1B73C3499B4", ConcurrencyStamp = "64834510-15af-59ec-8b9f-0b783232c9e3" },
                new AppUser { Id = "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", UserName = "investor333", NormalizedUserName = "INVESTOR333", Email = "investor333@blueFin.com", NormalizedEmail = "INVESTOR333@BLUEFIN.COM", EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAENQguuzK5ZyjlzNqRjh67H1fusaO7nmBOuqjr5GzmBT2myWBD6PmKpTZSzvJb+hwzQ==", SecurityStamp = "8A5B180C5BDF5F689F57F2F05388DAB6", ConcurrencyStamp = "2e008fd4-a9ee-5319-8d77-59651a9e5eed" },
                new AppUser { Id = "40fa6713-d2fa-52ac-b193-de5554240488", UserName = "investor444", NormalizedUserName = "INVESTOR444", Email = "investor444@blueFin.com", NormalizedEmail = "INVESTOR444@BLUEFIN.COM", EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAEDUhWt6qaCaNKiwtnOGQcst8W1N7VqnbggSmQjzS0gTVdpEstCCzDMrLtigwQmch2A==", SecurityStamp = "FFAD8A12A3ED5575BF7ABBAEB4B8D020", ConcurrencyStamp = "8fa428e1-e1c3-5f25-b741-73c5bbfcd31c" },
                new AppUser { Id = "8eb8512f-7564-56e0-80e1-35e8256e1973", UserName = "investor555", NormalizedUserName = "INVESTOR555", Email = "investor555@blueFin.com", NormalizedEmail = "INVESTOR555@BLUEFIN.COM", EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAEPnVl/ocRfehpm+H5x+BYiBxgPvobiXGbPeafV5N0IyfD9PlomL5IZtsyjw2MeiHtA==", SecurityStamp = "43D93F975F11526098571DC4CE763298", ConcurrencyStamp = "cdbcfdf5-5504-56bd-add5-3b08a4ca827b" },
                new AppUser { Id = "24912af2-fe71-5b9c-ae70-54ce47a06df4", UserName = "investor666", NormalizedUserName = "INVESTOR666", Email = "investor666@blueFin.com", NormalizedEmail = "INVESTOR666@BLUEFIN.COM", EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAENQyfbGKhBHeAbMheU+Ji81qeQtdWQhUpIUdMSTfC3EsPuXyZmGnzfGVYvcCcrFKDA==", SecurityStamp = "C6DD0AF8FEB05606A1322802972F88FB", ConcurrencyStamp = "e5bf1d96-6f16-5e17-94d0-434fd1de7050" },
                new AppUser { Id = "c129d2e4-7e79-5811-a736-66117ca1c8ff", UserName = "investor777", NormalizedUserName = "INVESTOR777", Email = "investor777@blueFin.com", NormalizedEmail = "INVESTOR777@BLUEFIN.COM", EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAEFh7fqi6YkW02vh4k59MnqqJlg67nwJCeJS/yQWdAuLellSUumGrvE0gcs+kpAdrPw==", SecurityStamp = "7A478ECCEEF15B1988B87F975BF41FE7", ConcurrencyStamp = "b57fbb11-8630-5976-80f6-ce17f1b090f7" },
                new AppUser { Id = "73aaeeb2-7674-5108-a974-9312dcfd454a", UserName = "investor888", NormalizedUserName = "INVESTOR888", Email = "investor888@blueFin.com", NormalizedEmail = "INVESTOR888@BLUEFIN.COM", EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAEPXNJGPoEkeMqeK6vdOVijlSeEScp62LxV4ldZfak1XEC9M8A5D849PMLi/9DBHocg==", SecurityStamp = "7243E9DE2D585497B404030FAAD7804D", ConcurrencyStamp = "a3c918ce-d92c-58af-a22f-7500b99cc7e7" },
                new AppUser { Id = "b5683003-fdf4-59cb-b121-048d94b77a9f", UserName = "investor999", NormalizedUserName = "INVESTOR999", Email = "investor999@blueFin.com", NormalizedEmail = "INVESTOR999@BLUEFIN.COM", EmailConfirmed = true, PasswordHash = "AQAAAAIAAYagAAAAEEhzCAJu56C/8orov/0H5iqs+UwHorWwQv7c+CGal5YjbgfjWXi9ulA4uC+94Qgd2A==", SecurityStamp = "A70181F0325A52CEA45684B33617D7B0", ConcurrencyStamp = "fad51079-42e3-5c5d-bc30-443361b93fb8" }
            };

            builder.Entity<AppUser>().HasData(users);

            builder.Entity<IdentityUserRole<string>>().HasData(
                users.Select(u => new IdentityUserRole<string> { UserId = u.Id, RoleId = "f1a00ccb-9902-4b15-8213-63824d53d020" })
            );

            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            builder.Entity<Portfolio>()
                .HasOne(p => p.AppUser)
                .WithMany(u => u.Portfolios)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<Portfolio>()
                .HasOne(p => p.Stock)
                .WithMany(s => s.Portfolios)
                .HasForeignKey(p => p.StockId);

            builder.Entity<Portfolio>().HasData(
                new Portfolio { AppUserId = "744f4311-22b4-5a24-b0f1-3e985835dda1", StockId = 1 }, // investor111
                new Portfolio { AppUserId = "744f4311-22b4-5a24-b0f1-3e985835dda1", StockId = 2 }, // investor111
                new Portfolio { AppUserId = "744f4311-22b4-5a24-b0f1-3e985835dda1", StockId = 3 }, // investor111
                new Portfolio { AppUserId = "9b3f00f0-fe42-5221-8fce-8171332a4851", StockId = 4 }, // investor222
                new Portfolio { AppUserId = "9b3f00f0-fe42-5221-8fce-8171332a4851", StockId = 5 }, // investor222
                new Portfolio { AppUserId = "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", StockId = 6 }, // investor333
                new Portfolio { AppUserId = "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", StockId = 7 }, // investor333
                new Portfolio { AppUserId = "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", StockId = 8 }, // investor333
                new Portfolio { AppUserId = "40fa6713-d2fa-52ac-b193-de5554240488", StockId = 1 }, // investor444
                new Portfolio { AppUserId = "40fa6713-d2fa-52ac-b193-de5554240488", StockId = 3 }, // investor444
                new Portfolio { AppUserId = "40fa6713-d2fa-52ac-b193-de5554240488", StockId = 4 }, // investor444
                new Portfolio { AppUserId = "40fa6713-d2fa-52ac-b193-de5554240488", StockId = 5 }, // investor444
                new Portfolio { AppUserId = "8eb8512f-7564-56e0-80e1-35e8256e1973", StockId = 7 }, // investor555
                new Portfolio { AppUserId = "24912af2-fe71-5b9c-ae70-54ce47a06df4", StockId = 2 }, // investor666
                new Portfolio { AppUserId = "24912af2-fe71-5b9c-ae70-54ce47a06df4", StockId = 6 }, // investor666
                new Portfolio { AppUserId = "c129d2e4-7e79-5811-a736-66117ca1c8ff", StockId = 3 }, // investor777
                new Portfolio { AppUserId = "c129d2e4-7e79-5811-a736-66117ca1c8ff", StockId = 4 }, // investor777
                new Portfolio { AppUserId = "73aaeeb2-7674-5108-a974-9312dcfd454a", StockId = 1 }, // investor888
                new Portfolio { AppUserId = "73aaeeb2-7674-5108-a974-9312dcfd454a", StockId = 5 }, // investor888
                new Portfolio { AppUserId = "73aaeeb2-7674-5108-a974-9312dcfd454a", StockId = 8 }, // investor888
                new Portfolio { AppUserId = "b5683003-fdf4-59cb-b121-048d94b77a9f", StockId = 2 }, // investor999
                new Portfolio { AppUserId = "b5683003-fdf4-59cb-b121-048d94b77a9f", StockId = 7 }, // investor999
                new Portfolio { AppUserId = "b5683003-fdf4-59cb-b121-048d94b77a9f", StockId = 8 } // investor999
            );
        }
    }
}