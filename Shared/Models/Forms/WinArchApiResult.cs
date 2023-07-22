using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OptechX.Portal.Shared.Models.Forms
{
    public class WinArchApiResult
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string ArchSelect { get; set; } = null!;
        public List<string>? LcidResult { get; set; }
    }

    public class WinArchApiResultConfiguration : IEntityTypeConfiguration<WinArchApiResult>
    {
        public void Configure(EntityTypeBuilder<WinArchApiResult> builder)
        {
            builder.Property(a => a.LcidResult)
            .HasConversion(
                v => string.Join(',', v!),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}