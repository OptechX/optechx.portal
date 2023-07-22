namespace OptechX.Portal.Client.Services
{
    public class PureHttpService : IPureHttpService
	{
        private readonly HttpClient _httpClient;

        public PureHttpService(HttpClient httpClient)
		{
            _httpClient = httpClient;
        }

        public async Task<bool> TestConnection(string url)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }
    }
}

