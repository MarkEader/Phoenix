using System;
using Phoenix.Models.Base;

namespace Phoenix.Models
{
    public class TimeSheet : MasterDataModel
    {
        public long TimeSheetId { get; set; }
        public virtual Employee Employee { get; set; }
        public decimal Hours { get; set; }
        public DateTime WorkDate { get; set; }
        public DateTime ClockInDateTime { get; set; }
        public DateTime? ClockOutDateTime { get; set; }
    }
}