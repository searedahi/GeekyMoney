using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Migrations
{
    public partial class enumTypesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleTypeID",
                table: "Fee");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleType",
                table: "Fee",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleType",
                table: "Fee");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleTypeID",
                table: "Fee",
                nullable: false,
                defaultValue: 0);
        }
    }
}
