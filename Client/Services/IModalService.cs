using Microsoft.AspNetCore.Components;

namespace OptechX.Portal.Client.Services
{
	public interface IModalService
	{
        void ShowModal(string appIconUri, string appPublisher, string appName,
            string appVersion, string appDescription, string appArch, string appLanguage,
            string appCopyright, string appHomepage, string appDocs, string appUid);

        void CloseModal();

        bool IsModalVisible();

        string AppIconURI { get; }
        string AppPublisher { get; }
        string AppName { get; }
        string AppVersion { get; }
        string AppDescription { get; }
        string AppArch { get; }
        string AppLanguage { get; }
        string AppCopyright { get; }
        string AppHomepage { get; }
        string AppDocs { get; }
        string AppUID { get; }

        EventCallback<bool> OnClose { get; }
    }
}

