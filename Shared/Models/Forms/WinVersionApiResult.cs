using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OptechX.Portal.Shared.Models.Forms
{
    public class WinVersionApiResult
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string VersionSelect { get; set; } = null!;
        public List<string>? ArchResult { get; set; }
    }

    public class WinVersionApiResultConfiguration : IEntityTypeConfiguration<WinVersionApiResult>
    {
        public void Configure(EntityTypeBuilder<WinVersionApiResult> builder)
        {
            builder.Property(a => a.ArchResult)
            .HasConversion(
                v => string.Join(',', v!),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}

