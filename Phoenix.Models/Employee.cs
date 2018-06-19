using System;
using System.ComponentModel.DataAnnotations;
using Phoenix.Models.Base;
using Phoenix.Models.Interface;

namespace Phoenix.Models
{
    public class Employee : MasterDataModel
    {
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastHireDate { get; set; }
        public Job Job { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
    }

    public class EmployeeDto : IDto
    {
        [Display(AutoGenerateField = false)]
        public Guid Id { get; set; }
        public int EmployeeNumber { get; set; }
        public string EmploymentStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastHireDate { get; set; }
        public string JobId { get; set; }
        public string JobDescription { get; set; }
        public decimal BasePayRate { get; set; }
        public int EmploymentStatusId { get; set; }
        public string EmploymentStatusDescription { get; set; }
    }
}