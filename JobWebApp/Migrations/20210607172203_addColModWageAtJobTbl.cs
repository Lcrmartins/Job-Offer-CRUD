using Microsoft.EntityFrameworkCore.Migrations;

namespace JobWebApp.Migrations
{
    public partial class addColModWageAtJobTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ModWage",
                table: "Job",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModWage",
                table: "Job");
        }
    }
}
