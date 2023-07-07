using OptechX.Portal.Shared.Models.Generic;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Client.Services
{
	public interface IAuthService
	{
        Task<ServiceResponse<int>> Register(UserRegister userRegister);
		Task<ServiceResponse<UserLoginResponse>> Login(UserLogin userLogin);
	}
}

