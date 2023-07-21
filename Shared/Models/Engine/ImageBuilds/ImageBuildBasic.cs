using System.ComponentModel.DataAnnotations;

namespace OptechX.Portal.Shared.Models.Engine.ImageBuilds
{
    public class ImageBuildBasic
    {
        public int Id { get; set; }
        public string? AccountId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? OrderLifecycle { get; set; }

        [Url]
        public string? DownloadLink { get; set; }
        public string? ImageFormat { get; set; }
        public bool ContinuousIntegrationApplications { get; set; }
        public bool ContinuousIntegrationDrivers { get; set; }
        public bool ContinuousDeployment { get; set; }
        public bool IntegrateSecurityPatches { get; set; }
        public string? WindowsRelease { get; set; }
        public string? WindowsEdition { get; set; }
        public string? WindowsVersion { get; set; }
        public string? Arch { get; set; }
        public string? Language { get; set; }
        public string[]? Drivers { get; set; }
        public string[]? Applications { get; set; }
        public string[]? AppxProvisionedPackages { get; set; }
        public string[]? WindowsCapabilities { get; set; }
        public string[]? WindowsOptionalFeatures { get; set; }
        public string[]? CustomRegistryStrings { get; set; }
        public bool NotifyBuildComplete { get; set; }
        public bool NotifyCICDComplete { get; set; }

        [EmailAddress(ErrorMessage = "Valid email address required")]
        public string? NotifyEmailAddress { get; set; }

        [Required, RegularExpression(@"^.{1,20}$",
            ErrorMessage = "Admin username length must be between 1 and 20 characters")]
        public string DefaultAccount { get; set; } = null!;

        [Required, RegularExpression(@"^.{8,32}$",
            ErrorMessage = "Password length must be between 6 and 32 characters")]
        public string DefaultPassword { get; set; } = null!;
    }
}

