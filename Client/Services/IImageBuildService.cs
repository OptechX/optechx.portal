using OptechX.Portal.Shared.Models.Engine.ImageBuilds;

namespace OptechX.Portal.Client.Services
{
	public interface IImageBuildService
	{
        List<ImageBuildBasic> ImageBuildBasicsList { get; }
        Task GetUserImageBuildHistory(string accountId);
        Task GetUserImageSubmittedOrders(string accountId);
        Task GetUserImageQueuedOrders(string accountId);
        Task GetUserImagePreworkOrders(string accountId);
        Task GetUserImageProcessingOrders(string accountId);
        Task GetUserImageCompilingOrders(string accountId);
        Task GetUserImageCompleteOrders(string accountId);
        Task GetUserImageDeletedOrders(string accountId);
    }
}

