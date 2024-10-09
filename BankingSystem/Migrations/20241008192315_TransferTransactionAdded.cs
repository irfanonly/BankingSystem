using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class TransferTransactionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "FromTransferId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "ToTransferId",
                table: "Transfers");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferredOn",
                table: "Transfers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TransferTransactions",
                columns: table => new
                {
                    TransferId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    TransactionId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferTransactions", x => new { x.TransferId, x.TransactionId });
                    table.ForeignKey(
                        name: "FK_TransferTransactions_Transactions_TransactionId1",
                        column: x => x.TransactionId1,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferTransactions_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferTransactions");

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
                name: "TransferredOn",
                table: "Transfers");

            migrationBuilder.AddColumn<int>(
                name: "FromTransferId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToTransferId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
