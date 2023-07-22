using Microsoft.EntityFrameworkCore;
using OptechX.Portal.Server.Data;
using OptechX.Portal.Shared.Models.Engine.Applications;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Server.Services
{
    public class UserSvrSdService : IUserSvrSdService
	{
        private readonly ApiDbContext _context;

		public UserSvrSdService(ApiDbContext context)
		{
            _context = context;
		}

        public async Task<UserDashboardResponse>? GetUserDashboardResponse(Guid accountId)
        {
            // User account stuff
            var user = _context.UserAccounts!.FirstOrDefault(u => u.Id == accountId);
            if (user == null)
            {
                return await Task.FromResult(new UserDashboardResponse());
            }
            UserDashboardResponse data = new UserDashboardResponse()
            {
                UserIcon = user.UserIcon,
                MicrosoftEnterpriseAgreementNumber = user.MicrosoftEnterpriseAgreementNumber,
                BillingType = user.BillingType,
                AccountTier = user.AccountTier,
                ImagesRemaining = user.ImagesRemaining,
                AppLockerStorageAvailable = user.AppLockerStorageAvailable,
            };

            // ImageBuildBasic from the user
            var images = _context.ImageBuildBasics!
                .Where(b => b.AccountId == accountId.ToString())
                .ToList();
            if (images != null)
                data.ImageBuildBasics = images;

            // ApplicationDashboardView (generic response)
            var apps = await _context.Applications!
                .ToListAsync();
            var last5Apps = apps.Count >= 5 ? apps.Skip(apps.Count - 5) : apps;
            List<ApplicationDashboardView> returnedApps = new();
            foreach (var app in last5Apps)
            {
                ApplicationDashboardView addApp = new ApplicationDashboardView() { Icon = app.Icon, Name = app.Name, Publisher = app.Publisher, Version = app.Version };
                returnedApps.Add(addApp);
            }
            data.ApplicationDashboardViews = returnedApps;

            // NewsUpdate (generic response)
            var newsArticles = _context.NewsUpdates!
                .OrderByDescending(news => news.Id)
                .Take(5)
                .ToList();
            data.NewsUpdates = newsArticles;

            return await Task.FromResult(data);
        }
    }
}

