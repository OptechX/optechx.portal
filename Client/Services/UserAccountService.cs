using OptechX.Portal.Shared.Models.User;
using System.Net.Http.Json;

namespace OptechX.Portal.Client.Services
{
    public class UserAccountService : IUserAccountService
	{
        private readonly HttpClient _httpClient;

        public UserAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public UserAccountRequiredFields UserAccountRequiredFields { get; set; } = new();

        /// <summary>
        /// Get the user account data from the API directly
        /// </summary>
        /// <returns></returns>
        public async Task LoadUserAccountRequiredFieldsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<UserAccountRequiredFields>("api/user");
            if (response != null)
            {
                UserAccountRequiredFields = response;
            }
        }
    }
}

