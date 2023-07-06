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
    }
}

