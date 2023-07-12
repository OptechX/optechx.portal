using System.Net.Http.Json;
using OptechX.Portal.Shared.Models.Forms;

namespace OptechX.Portal.Client.Services
{
    public class FormsService : IFormsService
	{
        private readonly HttpClient _httpClient;

        public FormsService(HttpClient httpClient)
		{
            _httpClient = httpClient;
        }

        public EditionResult editionResult { get; set; } = new();

        public async Task GetEditionResultsAsync(string releaseSelect)
        {
            var response = await _httpClient.GetFromJsonAsync<EditionResult>("api/FormsResponder/ReleaseResult/{releaseSelect}");
            if (response != null)
            {
                editionResult = response!;
            }
        }
    }
}

