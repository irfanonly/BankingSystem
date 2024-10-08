﻿// <auto-generated />
using System;
using BankingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankingSystem.Migrations
{
    [DbContext(typeof(BankAccDBContext))]
    partial class BankAccDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("68bdec11-c4d8-4975-8f57-9935c496ce24"),
                            AccountTypeId = 1,
                            Balance = 5000.00m,
                            IsClosed = false,
                            Name = "Primary Savings Account"
                        },
                        new
                        {
                            Id = new Guid("c60eae6b-6b87-4529-95f8-78e63f53aaec"),
                            AccountTypeId = 2,
                            Balance = 15000.00m,
                            IsClosed = false,
                            Name = "Business Checking Account"
                        },
                        new
                        {
                            Id = new Guid("6b7f38e9-ba51-4f84-a79f-c7b97740a8f8"),
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
                            CreatedOn = new DateTime(2024, 10, 8, 11, 13, 10, 213, DateTimeKind.Utc).AddTicks(6567),
                            IsDeleted = false,
                            Name = "Savings",
                            UpdatedOn = new DateTime(2024, 10, 8, 11, 13, 10, 213, DateTimeKind.Utc).AddTicks(6568)
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2024, 10, 8, 11, 13, 10, 213, DateTimeKind.Utc).AddTicks(6571),
                            IsDeleted = false,
                            Name = "Checking",
                            UpdatedOn = new DateTime(2024, 10, 8, 11, 13, 10, 213, DateTimeKind.Utc).AddTicks(6571)
                        });
                });

            modelBuilder.Entity("BankingSystem.Data.ClosedAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AccID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClosedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ClosedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

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
                            AccountId = new Guid("68bdec11-c4d8-4975-8f57-9935c496ce24"),
                            Amount = 500.00m,
                            TrnMethod = "Deposit",
                            TrnOn = new DateTime(2024, 10, 8, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6806),
                            TrnType = "Credit"
                        },
                        new
                        {
                            Id = 2L,
                            AccountId = new Guid("68bdec11-c4d8-4975-8f57-9935c496ce24"),
                            Amount = 100.00m,
                            TrnMethod = "Withdrawal",
                            TrnOn = new DateTime(2024, 10, 6, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6820),
                            TrnType = "Debit"
                        },
                        new
                        {
                            Id = 3L,
                            AccountId = new Guid("c60eae6b-6b87-4529-95f8-78e63f53aaec"),
                            Amount = 2000.00m,
                            TrnMethod = "Deposit",
                            TrnOn = new DateTime(2024, 10, 3, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6826),
                            TrnType = "Credit"
                        },
                        new
                        {
                            Id = 4L,
                            AccountId = new Guid("6b7f38e9-ba51-4f84-a79f-c7b97740a8f8"),
                            Amount = 5000.00m,
                            TrnMethod = "Deposit",
                            TrnOn = new DateTime(2024, 9, 8, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6829),
                            TrnType = "Credit"
                        },
                        new
                        {
                            Id = 5L,
                            AccountId = new Guid("6b7f38e9-ba51-4f84-a79f-c7b97740a8f8"),
                            Amount = 3000.00m,
                            TrnMethod = "Deposit",
                            TrnOn = new DateTime(2024, 8, 8, 15, 13, 10, 213, DateTimeKind.Local).AddTicks(6834),
                            TrnType = "Credit"
                        });
                });

            modelBuilder.Entity("BankingSystem.Data.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FromTransferId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToTransferId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Transfers");
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
                    b.HasOne("BankingSystem.Data.User", "ClosedBy")
                        .WithMany()
                        .HasForeignKey("ClosedById");

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

            modelBuilder.Entity("BankingSystem.Data.Account", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
