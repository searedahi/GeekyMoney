using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GeekyMoney.Data.Migrations
{
    public partial class afterAddingMultiples : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scenario_Mortgage_MortgageID",
                table: "Scenario");

            migrationBuilder.DropForeignKey(
                name: "FK_Scenario_RealEstateProperty_RealEstatePropertyID",
                table: "Scenario");

            migrationBuilder.DropIndex(
                name: "IX_Scenario_MortgageID",
                table: "Scenario");

            migrationBuilder.DropIndex(
                name: "IX_Scenario_RealEstatePropertyID",
                table: "Scenario");

            migrationBuilder.DropColumn(
                name: "MortgageID",
                table: "Scenario");

            migrationBuilder.DropColumn(
                name: "RealEstatePropertyID",
                table: "Scenario");

            migrationBuilder.AddColumn<int>(
                name: "ScenarioID",
                table: "RealEstateProperty",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScenarioID",
                table: "Mortgage",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProperty_ScenarioID",
                table: "RealEstateProperty",
                column: "ScenarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Mortgage_ScenarioID",
                table: "Mortgage",
                column: "ScenarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mortgage_Scenario_ScenarioID",
                table: "Mortgage",
                column: "ScenarioID",
                principalTable: "Scenario",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateProperty_Scenario_ScenarioID",
                table: "RealEstateProperty",
                column: "ScenarioID",
                principalTable: "Scenario",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mortgage_Scenario_ScenarioID",
                table: "Mortgage");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateProperty_Scenario_ScenarioID",
                table: "RealEstateProperty");

            migrationBuilder.DropIndex(
                name: "IX_RealEstateProperty_ScenarioID",
                table: "RealEstateProperty");

            migrationBuilder.DropIndex(
                name: "IX_Mortgage_ScenarioID",
                table: "Mortgage");

            migrationBuilder.DropColumn(
                name: "ScenarioID",
                table: "RealEstateProperty");

            migrationBuilder.DropColumn(
                name: "ScenarioID",
                table: "Mortgage");

            migrationBuilder.AddColumn<int>(
                name: "MortgageID",
                table: "Scenario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RealEstatePropertyID",
                table: "Scenario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scenario_MortgageID",
                table: "Scenario",
                column: "MortgageID");

            migrationBuilder.CreateIndex(
                name: "IX_Scenario_RealEstatePropertyID",
                table: "Scenario",
                column: "RealEstatePropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Scenario_Mortgage_MortgageID",
                table: "Scenario",
                column: "MortgageID",
                principalTable: "Mortgage",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Scenario_RealEstateProperty_RealEstatePropertyID",
                table: "Scenario",
                column: "RealEstatePropertyID",
                principalTable: "RealEstateProperty",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
