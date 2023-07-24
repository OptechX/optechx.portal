using OptechX.Portal.Shared.Models.Engine.Applications;

namespace OptechX.Portal.Client.Services
{
	public interface IApplicationService
	{
		IList<Application> Applications { get; }
		Task LoadApplicationsAsync();

		IList<Application> EnabledApplications { get; }
		Task LoadEnabledApplicationsAsync();
	}
}

