using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Migrations
{
    public partial class InitialStabAtIt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstateProperty",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppreciationRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMultiUnit = table.Column<bool>(type: "bit", nullable: false),
                    MLSID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OccupancyRate = table.Column<double>(type: "float", nullable: false),
                    PropertyTaxAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PropertyTaxRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    PropertyValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    RealEstatePropertyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeductible = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealEstatePropertyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealEstatePropertyID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
