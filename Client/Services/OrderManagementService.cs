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
        public ImageBuildBasic ImageBuildBasicResult { get; set; } = new();


        // GET
        public async Task GetImageBuildBasicResultsAsync(string select)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ImageBuildBasic>>($"api/FormsResponder/appresult/{select}");
            if (response != null)
            {
                ImageBuildBasicResults = response!;
            }
        }

        // DELETE
        public Task DeleteImageBuildBasicResultAsync(string select)
        {
            throw new NotImplementedException();
        }

        // POST
        public async Task<int> PostImageBuildBasicAsync(ImageBuildBasic imageBuildBasic)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/Orders", imageBuildBasic);
            if (response.IsSuccessStatusCode)
            {
                return 1;
                //var content = await response.Content.ReadFromJsonAsync<ImageBuildBasic>();
                //if (content != null)
                //{
                //    ImageBuildBasicResult = content;
                //    return 1;
                //}
                //else
                //{
                //    // deserialization fails
                //    return 2;
                //}
            }
            else
            {
                // http response is unsuccessful
                return 3;
            }
        }
    }
}

