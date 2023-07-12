using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OptechX.Portal.Shared.Models.Forms
{
    public class EditionResult
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string ReleaseSelect { get; set; } = null!;
        public List<string>? ReleaseResult { get; set; }
    }

    public class EditionResultConfiguration : IEntityTypeConfiguration<EditionResult>
    {
        public void Configure(EntityTypeBuilder<EditionResult> builder)
        {
            builder.Property(a => a.ReleaseResult)
            .HasConversion(
                v => string.Join(',', v!),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        }
    }
}

