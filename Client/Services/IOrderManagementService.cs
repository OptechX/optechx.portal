using OptechX.Portal.Shared.Models.Engine.ImageBuilds;

namespace OptechX.Portal.Client.Services
{
	public interface IOrderManagementService
	{
		ImageBuildBasic ImageBuildBasicResults { get; }
        Task GetImageBuildBasicResultsAsync(string select);
		Task DeleteImageBuildBasicResultAsync(string select);
    }
}

