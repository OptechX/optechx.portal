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
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadDellDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Dell");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadLenovoDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Lenovo");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadHPDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/HP");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadAppleDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Apple");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadAcerDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Acer");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadAsusDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Asus");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadMSIDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/MSI");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadToshibaDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Toshiba");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadNECDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/NEC");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadIBMDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/IBM");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadCompaqDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Compaq");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadPackard_Bell_NECDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Packard_Bell_NEC");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadFujitsuDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Fujitsu");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadSharpDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Sharp");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadMSXDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/MSX");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadMicrosoftDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Microsoft");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadOtherDriversAsync()
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>("api/DriverCore/Other");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task LoadDriversByWindowsReleaseAsync(string windowsRelease)
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>($"api/DriverCore/by-release/{windowsRelease}");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }

        public async Task SearchDriversAsync(string searchString)
        {
            if (Drivers.Count == 0)
            {
                var response = await _httpClient.GetFromJsonAsync<List<DriverCore>>($"api/DriverCore/search/{searchString}");
                if (response != null)
                {
                    Drivers = response;
                }
            }
        }
    }
}

