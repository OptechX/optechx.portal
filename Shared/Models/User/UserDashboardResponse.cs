using OptechX.Portal.Shared.Models.Engine.Applications;
using OptechX.Portal.Shared.Models.Engine.ImageBuilds;
using OptechX.Portal.Shared.Models.Generic;
using OptechX.Portal.Shared.Models.User.Constants;

namespace OptechX.Portal.Shared.Models.User
{
	public class UserDashboardResponse
	{
		public string? UserIcon { get; set; }
		public string? MicrosoftEnterpriseAgreementNumber { get; set; }
		public BillingType BillingType { get; set; }
		public AccountTier? AccountTier { get; set; }
		public int ImagesRemaining { get; set; }
		public int AppLockerStorageAvailable { get; set; }
		public List<ImageBuildBasic>? ImageBuildBasics { get; set; }
		public List<ApplicationDashboardView>? ApplicationDashboardViews { get; set; }
		public List<NewsUpdate>? NewsUpdates { get; set; }
    }
}

