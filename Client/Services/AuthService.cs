using System.Net.Http.Json;
using OptechX.Portal.Shared.Models.Generic;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Client.Services
{
    public class AuthService : IAuthService
	{
        private readonly HttpClient _httpClient;

		public AuthService(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        /// <summary>
        /// Request new verification code for account
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse<bool>> GetNewVerificationToken(string emailAddress)
        {
            var requestUri = $"api/auth/request-new-verification-token/{emailAddress}";
            var result = await _httpClient.PostAsync(requestUri, null);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            if (content != null)
            {
                return content;
            }
            else
            {
                return new ServiceResponse<bool> { Data = true, Message = "Request for new verification token received", ResponseCode = 204, Success = false };
            }
        }

        /// <summary>
        /// Login user account request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<UserLoginResponse>> Login(UserLogin request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", request);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<UserLoginResponse>>();
            if (content != null)
            {
                return content;
            }
            else
            {
                return new ServiceResponse<UserLoginResponse>() { Data = null, Message = "Not Found", ResponseCode = 404, Success = false };
            }
        }

        /// <summary>
        /// Register user account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<bool>> Register(UserRegister request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", request);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            if (content != null)
            {
                return content;
            }
            else
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Message = "User account not registered",
                    ResponseCode = 204,
                    Success = false,
                };
            }
        }

        /// <summary>
        /// Request password reset
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<bool>> ResetPassword(ResetPasswordRequest userEmail)
        {
            string requestUri = $"api/auth/reset-password/{userEmail.ResetEmailAddress}";
            HttpResponseMessage result = await _httpClient.PostAsync(requestUri, null);
            ServiceResponse<bool>? content = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            if (content != null)
            {
                return content;
            }
            else
            {
                return new ServiceResponse<bool> { Data = false, Message = "Request for password reset received", ResponseCode = 204, Success = false };
            }
        }

        /// <summary>
        /// Sets a new password for the user account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ServiceResponse<bool>> SetNewPassword(SetPasswordRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/set-new-password", request);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            if (content != null)
            {
                return content;
            }
            else
            {
                return new ServiceResponse<bool> { Data = false, Message = "Bad request", ResponseCode = 400, Success = false };
            }
        }

        /// <summary>
        /// Verify user account
        /// </summary>
        /// <param name="verificationToken"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<bool>> VerifyAccount(string verificationToken)
        {
            var requestUri = $"api/auth/verify-account/{verificationToken}";
            var result = await _httpClient.PostAsync(requestUri, null);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            if (content != null)
            {
                return content;
            }
            else
            {
                return new ServiceResponse<bool> { Data = false, Message = "Request for account verification failed", ResponseCode = 400, Success = false };
            }
        }

        /// <summary>
        /// Send the user's token to the API to validate if it has expired, 0=not expired, 1=anything else
        /// </summary>
        /// <returns>int</returns>
        public async Task<int> VerifyTokenValidity()
        {
            try
            {
                var result = await _httpClient.GetAsync("api/user/ValidateToken");
                var content = await result.Content.ReadFromJsonAsync<int>();
                return content;
            }
            catch
            {
                return 1;
            }
        }
    }
}

