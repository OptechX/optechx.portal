using Microsoft.AspNetCore.Components;

namespace OptechX.Portal.Client.Services
{
    public class BuildModalService : IBuildModalService
	{
        private bool showModal = false;

        public void ShowModal(DateTime OrderDate, string? ImageFormat,
            bool CIApps, bool CIDrivers, bool CICD,
            string? Release, string? Edition, string? Version,
            string? Arch, string? Language,
            string? Apps, string? AppxPackages,
            string? OptionalFeatures, string? Regedits,
            bool NotifyComplete, bool NotifyCICD,
            string UserAccount, string UserPassword)
        {
            ImgOrderDate = OrderDate;
            ImgImageFormat = ImageFormat!;
            ImgCIApps = CIApps;
            ImgCIDrivers = CIDrivers;
            ImgCICD = CICD;
            ImgRelease = Release!;
            ImgEdition = Edition!;
            ImgVersion = Version!;
            ImgArch = Arch!;
            ImgLanguage = Language!;
            ImgApps = new List<string>(Apps!.Split(','));
            ImgAppxPackages = new List<string>(AppxPackages!.Split(','));
            ImgOptionalFeatures = new List<string>(OptionalFeatures!.Split(','));
            ImgRegedits = new List<string>(Regedits!.Split(','));
            ImgNotifyComplete = NotifyComplete;
            ImgNotifyCICD = NotifyCICD;
            ImgUserAccount = UserAccount;
            ImgUserPassword = UserPassword;
        }

        public DateTime ImgOrderDate { get; private set; }
        public string ImgImageFormat { get; private set; } = null!;
        public bool ImgCIApps { get; private set; }
        public bool ImgCIDrivers { get; private set; }
        public bool ImgCICD { get; private set; }
        public string ImgRelease { get; private set; } = null!;
        public string ImgEdition { get; private set; } = null!;
        public string ImgVersion { get; private set; } = null!;
        public string ImgArch { get; private set; } = null!;
        public string ImgLanguage { get; private set; } = null!;
        public List<string> ImgApps { get; private set; } = null!;
        public List<string> ImgAppxPackages { get; private set; } = null!;
        public List<string> ImgOptionalFeatures { get; private set; } = null!;
        public List<string> ImgRegedits { get; private set; } = null!;
        public bool ImgNotifyComplete { get; private set; }
        public bool ImgNotifyCICD { get; private set; }
        public string ImgUserAccount { get; private set; } = null!;
        public string ImgUserPassword { get; private set; } = null!;

        public void CloseModal()
        {
            showModal = false;
        }

        public bool IsModalVisible()
        {
            return showModal;
        }

        EventCallback<bool> IBuildModalService.OnClose => throw new NotImplementedException();
    }
}

