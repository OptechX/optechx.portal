using OptechX.Portal.Shared.Models.Forms;

namespace OptechX.Portal.Client.Services
{
	public interface IFormsService
	{
		EditionResult editionResult { get; }

		Task GetEditionResultsAsync(string releaseSelect);
	}
}

