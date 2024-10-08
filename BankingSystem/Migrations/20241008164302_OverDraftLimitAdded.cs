using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class OverDraftLimitAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("41f09eeb-2062-4230-8395-6a0e3c928210"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("495be771-b264-456f-aba0-aafea7c14ff0"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("f9ea6b6d-deb5-41db-9794-d39a602f39db"));

            migrationBuilder.AddColumn<decimal>(
                name: "OverDraftLimit",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 16, 43, 2, 249, DateTimeKind.Utc).AddTicks(709), new DateTime(2024, 10, 8, 16, 43, 2, 249, DateTimeKind.Utc).AddTicks(712) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 16, 43, 2, 249, DateTimeKind.Utc).AddTicks(721), new DateTime(2024, 10, 8, 16, 43, 2, 249, DateTimeKind.Utc).AddTicks(721) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "OverDraftLimit", "UserId" },
                values: new object[,]
                {
                    { new Guid("049f2d7b-67af-4ef6-856a-711c80e58430"), 2, 15000.00m, false, "Business Checking Account", null, null },
                    { new Guid("38e638a4-3437-42a9-a0b1-d2fff5981eb6"), 1, 25000.00m, false, "Fixed Deposit Account", null, null },
                    { new Guid("fc0636de-40a6-45fc-b7ed-7fc20a01dea8"), 1, 5000.00m, false, "Primary Savings Account", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("fc0636de-40a6-45fc-b7ed-7fc20a01dea8"), new DateTime(2024, 10, 8, 20, 43, 2, 249, DateTimeKind.Local).AddTicks(1039) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("fc0636de-40a6-45fc-b7ed-7fc20a01dea8"), new DateTime(2024, 10, 6, 20, 43, 2, 249, DateTimeKind.Local).AddTicks(1051) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("049f2d7b-67af-4ef6-856a-711c80e58430"), new DateTime(2024, 10, 3, 20, 43, 2, 249, DateTimeKind.Local).AddTicks(1059) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("38e638a4-3437-42a9-a0b1-d2fff5981eb6"), new DateTime(2024, 9, 8, 20, 43, 2, 249, DateTimeKind.Local).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("38e638a4-3437-42a9-a0b1-d2fff5981eb6"), new DateTime(2024, 8, 8, 20, 43, 2, 249, DateTimeKind.Local).AddTicks(1065) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("049f2d7b-67af-4ef6-856a-711c80e58430"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("38e638a4-3437-42a9-a0b1-d2fff5981eb6"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("fc0636de-40a6-45fc-b7ed-7fc20a01dea8"));

            migrationBuilder.DropColumn(
                name: "OverDraftLimit",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 13, 17, 20, 254, DateTimeKind.Utc).AddTicks(8019), new DateTime(2024, 10, 8, 13, 17, 20, 254, DateTimeKind.Utc).AddTicks(8021) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 13, 17, 20, 254, DateTimeKind.Utc).AddTicks(8023), new DateTime(2024, 10, 8, 13, 17, 20, 254, DateTimeKind.Utc).AddTicks(8023) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("41f09eeb-2062-4230-8395-6a0e3c928210"), 2, 15000.00m, false, "Business Checking Account", null },
                    { new Guid("495be771-b264-456f-aba0-aafea7c14ff0"), 1, 5000.00m, false, "Primary Savings Account", null },
                    { new Guid("f9ea6b6d-deb5-41db-9794-d39a602f39db"), 1, 25000.00m, false, "Fixed Deposit Account", null }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("495be771-b264-456f-aba0-aafea7c14ff0"), new DateTime(2024, 10, 8, 17, 17, 20, 254, DateTimeKind.Local).AddTicks(8149) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("495be771-b264-456f-aba0-aafea7c14ff0"), new DateTime(2024, 10, 6, 17, 17, 20, 254, DateTimeKind.Local).AddTicks(8159) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("41f09eeb-2062-4230-8395-6a0e3c928210"), new DateTime(2024, 10, 3, 17, 17, 20, 254, DateTimeKind.Local).AddTicks(8165) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("f9ea6b6d-deb5-41db-9794-d39a602f39db"), new DateTime(2024, 9, 8, 17, 17, 20, 254, DateTimeKind.Local).AddTicks(8166) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("f9ea6b6d-deb5-41db-9794-d39a602f39db"), new DateTime(2024, 8, 8, 17, 17, 20, 254, DateTimeKind.Local).AddTicks(8170) });
        }
    }
}
