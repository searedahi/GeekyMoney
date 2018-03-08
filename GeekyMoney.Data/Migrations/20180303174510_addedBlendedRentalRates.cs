using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Migrations
{
    public partial class addedBlendedRentalRates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BeginDate",
                table: "RentalRate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BlendedRentalRateID",
                table: "RentalRate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "RentalRate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BlendedRentalRate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ScheduleTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlendedRentalRate", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalRate_BlendedRentalRateID",
                table: "RentalRate",
                column: "BlendedRentalRateID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalRate_BlendedRentalRate_BlendedRentalRateID",
                table: "RentalRate",
                column: "BlendedRentalRateID",
                principalTable: "BlendedRentalRate",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalRate_BlendedRentalRate_BlendedRentalRateID",
                table: "RentalRate");

            migrationBuilder.DropTable(
                name: "BlendedRentalRate");

            migrationBuilder.DropIndex(
                name: "IX_RentalRate_BlendedRentalRateID",
                table: "RentalRate");

            migrationBuilder.DropColumn(
                name: "BeginDate",
                table: "RentalRate");

            migrationBuilder.DropColumn(
                name: "BlendedRentalRateID",
                table: "RentalRate");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "RentalRate");
        }
    }
}
