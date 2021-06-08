using Microsoft.EntityFrameworkCore.Migrations;

namespace JobWebApp.Migrations
{
    public partial class altTblNameJobOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Position_IdType",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_jobOfferVM_Job_JobOfferId",
                table: "jobOfferVM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "JobOffer");

            migrationBuilder.RenameIndex(
                name: "IX_Job_IdType",
                table: "JobOffer",
                newName: "IX_JobOffer_IdType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobOffer",
                table: "JobOffer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Position_IdType",
                table: "JobOffer",
                column: "IdType",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobOfferVM_JobOffer_JobOfferId",
                table: "jobOfferVM",
                column: "JobOfferId",
                principalTable: "JobOffer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Position_IdType",
                table: "JobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_jobOfferVM_JobOffer_JobOfferId",
                table: "jobOfferVM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobOffer",
                table: "JobOffer");

            migrationBuilder.RenameTable(
                name: "JobOffer",
                newName: "Job");

            migrationBuilder.RenameIndex(
                name: "IX_JobOffer_IdType",
                table: "Job",
                newName: "IX_Job_IdType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Position_IdType",
                table: "Job",
                column: "IdType",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jobOfferVM_Job_JobOfferId",
                table: "jobOfferVM",
                column: "JobOfferId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
