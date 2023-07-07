namespace OptechX.Portal.Server.Services
{
	public interface IEmailService
	{
        Task SendAsync(string to, string subject, string html, string? from = null);
    }
}

