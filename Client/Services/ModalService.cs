using Microsoft.AspNetCore.Components;

namespace OptechX.Portal.Client.Services
{
    public class ModalService : IModalService
    {
        private bool showModal = false;

        public void ShowModal(string appIconUri, string appPublisher, string appName,
            string appVersion, string appDescription, string appArch, string appLanguage,
            string appCopyright, string appHomepage,string appDocs, string appUid)
        {
            AppIconURI = appIconUri;
            AppPublisher = appPublisher;
            AppName = appName;
            AppVersion = appVersion;
            AppDescription = appDescription;
            AppArch = appArch;
            AppLanguage = appLanguage;
            AppCopyright = appCopyright;
            AppHomepage = appHomepage;
            AppDocs = appDocs;
            AppUID = appUid;

            showModal = true;
        }

        public void CloseModal()
        {
            showModal = false;
        }

        public bool IsModalVisible()
        {
            return showModal;
        }

        public string AppIconURI { get; private set; } = null!;
        public string AppPublisher { get; private set; } = null!;
        public string AppName { get; private set; } = null!;
        public string AppVersion { get; private set; } = null!;
        public string AppDescription { get; private set; } = null!;
        public string AppArch { get; private set; } = null!;
        public string AppLanguage { get; private set; } = null!;
        public string AppCopyright { get; private set; } = null!;
        public string AppHomepage { get; private set; } = null!;
        public string AppDocs { get; private set; } = null!;
        public string AppUID { get; private set; } = null!;

        public EventCallback<bool> OnClose => EventCallback.Factory.Create<bool>(this, CloseModal);
    }
}

