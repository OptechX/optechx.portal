using OptechX.Portal.Shared.Models.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptechX.Portal.Shared.Models.Engine.Drivers
{
    public class DriverCore
    {
        [Key]
        public int Id { get; set; }
        public string UID { get; set; } = null!;
        public OriginalEquipmentManufacturer Oem { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public DateTime LastUpdated { get; set; }
        public string SupportedWinReleaseString { get; set; } = null!;

        [NotMapped]
        public string[]? SupportedWinRelease
        {
            get => SupportedWinReleaseString?.Split(',', StringSplitOptions.RemoveEmptyEntries);
            set => SupportedWinReleaseString = value != null ? string.Join(',', value) : SupportedWinReleaseString;
        }
    }
}

