using System;
using Phoenix.Models.Base;

namespace Phoenix.Models
{
    public class EmploymentStatus : MasterDataModel
    {
        public int Lookup { get; set; }
        public string Description { get; set; }

        public int GetLookup() => Lookup;

        public string GetDescription() => Description;
    }
}