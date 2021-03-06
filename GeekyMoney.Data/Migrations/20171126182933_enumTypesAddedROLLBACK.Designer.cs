﻿// <auto-generated />
using GeekyMoney.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GeekyMoney.Data.Migrations
{
    [DbContext(typeof(GeekyMoneyContext))]
    [Migration("20171126182933_enumTypesAddedROLLBACK")]
    partial class enumTypesAddedROLLBACK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeekyMoney.Data.Model.Fee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("Description");

                    b.Property<int>("FeeTypeID");

                    b.Property<bool>("IsDeductible");

                    b.Property<bool>("IsTemplate");

                    b.Property<int?>("MortgageID");

                    b.Property<string>("Name");

                    b.Property<int?>("RealEstatePropertyID");

                    b.Property<int>("ScheduleTypeID");

                    b.HasKey("ID");

                    b.HasIndex("MortgageID");

                    b.HasIndex("RealEstatePropertyID");

                    b.ToTable("Fee");
                });

            modelBuilder.Entity("GeekyMoney.Data.Model.Mortgage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<decimal>("DownPayment");

                    b.Property<decimal>("InterestRate");

                    b.Property<decimal>("LoanAmount");

                    b.Property<string>("Name");

                    b.Property<decimal>("PrincipleAmount");

                    b.Property<double>("TermInMonths");

                    b.Property<double>("TermInYears");

                    b.HasKey("ID");

                    b.ToTable("Mortgage");
                });

            modelBuilder.Entity("GeekyMoney.Data.Model.RealEstateProperty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<decimal>("AppreciationRate");

                    b.Property<decimal>("AskingPrice");

                    b.Property<DateTime>("Built");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMultiUnit");

                    b.Property<DateTime>("Listed");

                    b.Property<string>("MLSID");

                    b.Property<decimal>("MarketValue");

                    b.Property<string>("Name");

                    b.Property<double>("OccupancyRate");

                    b.Property<decimal>("PropertyTaxAmount");

                    b.Property<decimal>("PropertyTaxRate");

                    b.Property<decimal>("PurchasePrice");

                    b.Property<decimal>("Rating");

                    b.Property<string>("RedFinId");

                    b.Property<decimal>("SquareFeet");

                    b.Property<decimal>("TotalMonthlyCost");

                    b.Property<string>("TruliaId");

                    b.Property<string>("ZillowId");

                    b.HasKey("ID");

                    b.ToTable("RealEstateProperty");
                });

            modelBuilder.Entity("GeekyMoney.Data.Model.RentalRate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<decimal>("RentalAmount");

                    b.Property<int>("ScheduleTypeID");

                    b.HasKey("ID");

                    b.ToTable("RentalRate");
                });

            modelBuilder.Entity("GeekyMoney.Data.Model.Scenario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("MortgageID");

                    b.Property<string>("Name");

                    b.Property<int?>("RealEstatePropertyID");

                    b.Property<int?>("RentalRateID");

                    b.HasKey("ID");

                    b.HasIndex("MortgageID");

                    b.HasIndex("RealEstatePropertyID");

                    b.HasIndex("RentalRateID");

                    b.ToTable("Scenario");
                });

            modelBuilder.Entity("GeekyMoney.Data.Model.Fee", b =>
                {
                    b.HasOne("GeekyMoney.Data.Model.Mortgage")
                        .WithMany("LoanFees")
                        .HasForeignKey("MortgageID");

                    b.HasOne("GeekyMoney.Data.Model.RealEstateProperty")
                        .WithMany("PropertyFees")
                        .HasForeignKey("RealEstatePropertyID");
                });

            modelBuilder.Entity("GeekyMoney.Data.Model.Scenario", b =>
                {
                    b.HasOne("GeekyMoney.Data.Model.Mortgage", "Mortgage")
                        .WithMany()
                        .HasForeignKey("MortgageID");

                    b.HasOne("GeekyMoney.Data.Model.RealEstateProperty", "RealEstateProperty")
                        .WithMany()
                        .HasForeignKey("RealEstatePropertyID");

                    b.HasOne("GeekyMoney.Data.Model.RentalRate", "RentalRate")
                        .WithMany()
                        .HasForeignKey("RentalRateID");
                });
#pragma warning restore 612, 618
        }
    }
}
