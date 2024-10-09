﻿// <auto-generated />
using System;
using BankingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankingSystem.Migrations
{
    [DbContext(typeof(BankAccDBContext))]
    [Migration("20241009061728_AddTransferTransaction")]
    partial class AddTransferTransaction
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BankingSystem.Data.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccountTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("OverDraftLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6a79820-ee50-47b8-9b18-f169ab035d5d"),
                            AccountTypeId = 1,
                            Balance = 5000.00m,
                            IsClosed = false,
                            Name = "Primary Savings Account"
                        },
                        new
                        {
                            Id = new Guid("5f5d0d68-47cd-4a16-806b-e48ed2481c06"),
                            AccountTypeId = 2,
                            Balance = 15000.00m,
                            IsClosed = false,
                            Name = "Business Checking Account"
                        },
                        new
                        {
                            Id = new Guid("300aab50-4da6-4ab2-a5d6-f5953cd35e91"),
                            AccountTypeId = 1,
                            Balance = 25000.00m,
                            IsClosed = false,
                            Name = "Fixed Deposit Account"
                        });
                });

            modelBuilder.Entity("BankingSystem.Data.AccountType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AccountTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2024, 10, 9, 6, 17, 27, 918, DateTimeKind.Utc).AddTicks(5732),
                            IsDeleted = false,
                            Name = "Savings",
                            UpdatedOn = new DateTime(2024, 10, 9, 6, 17, 27, 918, DateTimeKind.Utc).AddTicks(5733)
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2024, 10, 9, 6, 17, 27, 918, DateTimeKind.Utc).AddTicks(5735),
                            IsDeleted = false,
                            Name = "Checking",
                            UpdatedOn = new DateTime(2024, 10, 9, 6, 17, 27, 918, DateTimeKind.Utc).AddTicks(5735)
                        });
                });

            modelBuilder.Entity("BankingSystem.Data.ClosedAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClosedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ClosedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ClosedById");

                    b.ToTable("ClosedAccounts");
                });

            modelBuilder.Entity("BankingSystem.Data.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("TrnById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TrnMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TrnOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrnType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("TrnById");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AccountId = new Guid("a6a79820-ee50-47b8-9b18-f169ab035d5d"),
                            Amount = 500.00m,
                            TrnMethod = "Deposit",
                            TrnOn = new DateTime(2024, 10, 9, 10, 17, 27, 918, DateTimeKind.Local).AddTicks(5928),
                            TrnType = "Credit"
                        },
                        new
                        {
                            Id = 2L,
                            AccountId = new Guid("a6a79820-ee50-47b8-9b18-f169ab035d5d"),
                            Amount = 100.00m,
                            TrnMethod = "Withdrawal",
                            TrnOn = new DateTime(2024, 10, 7, 10, 17, 27, 918, DateTimeKind.Local).AddTicks(5940),
                            TrnType = "Debit"
                        },
                        new
                        {
                            Id = 3L,
                            AccountId = new Guid("5f5d0d68-47cd-4a16-806b-e48ed2481c06"),
                            Amount = 2000.00m,
                            TrnMethod = "Deposit",
                            TrnOn = new DateTime(2024, 10, 4, 10, 17, 27, 918, DateTimeKind.Local).AddTicks(5946),
                            TrnType = "Credit"
                        },
                        new
                        {
                            Id = 4L,
                            AccountId = new Guid("300aab50-4da6-4ab2-a5d6-f5953cd35e91"),
                            Amount = 5000.00m,
                            TrnMethod = "Deposit",
                            TrnOn = new DateTime(2024, 9, 9, 10, 17, 27, 918, DateTimeKind.Local).AddTicks(5948),
                            TrnType = "Credit"
                        },
                        new
                        {
                            Id = 5L,
                            AccountId = new Guid("300aab50-4da6-4ab2-a5d6-f5953cd35e91"),
                            Amount = 3000.00m,
                            TrnMethod = "Deposit",
                            TrnOn = new DateTime(2024, 8, 9, 10, 17, 27, 918, DateTimeKind.Local).AddTicks(5984),
                            TrnType = "Credit"
                        });
                });

            modelBuilder.Entity("BankingSystem.Data.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TransferredOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("BankingSystem.Data.TransferTransaction", b =>
                {
                    b.Property<int>("TransferId")
                        .HasColumnType("int");

                    b.Property<long>("TransactionId")
                        .HasColumnType("bigint");

                    b.HasKey("TransferId", "TransactionId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransferTransaction");
                });

            modelBuilder.Entity("BankingSystem.Data.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BankingSystem.Data.Account", b =>
                {
                    b.HasOne("BankingSystem.Data.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("AccountType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BankingSystem.Data.ClosedAccount", b =>
                {
                    b.HasOne("BankingSystem.Data.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Data.User", "ClosedBy")
                        .WithMany()
                        .HasForeignKey("ClosedById");

                    b.Navigation("Account");

                    b.Navigation("ClosedBy");
                });

            modelBuilder.Entity("BankingSystem.Data.Transaction", b =>
                {
                    b.HasOne("BankingSystem.Data.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Data.User", "TrnBy")
                        .WithMany()
                        .HasForeignKey("TrnById");

                    b.Navigation("Account");

                    b.Navigation("TrnBy");
                });

            modelBuilder.Entity("BankingSystem.Data.TransferTransaction", b =>
                {
                    b.HasOne("BankingSystem.Data.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BankingSystem.Data.Transfer", "Transfer")
                        .WithMany("TransferTransactions")
                        .HasForeignKey("TransferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Transaction");

                    b.Navigation("Transfer");
                });

            modelBuilder.Entity("BankingSystem.Data.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BankingSystem.Data.Transfer", b =>
                {
                    b.Navigation("TransferTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
