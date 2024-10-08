using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("8185b7f2-b282-4fe8-9427-0f19a46ba3b1"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("8bf08a1a-cfb5-47e5-b61a-dad47f6b7d90"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("90ce1ae5-f145-4cbf-b7e2-138fc06b5a15"));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 11, 13, 10, 213, DateTimeKind.Utc).AddTicks(6567), new DateTime(2024, 10, 8, 11, 13, 10, 213, DateTimeKind.Utc).AddTicks(6568) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 11, 13, 10, 213, DateTimeKind.Utc).AddTicks(6571), new DateTime(2024, 10, 8, 11, 13, 10, 213, DateTimeKind.Utc).AddTicks(6571) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("68bdec11-c4d8-4975-8f57-9935c496ce24"), 1, 5000.00m, false, "Primary Savings Account", null },
                    { new Guid("6b7f38e9-ba51-4f84-a79f-c7b97740a8f8"), 1, 25000.00m, false, "Fixed Deposit Account", null },
                    { new Guid("c60eae6b-6b87-4529-95f8-78e63f53aaec"), 2, 15000.00m, false, "Business Checking Account", null }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Amount", "TrnById", "TrnMethod", "TrnOn", "TrnType" },
                values: new object[,]
                {
                    { 1L, new Guid("68bdec11-c4d8-4975-8f57-9935c496ce24"), 500.00m, null, "Deposit", new DateTime(2024, 10, 8, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6806), "Credit" },
                    { 2L, new Guid("68bdec11-c4d8-4975-8f57-9935c496ce24"), 100.00m, null, "Withdrawal", new DateTime(2024, 10, 6, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6820), "Debit" },
                    { 3L, new Guid("c60eae6b-6b87-4529-95f8-78e63f53aaec"), 2000.00m, null, "Deposit", new DateTime(2024, 10, 3, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6826), "Credit" },
                    { 4L, new Guid("6b7f38e9-ba51-4f84-a79f-c7b97740a8f8"), 5000.00m, null, "Deposit", new DateTime(2024, 9, 8, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6829), "Credit" },
                    { 5L, new Guid("6b7f38e9-ba51-4f84-a79f-c7b97740a8f8"), 3000.00m, null, "Deposit", new DateTime(2024, 8, 8, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6834), "Credit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("68bdec11-c4d8-4975-8f57-9935c496ce24"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("6b7f38e9-ba51-4f84-a79f-c7b97740a8f8"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("c60eae6b-6b87-4529-95f8-78e63f53aaec"));

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 11, 12, 22, 473, DateTimeKind.Utc).AddTicks(6168), new DateTime(2024, 10, 8, 11, 12, 22, 473, DateTimeKind.Utc).AddTicks(6169) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 11, 12, 22, 473, DateTimeKind.Utc).AddTicks(6171), new DateTime(2024, 10, 8, 11, 12, 22, 473, DateTimeKind.Utc).AddTicks(6172) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("8185b7f2-b282-4fe8-9427-0f19a46ba3b1"), 1, 5000.00m, false, "Primary Savings Account", null },
                    { new Guid("8bf08a1a-cfb5-47e5-b61a-dad47f6b7d90"), 1, 25000.00m, false, "Fixed Deposit Account", null },
                    { new Guid("90ce1ae5-f145-4cbf-b7e2-138fc06b5a15"), 2, 15000.00m, false, "Business Checking Account", null }
                });
        }
    }
}
