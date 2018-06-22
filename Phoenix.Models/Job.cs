using System;
using System.ComponentModel.DataAnnotations.Schema;
using Phoenix.Models.Base;
using Phoenix.Models.Interface;

namespace Phoenix.Models
{
    public class Job : MasterDataModel
    {
        public string Lookup { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(9, 2)")]
        public decimal BasePayRate { get; set; }
        public string GetLookup() => Lookup;
        public string GetDescription() => Description;
        public decimal GetBasePayRate() => BasePayRate;
    }
    public class JobDto : IDto
    {
        public Guid Id { get; set; }
        public string JobId { get; set; }
        public string JobDescription { get; set; }
        public decimal BasePayRate { get; set; }
    }
}