using System;
using Phoenix.Models.Base;
using Phoenix.Models.Interface;

namespace Phoenix.Models
{
    public class Job : MasterDataModel
    {
        public string JobId { get; set; }
        public string JobDescription { get; set; }
        public decimal BasePayRate { get; set; }
    }
    public class JobDto : IDto
    {
        public Guid Id { get; set; }
        public string JobId { get; set; }
        public string JobDescription { get; set; }
        public decimal BasePayRate { get; set; }
    }
}