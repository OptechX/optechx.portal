using Microsoft.AspNetCore.Mvc;
using Stripe;
using OptechX.Portal.Server.Data;
using System.Text.Json;
using OptechX.Portal.Shared.Models.Stripe;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Server.Controllers.Stripe
{
    [Route("api/[controller]")]
    public class StripeWebhookController : Controller
    {
        private readonly ApiDbContext _context;
        private readonly string _endpointSecret;

        public StripeWebhookController(ApiDbContext context, IConfiguration configuration)
        {
            _context = context;
            _endpointSecret = configuration["Stripe:Webhook"]!;
        }

        // POST api/StripeWebhook
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json,
                Request.Headers["Stripe-Signature"], _endpointSecret);

            // Handle the event
            switch (stripeEvent.Type)
            {
                case Events.CustomerSubscriptionCreated:
                    break;
                case Events.InvoicePaymentSucceeded:

                    //FileWriter.AppendToJsonLog(json: json);

                    // convert to custom StripeInvoice object
                    StripeInvoice stripeInvoice = JsonSerializer.Deserialize<StripeInvoice>(json)!;

                    // datum
                    List<Datum> lineDatas = stripeInvoice?.Data?.ObjectData?.Lines?.Data!;

                    StripeBgTaskQueue bgTask = new StripeBgTaskQueue()
                    {
                        Id = 0,
                        EmailAddress = stripeInvoice?.Data?.ObjectData?.CustomerEmail ?? null,
                        PhoneNumber = stripeInvoice?.Data?.ObjectData?.CustomerPhone ?? null,
                        Address1 = stripeInvoice?.Data?.ObjectData?.CustomerAddress?.Line1 ?? null,
                        Address2 = stripeInvoice?.Data?.ObjectData?.CustomerAddress?.Line2 ?? null,
                        City = stripeInvoice?.Data?.ObjectData?.CustomerAddress?.City ?? null,
                        State = stripeInvoice?.Data?.ObjectData?.CustomerAddress?.State ?? null,
                        PostalCode = stripeInvoice?.Data?.ObjectData?.CustomerAddress?.PostalCode ?? null,
                        Country = stripeInvoice?.Data?.ObjectData?.CustomerAddress?.Country ?? null,
                        Created = DateTime.UtcNow,
                        SubscriptionStartDate = DateTimeOffset.FromUnixTimeSeconds((long)stripeInvoice?.Data?.ObjectData?.PeriodStart!).DateTime,
                        SubscriptionExpireDate = DateTimeOffset.FromUnixTimeSeconds((long)stripeInvoice?.Data?.ObjectData?.PeriodEnd!).DateTime,
                        EventId = stripeInvoice?.Id ?? null,
                        ProductId = lineDatas[0].Plan?.Product ?? null,
                        CustomerId = stripeInvoice?.Data?.ObjectData?.Customer ?? null,
                        BillingReason = stripeInvoice?.Data?.ObjectData?.BillingReason ?? null,
                        Status = Shared.Models.User.Constants.StripeBgTaskStatus.QUEUED,
                    };
                    try
                    {
                        await _context.StripeBgTaskQueues!.AddAsync(bgTask);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        FileWriter.AppendToJsonLog(ex.Message);
                        if (ex.InnerException != null)
                        {
                            FileWriter.AppendToJsonLog($"Inner Exception: {ex.InnerException.Message}");
                        }
                    }
                    break;
                default:
                    break;
            }
            return Ok();
        }
    }

    public class FileWriter
    {
        public static void AppendToJsonLog(string json)
        {
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string logFilePath = Path.Combine(projectDirectory, "json.log");

            try
            {
                using (StreamWriter writer = System.IO.File.AppendText(logFilePath))
                {
                    writer.WriteLine(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

