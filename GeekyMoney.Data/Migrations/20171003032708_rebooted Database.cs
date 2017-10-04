using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Migrations
{
    public partial class rebootedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstateProperty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppreciationRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AskingPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Built = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMultiUnit = table.Column<bool>(type: "bit", nullable: false),
                    Listed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MLSID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarketValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OccupancyRate = table.Column<double>(type: "float", nullable: false),
                    PropertyTaxAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PropertyTaxRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RealEstatePropertyID = table.Column<int>(type: "int", nullable: true),
                    RedFinId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SquareFeet = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TotalMonthlyCost = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TruliaId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZillowId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateProperty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealEstateProperty_RealEstateProperty_RealEstatePropertyID",
                        column: x => x.RealEstatePropertyID,
                        principalTable: "RealEstateProperty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeductible = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealEstatePropertyID = table.Column<int>(type: "int", nullable: true),
                    ScheduleTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fee_RealEstateProperty_RealEstatePropertyID",
                        column: x => x.RealEstatePropertyID,
                        principalTable: "RealEstateProperty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentalRate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealEstatePropertyID = table.Column<int>(type: "int", nullable: true),
                    RentalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ScheduleTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalRate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RentalRate_RealEstateProperty_RealEstatePropertyID",
                        column: x => x.RealEstatePropertyID,
                        principalTable: "RealEstateProperty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fee_RealEstatePropertyID",
                table: "Fee",
                column: "RealEstatePropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_RealEstatePropertyID",
                table: "RealEstateProperty",
                column: "RealEstatePropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRate_RealEstatePropertyID",
                table: "RentalRate",
                column: "RealEstatePropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fee");

            migrationBuilder.DropTable(
                name: "RentalRate");

            migrationBuilder.DropTable(
                name: "RealEstateProperty");
        }
    }
}
