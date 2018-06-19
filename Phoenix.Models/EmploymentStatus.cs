using System;
using Phoenix.Models.Base;

namespace Phoenix.Models
{
    public class EmploymentStatus : MasterDataModel
    {
        public int EmploymentStatusId { get; set; }
        public string EmploymentStatusDescription { get; set; }
    }
}