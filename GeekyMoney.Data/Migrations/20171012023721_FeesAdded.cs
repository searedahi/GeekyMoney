using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeekyMoney.Data.Migrations
{
    public partial class FeesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateProperty_RealEstateProperty_RealEstatePropertyID",
                table: "RealEstateProperty");

            migrationBuilder.DropTable(
                name: "RentalRate");

            migrationBuilder.DropIndex(
                name: "IX_RealEstateProperty_RealEstatePropertyID",
                table: "RealEstateProperty");

            migrationBuilder.DropColumn(
                name: "RealEstatePropertyID",
                table: "RealEstateProperty");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealEstatePropertyID",
                table: "RealEstateProperty",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RentalRate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RealEstatePropertyID = table.Column<int>(nullable: true),
                    RentalAmount = table.Column<decimal>(nullable: false),
                    ScheduleTypeID = table.Column<int>(nullable: false)
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
                name: "IX_RealEstateProperty_RealEstatePropertyID",
                table: "RealEstateProperty",
                column: "RealEstatePropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_RentalRate_RealEstatePropertyID",
                table: "RentalRate",
                column: "RealEstatePropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateProperty_RealEstateProperty_RealEstatePropertyID",
                table: "RealEstateProperty",
                column: "RealEstatePropertyID",
                principalTable: "RealEstateProperty",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
