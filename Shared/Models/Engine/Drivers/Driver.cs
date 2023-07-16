using OptechX.Portal.Shared.Models.Constants;
using OptechX.Portal.Shared.Models.Engine.Constants;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OptechX.Portal.Shared.Models.Engine.Drivers
{

    public class MaxCurrentYearAttribute : RangeAttribute
    {
        public MaxCurrentYearAttribute(int minimum) : base(minimum, DateTime.Now.Year)
        {
        }
    }

    public class Driver
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string UID { get; set; } = null!;
        public OriginalEquipmentManufacturer Oem { get; set; }

        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;

        public string? CspVersion { get; set; }  // used for Lenovo only
        public string? CspName { get; set; }     // used for Lenovo only

        public string Version { get; set; } = null!;  // current Drivers package version
        public string BiosVersion { get; set; } = null!;  // current BIOS version

        [MaxCurrentYear(1900)]
        public int? ProductionYear { get; set; }   // when was the PC introduced to market?

        public string OemInstallClass { get; set; } = null!;

        public CpuArch? CpuArch { get; set; }

        public string Uri { get; set; } = null!;
        public string OutFile { get; set; } = null!;

        public bool Latest { get; set; }
        public DateTime LastUpdate { get; set; }

        public SupportedWinRelease WindowsRelease { get; set; }

        public SupportedWin10Version SupportedWindowsVersion { get; set; }

        public string? UrlVTScan { get; set; }
        public int? ExploitReportId { get; set; }

        public string? WmiObjectName { get; set; }  //repasscloud/optechx.api.engine/issues/15
        public string? WmiObjectVendor { get; set; }  //repasscloud/optechx.api.engine/issues/15
        public string? WmiObjectVersion { get; set; }  //repasscloud/optechx.api.engine/issues/15
        public string? WmiObjectCaption { get; set; }  //repasscloud/optechx.api.engine/issues/15

        public bool CloudDeploySupport { get; set; }

        public string? ScriptInstall { get; set; }

        public string? Notes { get; set; }

        public Driver()
        {
            ProductionYear = 1900;
            ExploitReportId = 0;
            CloudDeploySupport = false;
            LastUpdate = DateTime.Today.Date;
        }
    }
}

