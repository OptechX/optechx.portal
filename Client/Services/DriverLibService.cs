using System.Net.Http.Json;
using OptechX.Portal.Shared.Models.Engine.Drivers;

namespace OptechX.Portal.Client.Services
{
    public class DriverLibService : IDriverLibService
	{
        private readonly HttpClient _httpClient;
		public DriverLibService(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public List<DriverCore> Drivers { get; set; } = new List<DriverCore>();

        public async Task LoadDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadDellDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Dell");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadLenovoDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Lenovo");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadHPDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/HP");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadAppleDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Apple");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadAcerDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Acer");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadAsusDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Asus");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadMSIDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/MSI");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadToshibaDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Toshiba");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadNECDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/NEC");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadIBMDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/IBM");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadCompaqDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Compaq");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadPackard_Bell_NECDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Packard_Bell_NEC");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadFujitsuDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Fujitsu");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadSharpDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Sharp");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadMSXDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/MSX");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadMicrosoftDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Microsoft");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadOtherDriversAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Other");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task LoadDriversByWindowsReleaseAsync(string windowsRelease)
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>($"api/DriverCore/by-release/{windowsRelease}");
            if (response != null)
            {
                Drivers = response;
            }
        }

        public async Task SearchDriversAsync(string searchString)
        {
            var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>($"api/DriverCore/search/{searchString}");
            if (response != null)
            {
                Drivers = response;
            }
        }
    }
}

