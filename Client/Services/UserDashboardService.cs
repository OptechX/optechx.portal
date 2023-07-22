using System.Net.Http.Json;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Client.Services
{
    public class UserDashboardService : IUserDashboardService
    {
        private readonly HttpClient _httpClient;

        public UserDashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public UserDashboardResponse UserDashboard { get; set; } = new();

        public async Task GetUserDashboard(string accountId)
        {
            UserDashboardResponse? response = await _httpClient.GetFromJsonAsync<UserDashboardResponse>($"api/user/dashboard/{accountId}");
            if (response != null)
            {
                UserDashboard = response!;
            }
        }
    }
}

