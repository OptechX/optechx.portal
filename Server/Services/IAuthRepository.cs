using OptechX.Portal.Shared.Models.Generic;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Server.Services
{
	public interface IAuthRepository
	{
        Task<ServiceResponse<bool>> Register(UserRegister userRegister);
		Task<ServiceResponse<UserLoginResponse>> Login(UserLogin userLogin);
        Task<ServiceResponse<bool>> VerifyAccount(string verificationToken);
		Task<ServiceResponse<bool>> ResetPassword(string emailAddress);
		Task<ServiceResponse<bool>> GetNewVerificationToken(string emailAddress);
		Task<ServiceResponse<bool>> SetNewPassword(SetPasswordRequest request);
    }
}

