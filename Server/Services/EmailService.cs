using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace OptechX.Portal.Server.Services
{
	public class EmailService : IEmailService
	{
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAsync(string to, string subject, string html, string? from = null)
        {
            // create email
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from ?? _configuration["EmailConfig:From"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };

            // send email
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(
                host: _configuration["EmailConfig:SmtpHost"],
                port: int.Parse(_configuration["EmailConfig:Port"]!),
                options: SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(
                userName: _configuration["EmailConfig:SmtpUser"],
                password: _configuration["EmailConfig:SmtpPass"]);

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);

        }
    }
}

