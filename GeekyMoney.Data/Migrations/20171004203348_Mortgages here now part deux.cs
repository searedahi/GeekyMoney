using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Migrations
{
    public partial class Mortgagesherenowpartdeux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DownPayment",
                table: "Mortgage",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestRate",
                table: "Mortgage",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LoanAmount",
                table: "Mortgage",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrincipleAmount",
                table: "Mortgage",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "TermInMonths",
                table: "Mortgage",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TermInYears",
                table: "Mortgage",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MortgageID",
                table: "Fee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fee_MortgageID",
                table: "Fee",
                column: "MortgageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fee_Mortgage_MortgageID",
                table: "Fee",
                column: "MortgageID",
                principalTable: "Mortgage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fee_Mortgage_MortgageID",
                table: "Fee");

            migrationBuilder.DropIndex(
                name: "IX_Fee_MortgageID",
                table: "Fee");

            migrationBuilder.DropColumn(
                name: "DownPayment",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "InterestRate",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "LoanAmount",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "PrincipleAmount",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "TermInMonths",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "TermInYears",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "MortgageID",
                table: "Fee");
        }
    }
}
