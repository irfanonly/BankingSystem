using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemarksNullableAddedOnTransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("300aab50-4da6-4ab2-a5d6-f5953cd35e91"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("5f5d0d68-47cd-4a16-806b-e48ed2481c06"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("a6a79820-ee50-47b8-9b18-f169ab035d5d"));

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 6, 17, 27, 918, DateTimeKind.Utc).AddTicks(5732), new DateTime(2024, 10, 9, 6, 17, 27, 918, DateTimeKind.Utc).AddTicks(5733) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 6, 17, 27, 918, DateTimeKind.Utc).AddTicks(5735), new DateTime(2024, 10, 9, 6, 17, 27, 918, DateTimeKind.Utc).AddTicks(5735) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "OverDraftLimit", "UserId" },
                values: new object[,]
                {
                    { new Guid("300aab50-4da6-4ab2-a5d6-f5953cd35e91"), 1, 25000.00m, false, "Fixed Deposit Account", null, null },
                    { new Guid("5f5d0d68-47cd-4a16-806b-e48ed2481c06"), 2, 15000.00m, false, "Business Checking Account", null, null },
                    { new Guid("a6a79820-ee50-47b8-9b18-f169ab035d5d"), 1, 5000.00m, false, "Primary Savings Account", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("a6a79820-ee50-47b8-9b18-f169ab035d5d"), new DateTime(2024, 10, 9, 10, 17, 27, 918, DateTimeKind.Local).AddTicks(5928) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("a6a79820-ee50-47b8-9b18-f169ab035d5d"), new DateTime(2024, 10, 7, 10, 17, 27, 918, DateTimeKind.Local).AddTicks(5940) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("5f5d0d68-47cd-4a16-806b-e48ed2481c06"), new DateTime(2024, 10, 4, 10, 17, 27, 918, DateTimeKind.Local).AddTicks(5946) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("300aab50-4da6-4ab2-a5d6-f5953cd35e91"), new DateTime(2024, 9, 9, 10, 17, 27, 918, DateTimeKind.Local).AddTicks(5948) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("300aab50-4da6-4ab2-a5d6-f5953cd35e91"), new DateTime(2024, 8, 9, 10, 17, 27, 918, DateTimeKind.Local).AddTicks(5984) });
        }
    }
}
