using System.Net.Http.Json;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Client.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly HttpClient _httpClient;
        public event Action? OnChange;
        public UserData UserDatas { get; set; } = new();

        public UserAccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        void UserDatasChanged() => OnChange?.Invoke();

        public async Task LoadUserDatasAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<UserData>("api/user");
            if (response != null)
            {
                UserDatas = response;
                UserDatasChanged();
            }
        }
    }
}
