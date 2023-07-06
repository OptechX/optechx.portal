using System.ComponentModel.DataAnnotations.Schema;
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
        public string LcidString { get; set; } = null!;
        public string CpuArchString { get; set; } = null!;
        public string Homepage { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string Docs { get; set; } = null!;
        public string License { get; set; } = null!;
        public string TagsString { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public bool Enabled { get; set; } = true;
        public string? BannerIcon { get; set; }

        [NotMapped]
        public string[]? Lcid
        {
            get => LcidString?.Split(',', StringSplitOptions.RemoveEmptyEntries);
            set => LcidString = value != null ? string.Join(',', value) : LcidString;
        }

        [NotMapped]
        public string[]? CpuArch
        {
            get => CpuArchString?.Split(',', StringSplitOptions.RemoveEmptyEntries);
            set => CpuArchString = value != null ? string.Join(',', value) : CpuArchString;
        }

        [NotMapped]
        public string[]? Tags
        {
            get => TagsString?.Split(',', StringSplitOptions.RemoveEmptyEntries);
            set => TagsString = value != null ? string.Join(',', value) : TagsString;
        }
    }
}
