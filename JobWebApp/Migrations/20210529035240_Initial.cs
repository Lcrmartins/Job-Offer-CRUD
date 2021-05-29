using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobWebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    IdType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.IdType);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Local = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Responsibility = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Requirement = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Wage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Contribution = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Position_IdType",
                        column: x => x.IdType,
                        principalTable: "Position",
                        principalColumn: "IdType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Job_IdType",
                table: "Job",
                column: "IdType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
