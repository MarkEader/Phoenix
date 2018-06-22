using System;
using Phoenix.Models.Base;

namespace Phoenix.Models
{
    public class TimeSheetHeader : MasterDataModel
    {
        public string PurchaseOrder { get; set; }
        public string WorkOrder { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual Employee Foreman { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}