﻿// <auto-generated />
using System;
using BarBalanceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BarBalanceAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240103123745_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BarBalanceAPI.Models.Revenue", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("CardPayments")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("CardTips")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("CashClosing")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("CashOpening")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("CashReceived")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("CashWithdrawn")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("DailyIncome")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("DailyReport")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("DailyRevenueTotal")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("InternalExpenditure")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("InvoicesWithoutFiscalization")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("SafeClosing")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("SafeOpening")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateOnly>("ShiftDate")
                        .HasColumnType("date");

                    b.HasKey("ID");

                    b.ToTable("Revenues");
                });
#pragma warning restore 612, 618
        }
    }
}
