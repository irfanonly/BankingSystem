using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class RowVersionAddedForConcurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("a79d414c-9daa-480a-a2de-b088a97a9ec5"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("eeb614d5-8457-46f8-846f-99724425f1c8"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("fd589f85-930a-4217-a1fe-33f6db2b2f54"));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Accounts",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 7, 56, 7, 213, DateTimeKind.Utc).AddTicks(3881), new DateTime(2024, 10, 9, 7, 56, 7, 213, DateTimeKind.Utc).AddTicks(3884) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 7, 56, 7, 213, DateTimeKind.Utc).AddTicks(3886), new DateTime(2024, 10, 9, 7, 56, 7, 213, DateTimeKind.Utc).AddTicks(3886) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "OverDraftLimit", "UserId" },
                values: new object[,]
                {
                    { new Guid("5f3a0cf8-dd4e-472b-9d88-2855c313b46e"), 1, 25000.00m, false, "Fixed Deposit Account", null, null },
                    { new Guid("60715442-728c-4ea8-93c5-acc97102341d"), 1, 5000.00m, false, "Primary Savings Account", null, null },
                    { new Guid("79b03353-1d27-460e-a6f0-9fdc8d90b522"), 2, 15000.00m, false, "Business Checking Account", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("60715442-728c-4ea8-93c5-acc97102341d"), new DateTime(2024, 10, 9, 11, 56, 7, 213, DateTimeKind.Local).AddTicks(4007) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("60715442-728c-4ea8-93c5-acc97102341d"), new DateTime(2024, 10, 7, 11, 56, 7, 213, DateTimeKind.Local).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("79b03353-1d27-460e-a6f0-9fdc8d90b522"), new DateTime(2024, 10, 4, 11, 56, 7, 213, DateTimeKind.Local).AddTicks(4025) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("5f3a0cf8-dd4e-472b-9d88-2855c313b46e"), new DateTime(2024, 9, 9, 11, 56, 7, 213, DateTimeKind.Local).AddTicks(4027) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("5f3a0cf8-dd4e-472b-9d88-2855c313b46e"), new DateTime(2024, 8, 9, 11, 56, 7, 213, DateTimeKind.Local).AddTicks(4031) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("5f3a0cf8-dd4e-472b-9d88-2855c313b46e"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("60715442-728c-4ea8-93c5-acc97102341d"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("79b03353-1d27-460e-a6f0-9fdc8d90b522"));

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 7, 28, 5, 310, DateTimeKind.Utc).AddTicks(117), new DateTime(2024, 10, 9, 7, 28, 5, 310, DateTimeKind.Utc).AddTicks(119) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 7, 28, 5, 310, DateTimeKind.Utc).AddTicks(121), new DateTime(2024, 10, 9, 7, 28, 5, 310, DateTimeKind.Utc).AddTicks(121) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "OverDraftLimit", "UserId" },
                values: new object[,]
                {
                    { new Guid("a79d414c-9daa-480a-a2de-b088a97a9ec5"), 1, 5000.00m, false, "Primary Savings Account", null, null },
                    { new Guid("eeb614d5-8457-46f8-846f-99724425f1c8"), 2, 15000.00m, false, "Business Checking Account", null, null },
                    { new Guid("fd589f85-930a-4217-a1fe-33f6db2b2f54"), 1, 25000.00m, false, "Fixed Deposit Account", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("a79d414c-9daa-480a-a2de-b088a97a9ec5"), new DateTime(2024, 10, 9, 11, 28, 5, 310, DateTimeKind.Local).AddTicks(244) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("a79d414c-9daa-480a-a2de-b088a97a9ec5"), new DateTime(2024, 10, 7, 11, 28, 5, 310, DateTimeKind.Local).AddTicks(254) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("eeb614d5-8457-46f8-846f-99724425f1c8"), new DateTime(2024, 10, 4, 11, 28, 5, 310, DateTimeKind.Local).AddTicks(259) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("fd589f85-930a-4217-a1fe-33f6db2b2f54"), new DateTime(2024, 9, 9, 11, 28, 5, 310, DateTimeKind.Local).AddTicks(261) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("fd589f85-930a-4217-a1fe-33f6db2b2f54"), new DateTime(2024, 8, 9, 11, 28, 5, 310, DateTimeKind.Local).AddTicks(265) });
        }
    }
}
