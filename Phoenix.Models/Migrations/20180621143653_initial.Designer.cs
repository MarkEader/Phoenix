﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Phoenix.Models;

namespace Phoenix.Models.Migrations
{
    [DbContext(typeof(PhoenixDbContext))]
    [Migration("20180621143653_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Phoenix.Models.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archived");

                    b.Property<string>("ContractId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("LastUpdateBy");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("Phoenix.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archived");

                    b.Property<int>("EmployeeNumber");

                    b.Property<Guid?>("EmploymentStatusId");

                    b.Property<string>("FirstName");

                    b.Property<Guid?>("JobId");

                    b.Property<DateTime?>("LastHireDate");

                    b.Property<string>("LastName");

                    b.Property<string>("LastUpdateBy");

                    b.Property<DateTime>("LastUpdated");

                    b.HasKey("Id");

                    b.HasIndex("EmploymentStatusId");

                    b.HasIndex("JobId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Phoenix.Models.EmploymentStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archived");

                    b.Property<string>("EmploymentStatusDescription");

                    b.Property<int>("EmploymentStatusId");

                    b.Property<string>("LastUpdateBy");

                    b.Property<DateTime>("LastUpdated");

                    b.HasKey("Id");

                    b.ToTable("EmploymentStatus");
                });

            modelBuilder.Entity("Phoenix.Models.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archived");

                    b.Property<decimal>("BasePayRate");

                    b.Property<string>("JobDescription");

                    b.Property<string>("JobId");

                    b.Property<string>("LastUpdateBy");

                    b.Property<DateTime>("LastUpdated");

                    b.HasKey("Id");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Phoenix.Models.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archived");

                    b.Property<Guid?>("ContractId");

                    b.Property<string>("LastUpdateBy");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("SiteId");

                    b.Property<string>("SiteName");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Site");
                });

            modelBuilder.Entity("Phoenix.Models.TimeSheet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archived");

                    b.Property<DateTime>("ClockInDateTime");

                    b.Property<DateTime?>("ClockOutDateTime");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<decimal>("Hours");

                    b.Property<string>("LastUpdateBy");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<long>("TimeSheetId");

                    b.Property<DateTime>("WorkDate");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeSheet");
                });

            modelBuilder.Entity("Phoenix.Models.TimeSheetHeader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Archived");

                    b.Property<Guid?>("ContractId");

                    b.Property<DateTime>("EndDate");

                    b.Property<Guid?>("ForemanId");

                    b.Property<string>("LastUpdateBy");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("PurchaseOrder");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("WorkOrder");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("ForemanId");

                    b.ToTable("TimeSheetHeader");
                });

            modelBuilder.Entity("Phoenix.Models.Employee", b =>
                {
                    b.HasOne("Phoenix.Models.EmploymentStatus", "EmploymentStatus")
                        .WithMany()
                        .HasForeignKey("EmploymentStatusId");

                    b.HasOne("Phoenix.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId");
                });

            modelBuilder.Entity("Phoenix.Models.Site", b =>
                {
                    b.HasOne("Phoenix.Models.Contract")
                        .WithMany("Site")
                        .HasForeignKey("ContractId");
                });

            modelBuilder.Entity("Phoenix.Models.TimeSheet", b =>
                {
                    b.HasOne("Phoenix.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Phoenix.Models.TimeSheetHeader", b =>
                {
                    b.HasOne("Phoenix.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId");

                    b.HasOne("Phoenix.Models.Employee", "Foreman")
                        .WithMany()
                        .HasForeignKey("ForemanId");
                });
#pragma warning restore 612, 618
        }
    }
}
