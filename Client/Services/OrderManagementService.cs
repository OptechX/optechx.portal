using System;
using OptechX.Portal.Shared.Models.Engine.ImageBuilds;

namespace OptechX.Portal.Client.Services
{
    public class OrderManagementService : IOrderManagementService
	{
		public OrderManagementService()
		{
		}

        public ImageBuildBasic ImageBuildBasicResults => throw new NotImplementedException();

        public Task DeleteImageBuildBasicResultAsync(string select)
        {
            throw new NotImplementedException();
        }

        public Task GetImageBuildBasicResultsAsync(string select)
        {
            throw new NotImplementedException();
        }
    }
}

