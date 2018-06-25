using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Phoenix.Models.Migrations
{
    public partial class add_fks_to_employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmploymentStatus_EmploymentStatusId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Job_JobId",
                table: "Employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobId",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "EmploymentStatusId",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmploymentStatus_EmploymentStatusId",
                table: "Employee",
                column: "EmploymentStatusId",
                principalTable: "EmploymentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Job_JobId",
                table: "Employee",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmploymentStatus_EmploymentStatusId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Job_JobId",
                table: "Employee");

            migrationBuilder.AlterColumn<Guid>(
                name: "JobId",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmploymentStatusId",
                table: "Employee",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmploymentStatus_EmploymentStatusId",
                table: "Employee",
                column: "EmploymentStatusId",
                principalTable: "EmploymentStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Job_JobId",
                table: "Employee",
                column: "JobId",
                principalTable: "Job",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
