using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Phoenix.Models.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<string>(nullable: true),
                    ContractId = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<string>(nullable: true),
                    EmploymentStatusId = table.Column<int>(nullable: false),
                    EmploymentStatusDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<string>(nullable: true),
                    JobId = table.Column<string>(nullable: true),
                    JobDescription = table.Column<string>(nullable: true),
                    BasePayRate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<string>(nullable: true),
                    SiteId = table.Column<string>(nullable: true),
                    SiteName = table.Column<string>(nullable: true),
                    ContractId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Site_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<string>(nullable: true),
                    EmployeeNumber = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LastHireDate = table.Column<DateTime>(nullable: true),
                    JobId = table.Column<Guid>(nullable: true),
                    EmploymentStatusId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_EmploymentStatus_EmploymentStatusId",
                        column: x => x.EmploymentStatusId,
                        principalTable: "EmploymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Job_JobId",
                        column: x => x.JobId,
                        principalTable: "Job",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<string>(nullable: true),
                    TimeSheetId = table.Column<long>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: true),
                    Hours = table.Column<decimal>(nullable: false),
                    WorkDate = table.Column<DateTime>(nullable: false),
                    ClockInDateTime = table.Column<DateTime>(nullable: false),
                    ClockOutDateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheet_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheetHeader",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    LastUpdateBy = table.Column<string>(nullable: true),
                    PurchaseOrder = table.Column<string>(nullable: true),
                    WorkOrder = table.Column<string>(nullable: true),
                    ContractId = table.Column<Guid>(nullable: true),
                    ForemanId = table.Column<Guid>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheetHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheetHeader_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeSheetHeader_Employee_ForemanId",
                        column: x => x.ForemanId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmploymentStatusId",
                table: "Employee",
                column: "EmploymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobId",
                table: "Employee",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Site_ContractId",
                table: "Site",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheet_EmployeeId",
                table: "TimeSheet",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetHeader_ContractId",
                table: "TimeSheetHeader",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheetHeader_ForemanId",
                table: "TimeSheetHeader",
                column: "ForemanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Site");

            migrationBuilder.DropTable(
                name: "TimeSheet");

            migrationBuilder.DropTable(
                name: "TimeSheetHeader");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmploymentStatus");

            migrationBuilder.DropTable(
                name: "Job");
        }
    }
}
