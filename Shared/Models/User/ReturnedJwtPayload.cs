namespace OptechX.Portal.Shared.Models.User
{
	public class ReturnedJwtPayload
	{
        public string? EmailAddress { get; set; }
        public string? AccountId { get; set; }
        public string? Expiration { get; set; }
        public string? Issuer { get; set; }
    }
}

