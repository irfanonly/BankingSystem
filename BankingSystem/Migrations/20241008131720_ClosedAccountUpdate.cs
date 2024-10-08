using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class ClosedAccountUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "AccID",
                table: "ClosedAccounts",
                newName: "AccountId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ClosedAccounts_AccountId",
                table: "ClosedAccounts",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClosedAccounts_Accounts_AccountId",
                table: "ClosedAccounts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClosedAccounts_Accounts_AccountId",
                table: "ClosedAccounts");

            migrationBuilder.DropIndex(
                name: "IX_ClosedAccounts_AccountId",
                table: "ClosedAccounts");

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

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "ClosedAccounts",
                newName: "AccID");

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

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("68bdec11-c4d8-4975-8f57-9935c496ce24"), new DateTime(2024, 10, 8, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6806) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("68bdec11-c4d8-4975-8f57-9935c496ce24"), new DateTime(2024, 10, 6, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("c60eae6b-6b87-4529-95f8-78e63f53aaec"), new DateTime(2024, 10, 3, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("6b7f38e9-ba51-4f84-a79f-c7b97740a8f8"), new DateTime(2024, 9, 8, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("6b7f38e9-ba51-4f84-a79f-c7b97740a8f8"), new DateTime(2024, 8, 8, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6834) });
        }
    }
}
