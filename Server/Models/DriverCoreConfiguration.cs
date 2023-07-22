using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OptechX.Portal.Shared.Models.Engine.Drivers;

namespace OptechX.Portal.Server.Models
{
    public class DriverCoreConfiguration : IEntityTypeConfiguration<DriverCore>
    {
        public void Configure(EntityTypeBuilder<DriverCore> builder)
        {
            builder.Property(a => a.SupportedWinReleaseString).HasColumnName("SupportedWinRelease");
        }
    }
}

