using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class DropTransferTransaction2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("2bd598cf-fb87-41ec-8f76-64f37f2efacb"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("6d80de06-b30c-41c0-aede-f9c12b121f7d"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("6e90fdf0-4deb-4beb-92f3-f3bc786d111a"));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 6, 14, 55, 587, DateTimeKind.Utc).AddTicks(9560), new DateTime(2024, 10, 9, 6, 14, 55, 587, DateTimeKind.Utc).AddTicks(9562) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 6, 14, 55, 587, DateTimeKind.Utc).AddTicks(9565), new DateTime(2024, 10, 9, 6, 14, 55, 587, DateTimeKind.Utc).AddTicks(9565) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "OverDraftLimit", "UserId" },
                values: new object[,]
                {
                    { new Guid("0b631537-4973-4805-87ea-9673d84a360d"), 1, 5000.00m, false, "Primary Savings Account", null, null },
                    { new Guid("8689e2c7-c286-4941-b05b-5e0e634d5a91"), 2, 15000.00m, false, "Business Checking Account", null, null },
                    { new Guid("cf85b236-05cf-4b81-82b8-20fcf44bd3e4"), 1, 25000.00m, false, "Fixed Deposit Account", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("0b631537-4973-4805-87ea-9673d84a360d"), new DateTime(2024, 10, 9, 10, 14, 55, 587, DateTimeKind.Local).AddTicks(9749) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("0b631537-4973-4805-87ea-9673d84a360d"), new DateTime(2024, 10, 7, 10, 14, 55, 587, DateTimeKind.Local).AddTicks(9760) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("8689e2c7-c286-4941-b05b-5e0e634d5a91"), new DateTime(2024, 10, 4, 10, 14, 55, 587, DateTimeKind.Local).AddTicks(9766) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("cf85b236-05cf-4b81-82b8-20fcf44bd3e4"), new DateTime(2024, 9, 9, 10, 14, 55, 587, DateTimeKind.Local).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("cf85b236-05cf-4b81-82b8-20fcf44bd3e4"), new DateTime(2024, 8, 9, 10, 14, 55, 587, DateTimeKind.Local).AddTicks(9772) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("0b631537-4973-4805-87ea-9673d84a360d"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("8689e2c7-c286-4941-b05b-5e0e634d5a91"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("cf85b236-05cf-4b81-82b8-20fcf44bd3e4"));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 6, 13, 27, 494, DateTimeKind.Utc).AddTicks(9473), new DateTime(2024, 10, 9, 6, 13, 27, 494, DateTimeKind.Utc).AddTicks(9475) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 6, 13, 27, 494, DateTimeKind.Utc).AddTicks(9478), new DateTime(2024, 10, 9, 6, 13, 27, 494, DateTimeKind.Utc).AddTicks(9478) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "OverDraftLimit", "UserId" },
                values: new object[,]
                {
                    { new Guid("2bd598cf-fb87-41ec-8f76-64f37f2efacb"), 2, 15000.00m, false, "Business Checking Account", null, null },
                    { new Guid("6d80de06-b30c-41c0-aede-f9c12b121f7d"), 1, 25000.00m, false, "Fixed Deposit Account", null, null },
                    { new Guid("6e90fdf0-4deb-4beb-92f3-f3bc786d111a"), 1, 5000.00m, false, "Primary Savings Account", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("6e90fdf0-4deb-4beb-92f3-f3bc786d111a"), new DateTime(2024, 10, 9, 10, 13, 27, 494, DateTimeKind.Local).AddTicks(9654) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("6e90fdf0-4deb-4beb-92f3-f3bc786d111a"), new DateTime(2024, 10, 7, 10, 13, 27, 494, DateTimeKind.Local).AddTicks(9665) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("2bd598cf-fb87-41ec-8f76-64f37f2efacb"), new DateTime(2024, 10, 4, 10, 13, 27, 494, DateTimeKind.Local).AddTicks(9672) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("6d80de06-b30c-41c0-aede-f9c12b121f7d"), new DateTime(2024, 9, 9, 10, 13, 27, 494, DateTimeKind.Local).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("6d80de06-b30c-41c0-aede-f9c12b121f7d"), new DateTime(2024, 8, 9, 10, 13, 27, 494, DateTimeKind.Local).AddTicks(9678) });
        }
    }
}
