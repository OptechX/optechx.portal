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

        public WinVersionApiResult WinVersionApiResults { get; set; } = new();
        public WinEditionApiResult WinEditionApiResults { get; set; } = new();
        public WinReleaseApiResult WinReleaseApiResults { get; set; } = new();
        public WinArchApiResult WinArchApiResults { get; set; } = new();
        public List<ApplicationTableApiResult> ApplicationTableApiResults { get; set; } = new();

        public async Task ApplicationTableApiResultsAsync(string select)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ApplicationTableApiResult>> ($"api/FormsResponder/appresult/{select}");
            if (response != null)
            {
                ApplicationTableApiResults = response!;
            }
        }

        public async Task GetWinArchApiResultsAsync(string select)
        {
            var response = await _httpClient.GetFromJsonAsync<WinArchApiResult>($"api/FormsResponder/winarchresult/{select}");
            if (response != null)
            {
                WinArchApiResults = response!;
            }
        }

        public async Task GetWinEditionApiResultsAsync(string select)
        {
            var response = await _httpClient.GetFromJsonAsync<WinEditionApiResult>($"api/FormsResponder/wineditionresult/{select}");
            if (response != null)
            {
                WinEditionApiResults = response!;
            }
        }

        public async Task GetWinReleaseApiResultsAsync(string select)
        {
            var response = await _httpClient.GetFromJsonAsync<WinReleaseApiResult>($"api/FormsResponder/winreleaseresult/{select}");
            if (response != null)
            {
                WinReleaseApiResults = response!;
            }
        }

        public async Task GetWinVersionApiResultsAsync(string select)
        {
            var response = await _httpClient.GetFromJsonAsync<WinVersionApiResult>($"api/FormsResponder/winversionresult/{select}");
            if (response != null)
            {
                WinVersionApiResults = response!;
            }
        }
    }
}

