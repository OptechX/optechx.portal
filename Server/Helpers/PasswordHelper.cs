namespace OptechX.Portal.Server.Helpers
{
    public class PasswordHelper
    {
        public static string GenerateSaltAndHashPassword(string salt, string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password + salt);
            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string storedHashedPassword, string storedSalt)
        {
            if (storedHashedPassword == string.Empty || storedSalt == string.Empty)
                return false;

            return BCrypt.Net.BCrypt.Verify(password + storedSalt, storedHashedPassword);
        }
    }
}

