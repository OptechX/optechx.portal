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
        /// Login user account request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<UserLoginResponse>> Login(UserLogin request)
        {
            var response = new ServiceResponse<UserLoginResponse>();
            var result = await _httpClient.PostAsJsonAsync("api/auth/login", request);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<UserLoginResponse>>();
            if (content is not null)
            {
                response.Data = content.Data;
                response.Message = content.Message;
                response.ResponseCode = content.ResponseCode;
                response.Success = content.Success;
                return response;
            }
            else
            {
                response.Data = new UserLoginResponse();
                response.Message = "Not Found";
                response.ResponseCode = 404;
                response.Success = false;
                return response;
            }
        }

        /// <summary>
        /// Register user account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/auth/register", request);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
            if (content is not null)
            {
                return new ServiceResponse<int>
                {
                    Data = content.Data,
                    Message = content.Message,
                    ResponseCode = content.ResponseCode,
                    Success = content.Success,
                };
            }
            else
            {
                return new ServiceResponse<int>
                {
                    Data = 204,
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
            var requestUri = $"api/auth/reset-password/{userEmail}";
            var result = await _httpClient.PostAsync(requestUri, null);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            if (content is not null)
            {
                return new ServiceResponse<bool>
                {
                    Data = content.Data,
                    Message = content.Message,
                    ResponseCode = content.ResponseCode,
                    Success = content.Success,
                };
            }
            else
            {
                return new ServiceResponse<bool> { Data = false, Message = "Request for password reset received", ResponseCode = 204, Success = false };
            }
        }

        public async Task<ServiceResponse<bool>> VerifyAccount(string verificationToken)
        {
            var requestUri = $"api/auth/verify-account/{verificationToken}";
            var result = await _httpClient.PostAsync(requestUri, null);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            if (content is not null)
            {
                return new ServiceResponse<bool>
                {
                    Data = content.Data,
                    Message = content.Message,
                    ResponseCode = content.ResponseCode,
                    Success = content.Success,
                };
            }
            else
            {
                return new ServiceResponse<bool> { Data = false, Message = "Request for account verification failed", ResponseCode = 400, Success = false };
            }
        }
    }
}

