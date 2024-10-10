using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeededUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 10, 18, 28, 36, 310, DateTimeKind.Utc).AddTicks(6201), new DateTime(2024, 10, 10, 18, 28, 36, 310, DateTimeKind.Utc).AddTicks(6203) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 10, 18, 28, 36, 310, DateTimeKind.Utc).AddTicks(6206), new DateTime(2024, 10, 10, 18, 28, 36, 310, DateTimeKind.Utc).AddTicks(6206) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "OverDraftLimit", "UserId" },
                values: new object[,]
                {
                    { new Guid("b86b697a-fded-4ad2-99a7-3090b0550ad3"), 2, 15000.00m, false, "Business Checking Account", null, null },
                    { new Guid("d12b359e-21a7-4d19-ab3d-5099a1402ebe"), 1, 25000.00m, false, "Fixed Deposit Account", null, null },
                    { new Guid("eb39897c-dd25-47ee-90f4-ced3ead7ae9f"), 1, 5000.00m, false, "Primary Savings Account", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("eb39897c-dd25-47ee-90f4-ced3ead7ae9f"), new DateTime(2024, 10, 10, 22, 28, 36, 310, DateTimeKind.Local).AddTicks(6431) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("eb39897c-dd25-47ee-90f4-ced3ead7ae9f"), new DateTime(2024, 10, 8, 22, 28, 36, 310, DateTimeKind.Local).AddTicks(6441) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("b86b697a-fded-4ad2-99a7-3090b0550ad3"), new DateTime(2024, 10, 5, 22, 28, 36, 310, DateTimeKind.Local).AddTicks(6446) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("d12b359e-21a7-4d19-ab3d-5099a1402ebe"), new DateTime(2024, 9, 10, 22, 28, 36, 310, DateTimeKind.Local).AddTicks(6448) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("d12b359e-21a7-4d19-ab3d-5099a1402ebe"), new DateTime(2024, 8, 10, 22, 28, 36, 310, DateTimeKind.Local).AddTicks(6452) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("328946f6-ea23-4111-98dc-a08196c0806e"), "test@bk.ae", "123", "Customer" },
                    { new Guid("efc4910a-fbff-408d-9ae5-d275be89482c"), "admin@bk.ae", "123", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("b86b697a-fded-4ad2-99a7-3090b0550ad3"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("d12b359e-21a7-4d19-ab3d-5099a1402ebe"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("eb39897c-dd25-47ee-90f4-ced3ead7ae9f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("328946f6-ea23-4111-98dc-a08196c0806e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("efc4910a-fbff-408d-9ae5-d275be89482c"));

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
    }
}
