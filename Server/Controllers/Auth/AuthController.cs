using Microsoft.AspNetCore.Mvc;
using OptechX.Portal.Server.Services;
using OptechX.Portal.Shared.Models.User;

namespace OptechX.Portal.Server.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        /// <summary>
        /// Register for new account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister request)
        {
            var response = await _authRepo.Register(request);

            switch(response.ResponseCode)
            {
                case 201:
                    return Ok(response);
                default:
                    return BadRequest(response);
            }
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponse>> Login([FromBody] UserLogin request)
        {
            var response = await _authRepo.Login(request);

            switch (response.ResponseCode)
            {
                case 200:
                    return Ok(response.Data);
                default:
                    return BadRequest(response.Message);
            }
        }

        /// <summary>
        /// Verify account
        /// </summary>
        /// <param name="verificationToken"></param>
        /// <returns></returns>
        [HttpPost("verify-account/{verificationToken}")]
        public async Task<ActionResult<int>> VerifyAccount(string verificationToken)
        {
            var response = await _authRepo.VerifyAccount(verificationToken);

            switch (response.ResponseCode)
            {
                case 200:
                    return Ok(response);
                default:
                    return BadRequest(response.Message);
            }
        }

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        [HttpPost("reset-password/{emailAddress}")]
        public async Task<ActionResult<bool>> ResetPassword(string emailAddress)
        {
            var response = await _authRepo.ResetPassword(emailAddress);
            return Ok(response);  // this will never return anything other than Ok()
        }

        /// <summary>
        /// Request replacement verification token for account
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        [HttpPost("request-new-verification-token/{emailAddress}")]
        public async Task<ActionResult<bool>> RequestNewVerificationToken(string emailAddress)
        {
            var response = await _authRepo.GetNewVerificationToken(emailAddress);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }



        [HttpPost("set-new-password")]
        public async Task<ActionResult<bool>> SetNewPassword([FromBody] SetPasswordRequest request)
        {
            var response = await _authRepo.SetNewPassword(request);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
