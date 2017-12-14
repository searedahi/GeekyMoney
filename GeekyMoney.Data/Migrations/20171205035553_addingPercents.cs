using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Migrations
{
    public partial class addingPercents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PercentBaseValue",
                table: "Fee",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PercentBasedOn",
                table: "Fee",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentRate",
                table: "Fee",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentBaseValue",
                table: "Fee");

            migrationBuilder.DropColumn(
                name: "PercentBasedOn",
                table: "Fee");

            migrationBuilder.DropColumn(
                name: "PercentRate",
                table: "Fee");
        }
    }
}
