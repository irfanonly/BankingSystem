using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class DropTransferTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferTransactions_Transactions_TransactionId1",
                table: "TransferTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferTransactions_Transfers_TransferId",
                table: "TransferTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransferTransactions",
                table: "TransferTransactions");

            migrationBuilder.DropIndex(
                name: "IX_TransferTransactions_TransactionId1",
                table: "TransferTransactions");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("4937035e-0fd3-4134-acf1-0cff644f7bf3"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("958b0e2e-e96e-4b0b-9a7b-b992fdc9aaf3"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("e98f829f-fadf-45bf-878c-09c7bac26a07"));

            migrationBuilder.DropColumn(
                name: "TransactionId1",
                table: "TransferTransactions");

            migrationBuilder.RenameTable(
                name: "TransferTransactions",
                newName: "TransferTransaction");

            migrationBuilder.AlterColumn<long>(
                name: "TransactionId",
                table: "TransferTransaction",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransferTransaction",
                table: "TransferTransaction",
                columns: new[] { "TransferId", "TransactionId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_TransferTransaction_TransactionId",
                table: "TransferTransaction",
                column: "TransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferTransaction_Transactions_TransactionId",
                table: "TransferTransaction",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferTransaction_Transfers_TransferId",
                table: "TransferTransaction",
                column: "TransferId",
                principalTable: "Transfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransferTransaction_Transactions_TransactionId",
                table: "TransferTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferTransaction_Transfers_TransferId",
                table: "TransferTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransferTransaction",
                table: "TransferTransaction");

            migrationBuilder.DropIndex(
                name: "IX_TransferTransaction_TransactionId",
                table: "TransferTransaction");

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

            migrationBuilder.RenameTable(
                name: "TransferTransaction",
                newName: "TransferTransactions");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionId",
                table: "TransferTransactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "TransactionId1",
                table: "TransferTransactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransferTransactions",
                table: "TransferTransactions",
                columns: new[] { "TransferId", "TransactionId" });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 19, 23, 14, 931, DateTimeKind.Utc).AddTicks(5117), new DateTime(2024, 10, 8, 19, 23, 14, 931, DateTimeKind.Utc).AddTicks(5120) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 8, 19, 23, 14, 931, DateTimeKind.Utc).AddTicks(5122), new DateTime(2024, 10, 8, 19, 23, 14, 931, DateTimeKind.Utc).AddTicks(5123) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "OverDraftLimit", "UserId" },
                values: new object[,]
                {
                    { new Guid("4937035e-0fd3-4134-acf1-0cff644f7bf3"), 1, 25000.00m, false, "Fixed Deposit Account", null, null },
                    { new Guid("958b0e2e-e96e-4b0b-9a7b-b992fdc9aaf3"), 1, 5000.00m, false, "Primary Savings Account", null, null },
                    { new Guid("e98f829f-fadf-45bf-878c-09c7bac26a07"), 2, 15000.00m, false, "Business Checking Account", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("958b0e2e-e96e-4b0b-9a7b-b992fdc9aaf3"), new DateTime(2024, 10, 8, 23, 23, 14, 931, DateTimeKind.Local).AddTicks(5276) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("958b0e2e-e96e-4b0b-9a7b-b992fdc9aaf3"), new DateTime(2024, 10, 6, 23, 23, 14, 931, DateTimeKind.Local).AddTicks(5286) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("e98f829f-fadf-45bf-878c-09c7bac26a07"), new DateTime(2024, 10, 3, 23, 23, 14, 931, DateTimeKind.Local).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("4937035e-0fd3-4134-acf1-0cff644f7bf3"), new DateTime(2024, 9, 8, 23, 23, 14, 931, DateTimeKind.Local).AddTicks(5294) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("4937035e-0fd3-4134-acf1-0cff644f7bf3"), new DateTime(2024, 8, 8, 23, 23, 14, 931, DateTimeKind.Local).AddTicks(5298) });

            migrationBuilder.CreateIndex(
                name: "IX_TransferTransactions_TransactionId1",
                table: "TransferTransactions",
                column: "TransactionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TransferTransactions_Transactions_TransactionId1",
                table: "TransferTransactions",
                column: "TransactionId1",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferTransactions_Transfers_TransferId",
                table: "TransferTransactions",
                column: "TransferId",
                principalTable: "Transfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
