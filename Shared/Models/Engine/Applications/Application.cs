using OptechX.Portal.Shared.Models.Engine.Constants;

namespace OptechX.Portal.Shared.Models.Engine.Applications
{
    public class Application
    {
        public int Id { get; set; }
        public string UID { get; set; } = null!;
        public DateTime LastUpdate { get; set; }
        public ApplicationCategory ApplicationCategory { get; set; }
        public string Publisher { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Version { get; set; } = null!;
        public string Copyright { get; set; } = null!;
        public bool LicenseAcceptRequired { get; set; } = false;
        public string[]? Lcid { get; set; }
        public string[]? CpuArch { get; set; }
        public string Homepage { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string Docs { get; set; } = null!;
        public string License { get; set; } = null!;
        public string[]? Tags { get; set; }
        public string Summary { get; set; } = null!;
        public bool Enabled { get; set; } = true;
        public string? BannerIcon { get; set; }

        public Application()
        {
            LastUpdate = DateTime.Today.Date;
        }
    }
}
