using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OptechX.Portal.Shared.Models.Forms
{
    public class WinEditionApiResult
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string EditionSelect { get; set; } = null!;
        public List<string>? VersionResult { get; set; }
    }

    public class WinEditionApiResultConfiguration : IEntityTypeConfiguration<WinEditionApiResult>
    {
        public void Configure(EntityTypeBuilder<WinEditionApiResult> builder)
        {
            builder.Property(a => a.VersionResult)
            .HasConversion(
                v => string.Join(',', v!),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}

