using System.Net.Http.Json;
using OptechX.Portal.Shared.Models.Engine.Applications;
using OptechX.Portal.Shared.Models.Engine.Constants;

namespace OptechX.Portal.Client.Services
{
	public class ApplicationService : IApplicationService
	{
        private readonly HttpClient _httpClient;

        public ApplicationService(HttpClient httpClient)
		{
            _httpClient = httpClient;
        }

        public IList<Application> Applications { get; set; } = new List<Application>();

        public async Task LoadApplicationsAsync()
        {
            if (Applications.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application");
                if (response != null)
                {
                    Applications = response;
                }
                //Applications = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application") ?? new List<Application>
                //{
                //    new Application
                //    {
                //        Id = 0,
                //        UID = "Google::Chrome",
                //        LastUpdate = DateTime.UtcNow,
                //        ApplicationCategory = ApplicationCategory.INTERNET,
                //        Publisher = "Fish",
                //        Name = "Fingers",
                //        Version = "114.0.5735.199",
                //        Copyright = "Copyright 2023 Google LLC. All rights reserved.",
                //        LicenseAcceptRequired = false,
                //        Lcid = new string[] { "x64","x86" },
                //        CpuArch = new string[] { "EN_US" },
                //        Homepage = "https://www.google.com/chrome/browser/",
                //        Icon = "https://raw.githubusercontent.com/OptechX/library.apps.images/main/Internet/Google/Chrome/icon.svg",
                //        Docs = "https://support.google.com/chrome/?hl=en&rd=3#topic=7439538",
                //        License = "https://www.google.it/intl/en/chrome/browser/privacy/eula_text.html",
                //        Tags = new string[] { "google","chrome","internet","browser" },
                //        Summary = "Chrome is a fast, simple, and secure web browser, built for the modern web.",
                //        Enabled = true,
                //        BannerIcon = null,
                //    }
                //};
            }
        }
    }
}

