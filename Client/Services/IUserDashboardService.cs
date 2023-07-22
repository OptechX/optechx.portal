using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Client.Services
{
	public interface IUserDashboardService
	{
		UserDashboardResponse UserDashboard { get; }
		Task GetUserDashboard(string accountId);
	}
}

