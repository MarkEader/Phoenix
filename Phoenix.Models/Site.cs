using Phoenix.Models.Base;

namespace Phoenix.Models
{
    public class Site : MasterDataModel
    {
        public string SiteId { get; set; }
        public string SiteName { get; set; }
    }
}