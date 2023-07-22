using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Server.Services
{
	public interface IUserSvrSdService
	{
        //UserDashboardResponse UserDashboardResponseData { get; set; }
        Task<UserDashboardResponse>? GetUserDashboardResponse(Guid accountId);
	}
}

