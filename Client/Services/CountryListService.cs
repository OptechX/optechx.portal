using System.Net.Http.Json;
using Blazored.Toast.Services;

namespace OptechX.Portal.Client.Services
{
    public class CountryListService : ICountryListService
    {
        private readonly IToastService _toastService;
        private readonly HttpClient _httpClient;

        public CountryListService(IToastService toastService, HttpClient httpClient)
        {
            _toastService = toastService;
            _httpClient = httpClient;
        }

        public IList<string> Countries { get; set; } = new List<string>();

        public async Task LoadCountryListAsync()
        {
            if (Countries.Count == 0)
            {
                var countryList = await _httpClient.GetFromJsonAsync<IList<string>>("api/CountryList");
                if (countryList != null)
                {
                    Countries = countryList;
                }
            }
        }
    }
}
