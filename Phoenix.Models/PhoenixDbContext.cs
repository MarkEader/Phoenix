using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Phoenix.Models
{
    public class PhoenixDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public PhoenixDbContext(DbContextOptions<PhoenixDbContext> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=brockenterprise.database.windows.net;Database=Phoenix;user id=brock_dbadmin;password=F1r3St@rter");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<TimeSheet> TimeSheets { get; set; }
        public DbSet<TimeSheetHeader> TimeSheetHeaders { get; set; }
    }
}