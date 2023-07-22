using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace OptechX.Portal.Server.Helpers
{
    public class StringListConverter : ValueConverter<List<string>, string>
    {
        public StringListConverter() : base(
            v => string.Join(',', v),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
        {
        }
    }
}

