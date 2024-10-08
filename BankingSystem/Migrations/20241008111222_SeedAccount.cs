using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new DateTime(2024, 10, 8, 8, 30, 2, 556, DateTimeKind.Utc).AddTicks(3780), new DateTime(2024, 10, 8, 8, 30, 2, 556, DateTimeKind.Utc).AddTicks(3782) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 8, 30, 2, 556, DateTimeKind.Utc).AddTicks(3784), new DateTime(2024, 10, 8, 8, 30, 2, 556, DateTimeKind.Utc).AddTicks(3784) });
        }
    }
}
