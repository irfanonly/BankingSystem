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

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
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
                            CreatedOn = new DateTime(2024, 10, 8, 9, 15, 10, 53, DateTimeKind.Local).AddTicks(7486),
                            IsDeleted = true,
                            Name = "Savings",
                            UpdatedOn = new DateTime(2024, 10, 8, 9, 15, 10, 53, DateTimeKind.Local).AddTicks(7496)
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2024, 10, 8, 9, 15, 10, 53, DateTimeKind.Local).AddTicks(7498),
                            IsDeleted = true,
                            Name = "Checking",
                            UpdatedOn = new DateTime(2024, 10, 8, 9, 15, 10, 53, DateTimeKind.Local).AddTicks(7499)
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid>("AccID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AccountId")
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
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                    b.HasOne("BankingSystem.Data.Account", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId");

                    b.HasOne("BankingSystem.Data.User", "TrnBy")
                        .WithMany()
                        .HasForeignKey("TrnById");

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
