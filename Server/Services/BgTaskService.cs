using Microsoft.EntityFrameworkCore;
using OptechX.Portal.Server.Data;
using OptechX.Portal.Server.Helpers;
using OptechX.Portal.Shared.Models.Generic;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Server.Services;

public class BgTaskService : IBGTaskService
{
    private readonly ApiDbContext _dbContext;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;
    private readonly SemaphoreSlim _semaphore;

    private bool _isRunning;

    public BgTaskService(ApiDbContext dbContext, IConfiguration configuration, IEmailService emailService)
    {
        _dbContext = dbContext;
        _configuration = configuration;
        _emailService = emailService;
        _semaphore = new SemaphoreSlim(1, 1); // Limit concurrency to one task at a time
    }

    public async Task<ServiceResponse<bool>> ExecuteBgTaskServiceAsync(string verificationToken)
    {
        var response = new ServiceResponse<bool> { Data = true, Message = "Request 201", ResponseCode = 201, Success = true, };

        if (!string.IsNullOrEmpty(verificationToken))
        {
            if (verificationToken != _configuration["CronJob:SecretKey"])
            {
                return response;
            }

            // main starts here
            await ExecuteTaskAsync();
            return response;
        }
        else
        {

            return response;
        }
    }

    private async Task ExecuteTaskAsync()
    {
        if (!_isRunning)
        {
            await _semaphore.WaitAsync();

            try
            {
                _isRunning = true;

                if (_dbContext.StripeBgTaskQueues != null)
                {
                    var queued = await _dbContext
                            .StripeBgTaskQueues!
                            .Where(s => s.Status == Shared.Models.User.Constants.StripeBgTaskStatus.QUEUED)
                            .ToListAsync();

                    foreach (var q in queued)
                    {
                        var email = q.EmailAddress!.ToLowerInvariant();

                        UserAccount? usr = await _dbContext.UserAccounts!
                            .FirstOrDefaultAsync(u => u.EmailAddress == email!);

                        if (usr != null)
                        {
                            usr.PhoneNumber = q.PhoneNumber;
                            usr.Address1 = q.Address1;
                            usr.Address2 = q.Address2;
                            usr.City = q.City;
                            usr.State = q.State;
                            usr.PostalCode = q.PostalCode;
                            usr.BillingType = Shared.Models.User.Constants.BillingType.STRIPE;
                            usr.Updated = DateTime.UtcNow;
                            usr.SubscriptionStartDate = q.SubscriptionStartDate;
                            usr.SubscriptionExpireDate = q.SubscriptionExpireDate;

                            switch (q.ProductId)
                            {
                                // OptechX Small (Test Mode)
                                case "prod_NfEauO0yAuZaqw":
                                    usr.AccountTier = Shared.Models.User.Constants.AccountTier.POWER_USER;
                                    usr.ImagesRemaining = 1;
                                    usr.AppLockerStorageAvailable = 1024 * 3;
                                    usr.AppLockerStorageUsed = 0;
                                    break;
                                // OptechX Medium (Test Mode)
                                case "prod_NfTYUKwzlFv0aW":
                                    usr.AccountTier = Shared.Models.User.Constants.AccountTier.PROFESSIONAL;
                                    usr.ImagesRemaining = 3;
                                    usr.AppLockerStorageAvailable = 1024 * 6;
                                    usr.AppLockerStorageUsed = 0;
                                    break;
                                default:
                                    break;
                            }

                            // store the q Id before saving changes
                            var qId = q.Id;

                            // save the usr changes
                            await _dbContext.SaveChangesAsync();

                            // Now, retrieve 'q' again based on the stored 'Id' value
                            StripeBgTaskQueue? updatedQ = await _dbContext.StripeBgTaskQueues!
                                .FirstOrDefaultAsync(q => q.Id == qId);

                            if (updatedQ != null)
                            {
                                // Make further changes to 'updatedQ'
                                updatedQ.Status = Shared.Models.User.Constants.StripeBgTaskStatus.PROCESSED;

                                // Save the changes to the 'StripeBgTaskQueue' table
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                        else
                        {
                            string verificationToken = OptechXValueGenerator.GenerateRandomString(8);
                            UserAccount user = new UserAccount()
                            {
                                EmailAddress = q.EmailAddress!.ToLowerInvariant(),
                                PhoneNumber = q.PhoneNumber!,
                                Address1 = q.Address1!,
                                Address2 = q.Address2!,
                                City = q.City!,
                                State = q.State!,
                                PostalCode = q.PostalCode!,
                                BillingType = Shared.Models.User.Constants.BillingType.STRIPE!,
                                Created = DateTime.UtcNow,
                                Updated = DateTime.UtcNow,
                                SubscriptionStartDate = q.SubscriptionStartDate!,
                                SubscriptionExpireDate = q.SubscriptionExpireDate!,
                                IsAcceptTerms = true,
                                Role = Shared.Models.User.Constants.Role.USER,
                                VerificationToken = verificationToken,
                            };

                            switch (q.ProductId)
                            {
                                // OptechX Small (Test Mode)
                                case "prod_NfEauO0yAuZaqw":
                                    user.AccountTier = Shared.Models.User.Constants.AccountTier.POWER_USER;
                                    user.ImagesRemaining = 1;
                                    user.AppLockerStorageAvailable = 1024 * 3;
                                    user.AppLockerStorageUsed = 0;
                                    break;
                                // OptechX Medium (Test Mode)
                                case "prod_NfTYUKwzlFv0aW":
                                    user.AccountTier = Shared.Models.User.Constants.AccountTier.PROFESSIONAL;
                                    user.ImagesRemaining = 3;
                                    user.AppLockerStorageAvailable = 1024 * 6;
                                    user.AppLockerStorageUsed = 0;
                                    break;
                                default:
                                    break;
                            }

                            // store the q Id before saving changes
                            var qId = q.Id;

                            await _dbContext.UserAccounts!.AddAsync(user);
                            await _dbContext.SaveChangesAsync();

                            // Now, retrieve 'q' again based on the stored 'Id' value
                            StripeBgTaskQueue? updatedQ = await _dbContext.StripeBgTaskQueues!
                                .FirstOrDefaultAsync(q => q.Id == qId);

                            if (updatedQ != null)
                            {
                                // Make further changes to 'updatedQ'
                                updatedQ.Status = Shared.Models.User.Constants.StripeBgTaskStatus.PROCESSED;

                                // Save the changes to the 'StripeBgTaskQueue' table
                                await _dbContext.SaveChangesAsync();
                            }

                            string emailTemplate = EmailTemplates.VerifyEmailAddress(
                                recipientSmtp: user.EmailAddress,
                                verifyUrl: $"https://portal.optechx.com/account/verify-account?token={user.VerificationToken}");
                            await _emailService.SendAsync(
                                to: user.EmailAddress,
                                subject: "Welcome to OptechX!",
                                html: emailTemplate);
                        }
                    }
                }
            }
            finally
            {
                _isRunning = false;
                _semaphore.Release(); // Release the semaphore to allow the next task to start
            }
        }
    }
}