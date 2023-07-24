using System.Net.Http.Json;
using OptechX.Portal.Shared.Models.Engine.Applications;

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

        public IList<Application> EnabledApplications { get; set; } = new List<Application>();

        public async Task LoadApplicationsAsync()
        {
            if (Applications.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application");
                if (response != null)
                {
                    Applications = response;
                }
            }
        }

        public async Task LoadEnabledApplicationsAsync()
        {
            if (EnabledApplications.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/Enabled");
                if (response != null)
                {
                    EnabledApplications = response;
                }
            }
        }

        // only return to EnabledApplications as these filters are specific to the Enabled feature used in drop down results
        public async Task LoadInternetApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/Internet");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task LoadDeveloperToolsApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/DeveloperTools");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task LoadEducationApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/Education");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task LoadEntertainmentApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/Entertainment");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task LoadGamesApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/Games");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task LoadLifestyleApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/Lifestyle");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task LoadMicrosoftApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/Microsoft");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task LoadPhotoDesignApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/PhotoDesign");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task LoadProductivityApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/Productivity");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task LoadSecurityApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/Security");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task LoadUtilityApplicationsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>("api/Application/category/Utility");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }

        public async Task SearchApplicationTagsAsync(string searchString)
        {
            var response = await _httpClient.GetFromJsonAsync<IList<Application>>($"api/Application/search-tags/{searchString}");
            if (response != null)
            {
                EnabledApplications = response;
            }
        }
    }
}

