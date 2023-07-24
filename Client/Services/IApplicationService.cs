using OptechX.Portal.Shared.Models.Engine.Applications;

namespace OptechX.Portal.Client.Services
{
	public interface IApplicationService
	{
		IList<Application> Applications { get; }
		Task LoadApplicationsAsync();

		IList<Application> EnabledApplications { get; }
		Task LoadEnabledApplicationsAsync();

        Task LoadInternetApplicationsAsync();
        Task LoadDeveloperToolsApplicationsAsync();
        Task LoadEducationApplicationsAsync();
        Task LoadEntertainmentApplicationsAsync();
        Task LoadGamesApplicationsAsync();
        Task LoadLifestyleApplicationsAsync();
        Task LoadMicrosoftApplicationsAsync();
        Task LoadPhotoDesignApplicationsAsync();
        Task LoadProductivityApplicationsAsync();
        Task LoadSecurityApplicationsAsync();
        Task LoadUtilityApplicationsAsync();

        Task SearchApplicationTagsAsync(string searchString);
    }
}

