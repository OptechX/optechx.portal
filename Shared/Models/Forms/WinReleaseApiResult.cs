using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OptechX.Portal.Shared.Models.Forms
{
    public class WinReleaseApiResult
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string ReleaseSelect { get; set; } = null!;
        public List<string>? EditionResult { get; set; }
    }

    public class WinReleaseApiResultConfiguration : IEntityTypeConfiguration<WinReleaseApiResult>
    {
        public void Configure(EntityTypeBuilder<WinReleaseApiResult> builder)
        {
            builder.Property(a => a.EditionResult)
            .HasConversion(
                v => string.Join(',', v!),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}

