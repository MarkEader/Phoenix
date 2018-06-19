using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Phoenix.Models.Base;

namespace Phoenix.Models
{
    public class Contract : MasterDataModel
    {
        public string ContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EnDate { get; set; }
        public virtual ICollection<Site> Site { get; set; }
    }
}