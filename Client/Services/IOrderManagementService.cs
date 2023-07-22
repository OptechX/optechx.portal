using OptechX.Portal.Shared.Models.Engine.ImageBuilds;

namespace OptechX.Portal.Client.Services
{
	public interface IOrderManagementService
	{
        ImageBuildBasic ImageBuildBasicResult { get; }
		List<ImageBuildBasic> ImageBuildBasicResults { get; }
        Task<int> PostImageBuildBasicAsync(ImageBuildBasic imageBuildBasic);
        Task GetImageBuildBasicResultsAsync(string select);
		Task DeleteImageBuildBasicResultAsync(string select);
    }
}

