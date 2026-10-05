using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersAndPortfolios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "24912af2-fe71-5b9c-ae70-54ce47a06df4", 0, "e5bf1d96-6f16-5e17-94d0-434fd1de7050", "investor666@blueFin.com", true, false, null, "INVESTOR666@BLUEFIN.COM", "INVESTOR666", "AQAAAAIAAYagAAAAENQyfbGKhBHeAbMheU+Ji81qeQtdWQhUpIUdMSTfC3EsPuXyZmGnzfGVYvcCcrFKDA==", null, false, "C6DD0AF8FEB05606A1322802972F88FB", false, "investor666" },
                    { "40fa6713-d2fa-52ac-b193-de5554240488", 0, "8fa428e1-e1c3-5f25-b741-73c5bbfcd31c", "investor444@blueFin.com", true, false, null, "INVESTOR444@BLUEFIN.COM", "INVESTOR444", "AQAAAAIAAYagAAAAEDUhWt6qaCaNKiwtnOGQcst8W1N7VqnbggSmQjzS0gTVdpEstCCzDMrLtigwQmch2A==", null, false, "FFAD8A12A3ED5575BF7ABBAEB4B8D020", false, "investor444" },
                    { "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", 0, "2e008fd4-a9ee-5319-8d77-59651a9e5eed", "investor333@blueFin.com", true, false, null, "INVESTOR333@BLUEFIN.COM", "INVESTOR333", "AQAAAAIAAYagAAAAENQguuzK5ZyjlzNqRjh67H1fusaO7nmBOuqjr5GzmBT2myWBD6PmKpTZSzvJb+hwzQ==", null, false, "8A5B180C5BDF5F689F57F2F05388DAB6", false, "investor333" },
                    { "73aaeeb2-7674-5108-a974-9312dcfd454a", 0, "a3c918ce-d92c-58af-a22f-7500b99cc7e7", "investor888@blueFin.com", true, false, null, "INVESTOR888@BLUEFIN.COM", "INVESTOR888", "AQAAAAIAAYagAAAAEPXNJGPoEkeMqeK6vdOVijlSeEScp62LxV4ldZfak1XEC9M8A5D849PMLi/9DBHocg==", null, false, "7243E9DE2D585497B404030FAAD7804D", false, "investor888" },
                    { "744f4311-22b4-5a24-b0f1-3e985835dda1", 0, "db75469f-297f-5874-a015-ced29ddf52e0", "investor111@blueFin.com", true, false, null, "INVESTOR111@BLUEFIN.COM", "INVESTOR111", "AQAAAAIAAYagAAAAEGY0ya6tJ6CSVrBqjA2noC4ohN/GUQ6M8A+SbKnvvVOA+XkabPY3RXBr3IvrMZltVw==", null, false, "5589919A33A15D3DA3F0EAB0424CEA85", false, "investor111" },
                    { "8eb8512f-7564-56e0-80e1-35e8256e1973", 0, "cdbcfdf5-5504-56bd-add5-3b08a4ca827b", "investor555@blueFin.com", true, false, null, "INVESTOR555@BLUEFIN.COM", "INVESTOR555", "AQAAAAIAAYagAAAAEPnVl/ocRfehpm+H5x+BYiBxgPvobiXGbPeafV5N0IyfD9PlomL5IZtsyjw2MeiHtA==", null, false, "43D93F975F11526098571DC4CE763298", false, "investor555" },
                    { "9b3f00f0-fe42-5221-8fce-8171332a4851", 0, "64834510-15af-59ec-8b9f-0b783232c9e3", "investor222@blueFin.com", true, false, null, "INVESTOR222@BLUEFIN.COM", "INVESTOR222", "AQAAAAIAAYagAAAAEJaZ492bvhrjBQC204qJnp9kQY4Xq53a80w0KiOyoyGJwDHfiZLz7YDfe0pzCyAjYQ==", null, false, "C48610F05E3F5B1CAE80F1B73C3499B4", false, "investor222" },
                    { "b5683003-fdf4-59cb-b121-048d94b77a9f", 0, "fad51079-42e3-5c5d-bc30-443361b93fb8", "investor999@blueFin.com", true, false, null, "INVESTOR999@BLUEFIN.COM", "INVESTOR999", "AQAAAAIAAYagAAAAEEhzCAJu56C/8orov/0H5iqs+UwHorWwQv7c+CGal5YjbgfjWXi9ulA4uC+94Qgd2A==", null, false, "A70181F0325A52CEA45684B33617D7B0", false, "investor999" },
                    { "c129d2e4-7e79-5811-a736-66117ca1c8ff", 0, "b57fbb11-8630-5976-80f6-ce17f1b090f7", "investor777@blueFin.com", true, false, null, "INVESTOR777@BLUEFIN.COM", "INVESTOR777", "AQAAAAIAAYagAAAAEFh7fqi6YkW02vh4k59MnqqJlg67nwJCeJS/yQWdAuLellSUumGrvE0gcs+kpAdrPw==", null, false, "7A478ECCEEF15B1988B87F975BF41FE7", false, "investor777" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "f1a00ccb-9902-4b15-8213-63824d53d020", "24912af2-fe71-5b9c-ae70-54ce47a06df4" },
                    { "f1a00ccb-9902-4b15-8213-63824d53d020", "40fa6713-d2fa-52ac-b193-de5554240488" },
                    { "f1a00ccb-9902-4b15-8213-63824d53d020", "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564" },
                    { "f1a00ccb-9902-4b15-8213-63824d53d020", "73aaeeb2-7674-5108-a974-9312dcfd454a" },
                    { "f1a00ccb-9902-4b15-8213-63824d53d020", "744f4311-22b4-5a24-b0f1-3e985835dda1" },
                    { "f1a00ccb-9902-4b15-8213-63824d53d020", "8eb8512f-7564-56e0-80e1-35e8256e1973" },
                    { "f1a00ccb-9902-4b15-8213-63824d53d020", "9b3f00f0-fe42-5221-8fce-8171332a4851" },
                    { "f1a00ccb-9902-4b15-8213-63824d53d020", "b5683003-fdf4-59cb-b121-048d94b77a9f" },
                    { "f1a00ccb-9902-4b15-8213-63824d53d020", "c129d2e4-7e79-5811-a736-66117ca1c8ff" }
                });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "AppUserId", "StockId" },
                values: new object[,]
                {
                    { "24912af2-fe71-5b9c-ae70-54ce47a06df4", 2 },
                    { "24912af2-fe71-5b9c-ae70-54ce47a06df4", 6 },
                    { "40fa6713-d2fa-52ac-b193-de5554240488", 1 },
                    { "40fa6713-d2fa-52ac-b193-de5554240488", 3 },
                    { "40fa6713-d2fa-52ac-b193-de5554240488", 4 },
                    { "40fa6713-d2fa-52ac-b193-de5554240488", 5 },
                    { "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", 6 },
                    { "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", 7 },
                    { "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", 8 },
                    { "73aaeeb2-7674-5108-a974-9312dcfd454a", 1 },
                    { "73aaeeb2-7674-5108-a974-9312dcfd454a", 5 },
                    { "73aaeeb2-7674-5108-a974-9312dcfd454a", 8 },
                    { "744f4311-22b4-5a24-b0f1-3e985835dda1", 1 },
                    { "744f4311-22b4-5a24-b0f1-3e985835dda1", 2 },
                    { "744f4311-22b4-5a24-b0f1-3e985835dda1", 3 },
                    { "8eb8512f-7564-56e0-80e1-35e8256e1973", 7 },
                    { "9b3f00f0-fe42-5221-8fce-8171332a4851", 4 },
                    { "9b3f00f0-fe42-5221-8fce-8171332a4851", 5 },
                    { "b5683003-fdf4-59cb-b121-048d94b77a9f", 2 },
                    { "b5683003-fdf4-59cb-b121-048d94b77a9f", 7 },
                    { "b5683003-fdf4-59cb-b121-048d94b77a9f", 8 },
                    { "c129d2e4-7e79-5811-a736-66117ca1c8ff", 3 },
                    { "c129d2e4-7e79-5811-a736-66117ca1c8ff", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1a00ccb-9902-4b15-8213-63824d53d020", "24912af2-fe71-5b9c-ae70-54ce47a06df4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1a00ccb-9902-4b15-8213-63824d53d020", "40fa6713-d2fa-52ac-b193-de5554240488" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1a00ccb-9902-4b15-8213-63824d53d020", "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1a00ccb-9902-4b15-8213-63824d53d020", "73aaeeb2-7674-5108-a974-9312dcfd454a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1a00ccb-9902-4b15-8213-63824d53d020", "744f4311-22b4-5a24-b0f1-3e985835dda1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1a00ccb-9902-4b15-8213-63824d53d020", "8eb8512f-7564-56e0-80e1-35e8256e1973" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1a00ccb-9902-4b15-8213-63824d53d020", "9b3f00f0-fe42-5221-8fce-8171332a4851" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1a00ccb-9902-4b15-8213-63824d53d020", "b5683003-fdf4-59cb-b121-048d94b77a9f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f1a00ccb-9902-4b15-8213-63824d53d020", "c129d2e4-7e79-5811-a736-66117ca1c8ff" });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "24912af2-fe71-5b9c-ae70-54ce47a06df4", 2 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "24912af2-fe71-5b9c-ae70-54ce47a06df4", 6 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "40fa6713-d2fa-52ac-b193-de5554240488", 1 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "40fa6713-d2fa-52ac-b193-de5554240488", 3 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "40fa6713-d2fa-52ac-b193-de5554240488", 4 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "40fa6713-d2fa-52ac-b193-de5554240488", 5 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", 6 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", 7 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564", 8 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "73aaeeb2-7674-5108-a974-9312dcfd454a", 1 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "73aaeeb2-7674-5108-a974-9312dcfd454a", 5 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "73aaeeb2-7674-5108-a974-9312dcfd454a", 8 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "744f4311-22b4-5a24-b0f1-3e985835dda1", 1 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "744f4311-22b4-5a24-b0f1-3e985835dda1", 2 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "744f4311-22b4-5a24-b0f1-3e985835dda1", 3 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "8eb8512f-7564-56e0-80e1-35e8256e1973", 7 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "9b3f00f0-fe42-5221-8fce-8171332a4851", 4 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "9b3f00f0-fe42-5221-8fce-8171332a4851", 5 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "b5683003-fdf4-59cb-b121-048d94b77a9f", 2 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "b5683003-fdf4-59cb-b121-048d94b77a9f", 7 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "b5683003-fdf4-59cb-b121-048d94b77a9f", 8 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "c129d2e4-7e79-5811-a736-66117ca1c8ff", 3 });

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumns: new[] { "AppUserId", "StockId" },
                keyValues: new object[] { "c129d2e4-7e79-5811-a736-66117ca1c8ff", 4 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24912af2-fe71-5b9c-ae70-54ce47a06df4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40fa6713-d2fa-52ac-b193-de5554240488");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4d0f22a1-fdfa-5d2e-9856-7957c3fd5564");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73aaeeb2-7674-5108-a974-9312dcfd454a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "744f4311-22b4-5a24-b0f1-3e985835dda1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8eb8512f-7564-56e0-80e1-35e8256e1973");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9b3f00f0-fe42-5221-8fce-8171332a4851");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5683003-fdf4-59cb-b121-048d94b77a9f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c129d2e4-7e79-5811-a736-66117ca1c8ff");
        }
    }
}
