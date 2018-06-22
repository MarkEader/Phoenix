using Microsoft.EntityFrameworkCore.Migrations;

namespace Phoenix.Models.Migrations
{
    public partial class job_model_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Job",
                newName: "Lookup");

            migrationBuilder.RenameColumn(
                name: "JobDescription",
                table: "Job",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "EmploymentStatusLookup",
                table: "EmploymentStatus",
                newName: "Lookup");

            migrationBuilder.RenameColumn(
                name: "EmploymentStatusDescription",
                table: "EmploymentStatus",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lookup",
                table: "Job",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Job",
                newName: "JobDescription");

            migrationBuilder.RenameColumn(
                name: "Lookup",
                table: "EmploymentStatus",
                newName: "EmploymentStatusLookup");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "EmploymentStatus",
                newName: "EmploymentStatusDescription");
        }
    }
}
