namespace SensorSiteApi.models
{
    public class SensorSite
    {
        public int Id { get; set; }
        public string SiteName { get; set; } = string.Empty;
        public string Zone { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime LastContact { get; set; }
    }
}
