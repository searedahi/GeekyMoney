using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Migrations
{
    public partial class parentClassAddedToFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentClass",
                table: "Fee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentClass",
                table: "Fee");
        }
    }
}
