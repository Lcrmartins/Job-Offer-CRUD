using Microsoft.EntityFrameworkCore.Migrations;

namespace JobWebApp.Migrations
{
    public partial class corrNameBenefitJobOfferTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contribution",
                table: "JobOffer",
                newName: "Benefit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Benefit",
                table: "JobOffer",
                newName: "Contribution");
        }
    }
}
