using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Migrations
{
    public partial class removedPercentOfValueFromFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentBaseValue",
                table: "Fee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PercentBaseValue",
                table: "Fee",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
