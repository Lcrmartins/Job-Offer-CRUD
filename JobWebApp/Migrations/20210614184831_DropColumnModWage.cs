using Microsoft.EntityFrameworkCore.Migrations;

namespace JobWebApp.Migrations
{
    public partial class DropColumnModWage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModWage",
                table: "JobOffer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ModWage",
                table: "JobOffer",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
