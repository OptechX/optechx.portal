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
    }
}
