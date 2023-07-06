using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OptechX.Portal.Shared.Models.Engine.Applications;

namespace OptechX.Portal.Server.Models
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.Property(a => a.LcidString).HasColumnName("Lcid");
            builder.Property(a => a.CpuArchString).HasColumnName("CpuArch");
            builder.Property(a => a.TagsString).HasColumnName("Tags");
        }
    }
}

