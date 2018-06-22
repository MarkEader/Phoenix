using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Phoenix.Models.Migrations
{
    public partial class employee_model_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmploymentStatusId",
                table: "EmploymentStatus",
                newName: "EmploymentStatusLookup");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "TimeSheet",
                type: "decimal(2, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "BasePayRate",
                table: "Job",
                type: "decimal(9, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastHireDate",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmploymentStatusLookup",
                table: "EmploymentStatus",
                newName: "EmploymentStatusId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hours",
                table: "TimeSheet",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BasePayRate",
                table: "Job",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9, 2)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastHireDate",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
