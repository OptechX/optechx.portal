using OptechX.Portal.Shared.Models.Generic;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Server.Services
{
	public interface IAuthRepository
	{
        Task<ServiceResponse<string>> Register(UserRegister userRegister);
		Task<ServiceResponse<UserLoginResponse>> Login(UserLogin userLogin);
        Task<ServiceResponse<int>> VerifyAccount(string verificationToken);
	}
}

