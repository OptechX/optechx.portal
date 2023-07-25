using OptechX.Portal.Shared.Models.Engine.Drivers;

namespace OptechX.Portal.Client.Services
{
	public interface IDriverLibService
	{
		IList<Driver> Drivers { get; }

		Task LoadDriversAsync();
        Task LoadDellDriversAsync();
        Task LoadLenovoDriversAsync();
        Task LoadHPDriversAsync();
        Task LoadAppleDriversAsync();
        Task LoadAcerDriversAsync();
        Task LoadAsusDriversAsync();
        Task LoadMSIDriversAsync();
        Task LoadToshibaDriversAsync();
        Task LoadNECDriversAsync();
        Task LoadIBMDriversAsync();
        Task LoadCompaqDriversAsync();
        Task LoadPackard_Bell_NECDriversAsync();
        Task LoadFujitsuDriversAsync();
        Task LoadSharpDriversAsync();
        Task LoadMSXDriversAsync();
        Task LoadMicrosoftDriversAsync();
        Task LoadOtherDriversAsync();

        Task LoadDriversByWindowsReleaseAsync(string windowsRelease);
        Task SearchDriversAsync(string searchString);
    }
}

