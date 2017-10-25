using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Migrations
{
    public partial class ratingsAddedToProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "RealEstateProperty",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "RentalRate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ScheduleTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalRate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Scenario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MortgageID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealEstatePropertyID = table.Column<int>(type: "int", nullable: true),
                    RentalRateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Scenario_Mortgage_MortgageID",
                        column: x => x.MortgageID,
                        principalTable: "Mortgage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenario_RealEstateProperty_RealEstatePropertyID",
                        column: x => x.RealEstatePropertyID,
                        principalTable: "RealEstateProperty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scenario_RentalRate_RentalRateID",
                        column: x => x.RentalRateID,
                        principalTable: "RentalRate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scenario_MortgageID",
                table: "Scenario",
                column: "MortgageID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenario_RealEstatePropertyID",
                table: "Scenario",
                column: "RealEstatePropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenario_RentalRateID",
                table: "Scenario",
                column: "RentalRateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scenario");

            migrationBuilder.DropTable(
                name: "RentalRate");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "RealEstateProperty");
        }
    }
}
