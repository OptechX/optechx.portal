namespace OptechX.Portal.Client.Services
{
	public interface ICountryListService
	{
        IList<string> Countries { get; }
        Task LoadCountryListAsync();
	}
}

