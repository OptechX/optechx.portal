using System.Net.Http.Json;
using OptechX.Portal.Shared.Models.Engine.ImageBuilds;

namespace OptechX.Portal.Client.Services
{
    public class OrderManagementService : IOrderManagementService
	{
        private readonly HttpClient _httpClient;

        public OrderManagementService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<ImageBuildBasic> ImageBuildBasicResults { get; set; } = new();

        public async Task GetImageBuildBasicResultsAsync(string select)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ImageBuildBasic>>($"api/FormsResponder/appresult/{select}");
            if (response != null)
            {
                ImageBuildBasicResults = response!;
            }
        }

        public Task DeleteImageBuildBasicResultAsync(string select)
        {
            throw new NotImplementedException();
        }
    }
}

