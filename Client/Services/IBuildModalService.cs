using Microsoft.AspNetCore.Components;

namespace OptechX.Portal.Client.Services
{
	public interface IBuildModalService
	{
        void ShowModal(DateTime OrderDate, string? ImageFormat,
            bool CIApps, bool CIDrivers, bool CICD,
            string? Release, string? Edition, string? Version,
            string? Arch, string? Language,
            string? Apps, string? Drivers, string? Regedits,
            string? AppxPackages, string? OptionalFeatures,
            bool NotifyComplete, bool NotifyCICD,
            string UserAccount, string UserPassword);

        void CloseModal();

        bool IsModalVisible();

        DateTime ImgOrderDate { get; }
        string ImgImageFormat { get; }
        bool ImgCIApps { get; }
        bool ImgCIDrivers { get; }
        bool ImgCICD { get; }
        string ImgRelease { get; }
        string ImgEdition { get; }
        string ImgVersion { get; }
        string ImgArch { get; }
        string ImgLanguage { get; }
        List<string> ImgApps { get; }
        List<string> ImgDrivers { get; }
        List<string> ImgAppxPackages { get; }
        List<string> ImgOptionalFeatures { get; }
        List<string> ImgRegedits { get; }
        bool ImgNotifyComplete { get; }
        bool ImgNotifyCICD { get; }
        string ImgUserAccount { get; }
        string ImgUserPassword { get; }

        EventCallback<bool> OnClose { get; }
    }
}

