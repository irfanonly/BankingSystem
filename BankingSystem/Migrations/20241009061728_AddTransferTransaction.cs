using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddTransferTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("2067038a-9e4a-4763-83a7-d4ea67cb0426"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("80e8de19-280e-4a95-a519-6aa40a03e52c"));

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: new Guid("f8459235-bc7b-4205-8f3d-b2cd518bac6c"));

            migrationBuilder.CreateTable(
                name: "TransferTransaction",
                columns: table => new
                {
                    TransferId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferTransaction", x => new { x.TransferId, x.TransactionId });
                    table.ForeignKey(
                        name: "FK_TransferTransaction_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransferTransaction_Transfers_TransferId",
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

            migrationBuilder.CreateIndex(
                name: "IX_TransferTransaction_TransactionId",
                table: "TransferTransaction",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferTransaction");

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

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 6, 15, 51, 849, DateTimeKind.Utc).AddTicks(2618), new DateTime(2024, 10, 9, 6, 15, 51, 849, DateTimeKind.Utc).AddTicks(2620) });

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2024, 10, 9, 6, 15, 51, 849, DateTimeKind.Utc).AddTicks(2623), new DateTime(2024, 10, 9, 6, 15, 51, 849, DateTimeKind.Utc).AddTicks(2624) });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountTypeId", "Balance", "IsClosed", "Name", "OverDraftLimit", "UserId" },
                values: new object[,]
                {
                    { new Guid("2067038a-9e4a-4763-83a7-d4ea67cb0426"), 2, 15000.00m, false, "Business Checking Account", null, null },
                    { new Guid("80e8de19-280e-4a95-a519-6aa40a03e52c"), 1, 25000.00m, false, "Fixed Deposit Account", null, null },
                    { new Guid("f8459235-bc7b-4205-8f3d-b2cd518bac6c"), 1, 5000.00m, false, "Primary Savings Account", null, null }
                });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("f8459235-bc7b-4205-8f3d-b2cd518bac6c"), new DateTime(2024, 10, 9, 10, 15, 51, 849, DateTimeKind.Local).AddTicks(2842) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("f8459235-bc7b-4205-8f3d-b2cd518bac6c"), new DateTime(2024, 10, 7, 10, 15, 51, 849, DateTimeKind.Local).AddTicks(2855) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("2067038a-9e4a-4763-83a7-d4ea67cb0426"), new DateTime(2024, 10, 4, 10, 15, 51, 849, DateTimeKind.Local).AddTicks(2863) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("80e8de19-280e-4a95-a519-6aa40a03e52c"), new DateTime(2024, 9, 9, 10, 15, 51, 849, DateTimeKind.Local).AddTicks(2866) });

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "AccountId", "TrnOn" },
                values: new object[] { new Guid("80e8de19-280e-4a95-a519-6aa40a03e52c"), new DateTime(2024, 8, 9, 10, 15, 51, 849, DateTimeKind.Local).AddTicks(2875) });
        }
    }
}
