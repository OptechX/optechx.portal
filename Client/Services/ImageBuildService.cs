using System.Net.Http.Json;
using OptechX.Portal.Shared.Models.Engine.ImageBuilds;

namespace OptechX.Portal.Client.Services
{
    public class ImageBuildService : IImageBuildService
    {
        private readonly HttpClient _httpClient;

		public ImageBuildService(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public List<ImageBuildBasic> ImageBuildBasicsList { get; set; } = new();

        public async Task GetUserImageBuildHistory(string accountId)
        {
            List<ImageBuildBasic>? response = await _httpClient.GetFromJsonAsync<List<ImageBuildBasic>>($"api/Orders/orderslistbyaccountid/{accountId}");
            if (response!.Count > 0)
            {
                ImageBuildBasicsList = response;
            }
        }

        public async Task GetUserImageSubmittedOrders(string accountId)
        {
            List<ImageBuildBasic>? response = await _httpClient.GetFromJsonAsync<List<ImageBuildBasic>>($"api/Orders/orderslistbyaccountid/{accountId}/submitted");
            if (response!.Count > 0)
            {
                ImageBuildBasicsList = response;
            }
        }

        public async Task GetUserImageQueuedOrders(string accountId)
        {
            List<ImageBuildBasic>? response = await _httpClient.GetFromJsonAsync<List<ImageBuildBasic>>($"api/Orders/orderslistbyaccountid/{accountId}/queued");
            if (response!.Count > 0)
            {
                ImageBuildBasicsList = response;
            }
        }

        public async Task GetUserImagePreworkOrders(string accountId)
        {
            List<ImageBuildBasic>? response = await _httpClient.GetFromJsonAsync<List<ImageBuildBasic>>($"api/Orders/orderslistbyaccountid/{accountId}/prework");
            if (response!.Count > 0)
            {
                ImageBuildBasicsList = response;
            }
        }

        public async Task GetUserImageProcessingOrders(string accountId)
        {
            List<ImageBuildBasic>? response = await _httpClient.GetFromJsonAsync<List<ImageBuildBasic>>($"api/Orders/orderslistbyaccountid/{accountId}/processing");
            if (response!.Count > 0)
            {
                ImageBuildBasicsList = response;
            }
        }

        public async Task GetUserImageCompilingOrders(string accountId)
        {
            List<ImageBuildBasic>? response = await _httpClient.GetFromJsonAsync<List<ImageBuildBasic>>($"api/Orders/orderslistbyaccountid/{accountId}/compiling");
            if (response!.Count > 0)
            {
                ImageBuildBasicsList = response;
            }
        }

        public async Task GetUserImageCompleteOrders(string accountId)
        {
            List<ImageBuildBasic>? response = await _httpClient.GetFromJsonAsync<List<ImageBuildBasic>>($"api/Orders/orderslistbyaccountid/{accountId}/complete");
            if (response!.Count > 0)
            {
                ImageBuildBasicsList = response;
            }
        }

        public async Task GetUserImageDeletedOrders(string accountId)
        {
            List<ImageBuildBasic>? response = await _httpClient.GetFromJsonAsync<List<ImageBuildBasic>>($"api/Orders/orderslistbyaccountid/{accountId}/deleted");
            if (response!.Count > 0)
            {
                ImageBuildBasicsList = response;
            }
        }
    }
}

