using System;
using System.ComponentModel.DataAnnotations;
using Phoenix.Models.Base;
using Phoenix.Models.Interface;

namespace Phoenix.Models
{
    public class Employee : MasterDataModel
    {
        public int EmployeeNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime? LastHireDate { get; set; }
        public Guid? JobId { get; set; }
        public Guid? EmploymentStatusId { get; set; }
        public virtual Job Job { get; set; }
        public virtual EmploymentStatus EmploymentStatus { get; set; }
    }

    public class EmployeeDto : IDto
    {
        [Display(AutoGenerateField = false)]
        public Guid Id { get; set; }
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastHireDate { get; set; }
        public string JobLookup { get; set; }
        public string JobDescription { get; set; }
        public decimal JobBasePayRate { get; set; }
        public int EmploymentStatusLookup { get; set; }
        public string EmploymentStatusDescription { get; set; }
    }
}