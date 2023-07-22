namespace OptechX.Portal.Client.Services
{
	public interface IPureHttpService
	{
        Task<bool> TestConnection(string url);
	}
}

