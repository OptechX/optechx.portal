namespace OptechX.Portal.Server.Helpers
{
    public class OptechXValueGenerator
    {
        private static Random random = new();
        private const string characters = "ABCDEFGHJKLMNOPQRSTUVWXYZ23456789";

        public static string GenerateRandomString(int length)
        {
            return new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

