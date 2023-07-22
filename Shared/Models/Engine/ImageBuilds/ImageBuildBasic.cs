using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? Drivers { get; set; }
        public string? Applications { get; set; }
        public string? AppxProvisionedPackages { get; set; }
        public string? WindowsCapabilities { get; set; }
        public string? WindowsOptionalFeatures { get; set; }
        public string? CustomRegistryStrings { get; set; }
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

        // custom mapping
        //[NotMapped]
        //public List<string>? DriversList
        //{
        //    get => Drivers?.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
        //    set => Drivers = value != null ? string.Join(',', value) : Drivers;
        //}
        //[NotMapped]
        //public List<string>? ApplicationsList
        //{
        //    get => Applications?.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
        //    set => Applications = value != null ? string.Join(',', value) : Applications;
        //}
        //[NotMapped]
        //public List<string>? AppxProvisionedPackagesList
        //{
        //    get => AppxProvisionedPackages?.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
        //    set => AppxProvisionedPackages = value != null ? string.Join(',', value) : AppxProvisionedPackages;
        //}
        //[NotMapped]
        //public List<string>? WindowsCapabilitiesList
        //{
        //    get => WindowsCapabilities?.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
        //    set => WindowsCapabilities = value != null ? string.Join(',', value) : WindowsCapabilities;
        //}
        //[NotMapped]
        //public List<string>? WindowsOptionalFeaturesList
        //{
        //    get => WindowsOptionalFeatures?.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
        //    set => WindowsOptionalFeatures = value != null ? string.Join(',', value) : WindowsOptionalFeatures;
        //}
        //[NotMapped]
        //public List<string>? CustomRegistryStringsList
        //{
        //    get => CustomRegistryStrings?.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
        //    set => CustomRegistryStrings = value != null ? string.Join(',', value) : CustomRegistryStrings;
        //}
    }
}


/*
         * OLD MAPPINGS
         */
//[NotMapped]
//public List<string>? DriversList
//{
//    get => Drivers?.Split(',').ToList();
//    set => Drivers = value != null ? string.Join(',', value) : Drivers;
//}

//[NotMapped]
//public List<string>? ApplicationsList
//{
//    get => Applications?.Split(',').ToList();
//    set => Applications = value != null ? string.Join(',', value) : Applications;
//}

//[NotMapped]
//public List<string>? AppxProvisionedPackagesList
//{
//    get => AppxProvisionedPackages?.Split(',').ToList();
//    set => AppxProvisionedPackages = value != null ? string.Join(',', value) : AppxProvisionedPackages;
//}

//[NotMapped]
//public List<string>? WindowsCapabilitiesList
//{
//    get => WindowsCapabilities?.Split(',').ToList();
//    set => WindowsCapabilities = value != null ? string.Join(',', value) : WindowsCapabilities;
//}

//[NotMapped]
//public List<string>? WindowsOptionalFeaturesList
//{
//    get => WindowsOptionalFeatures?.Split(',').ToList();
//    set => WindowsOptionalFeatures = value != null ? string.Join(',', value) : WindowsOptionalFeatures;
//}

//[NotMapped]
//public List<string>? CustomRegistryStringsList
//{
//    get => CustomRegistryStrings?.Split(',').ToList();
//    set => CustomRegistryStrings = value != null ? string.Join(',', value) : CustomRegistryStrings;
//}