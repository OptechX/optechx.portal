using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptechX.Portal.Server.Data;
using OptechX.Portal.Shared.Models.User;
using OptechX.Portal.Shared.Models.User.Constants;

namespace OptechX.Portal.Server.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;

        public UserController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private ReturnedJwtPayload? GetAccountIdFromToken()
        {
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                string token = authHeader["Bearer ".Length..].Trim().Replace("\"", "");
                var jwtSecurityToken = new JwtSecurityToken(token);
                ReturnedJwtPayload returnedJwtPayload = new()
                {
                    EmailAddress = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value,
                    AccountId = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "AccountId")?.Value,
                    Expiration = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "exp")?.Value,
                    Issuer = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "iss")?.Value
                };
                if (DateTime.UtcNow > DateTimeOffset.FromUnixTimeSeconds(long.Parse(returnedJwtPayload.Expiration!)))
                {
                    ReturnedJwtPayload expiredJwtPayload = new()
                    {
                        EmailAddress = "expired@token.com",
                        AccountId = Guid.Empty.ToString(),
                        Expiration = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "exp")?.Value,
                        Issuer = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "iss")?.Value
                    };
                    return expiredJwtPayload;
                }
                return returnedJwtPayload;
            }
            else
            {
                ReturnedJwtPayload invalidJwtPayload = new()
                {
                    EmailAddress = "invalid@token.com",
                    AccountId = Guid.Empty.ToString(),
                    Expiration = DateTime.UtcNow.ToFileTimeUtc().ToString(),
                    Issuer = "http://error.com/",
                };
                return invalidJwtPayload;
            }
        }

        // GET: /api/user
        [HttpGet]
        public async Task<IActionResult> GetUserBasics()
        {
            var authHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                string token = authHeader["Bearer ".Length..].Trim().Replace("\"", "");
                var jwtSecurityToken = new JwtSecurityToken(token);
                ReturnedJwtPayload returnedJwtPayload = new()
                {
                    EmailAddress = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value,
                    AccountId = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "AccountId")?.Value,
                    Expiration = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "exp")?.Value,
                    Issuer = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "iss")?.Value
                };
                if (DateTime.UtcNow > DateTimeOffset.FromUnixTimeSeconds(long.Parse(returnedJwtPayload.Expiration!)))
                {
                    ReturnedJwtPayload expiredJwtPayload = new()
                    {
                        EmailAddress = "expired@token.com",
                        AccountId = Guid.Empty.ToString(),
                        Expiration = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "exp")?.Value,
                        Issuer = jwtSecurityToken.Claims.FirstOrDefault(claim => claim.Type == "iss")?.Value
                    };
                    UserData response2 = new()
                    {
                        Id = expiredJwtPayload.AccountId,
                        EmailAddress = expiredJwtPayload.EmailAddress,
                        Company = "fail",
                        TaxId = "fail",
                        FirstName = "fail",
                        LastName = "fail",
                        PhoneNumber = "fail",
                        Address1 = "fail",
                        Address2 = "fail",
                        City = "fail",
                        State = "fail",
                        PostalCode = "fail",
                        Country = "fail",
                        UserIcon = "fail",
                    };
                    return Ok(response2);
                }

                var user = await _dbContext.UserAccounts!.FirstOrDefaultAsync(u => u.Id == Guid.Parse(returnedJwtPayload.AccountId!));
                UserData response = new()
                {
                    Id = user!.Id.ToString(),
                    EmailAddress = user.EmailAddress,
                    Company = user.Company,
                    TaxId = user.TaxId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Address1 = user.Address1,
                    Address2 = user.Address2,
                    City = user.City,
                    State = user.State,
                    PostalCode = user.PostalCode,
                    Country = user.Country,
                    UserIcon = user.UserIcon,
                };
                return Ok(response);
            }
            else
            {
                UserData response = new()
                {
                    Id = "fail",
                    EmailAddress = "fail@fail.com",
                    Company = "fail",
                    TaxId = "fail",
                    FirstName = "fail",
                    LastName = "fail",
                    PhoneNumber = "fail",
                    Address1 = "fail",
                    Address2 = "fail",
                    City = "fail",
                    State = "fail",
                    PostalCode = "fail",
                    Country = "fail",
                    UserIcon = "fail",
                };
                return Ok(response);
            }
        }

        // GET: /api/user/billingtype
        [HttpGet("billingtype")]
        public async Task<ActionResult<string>> GetBillingType()
        {
            var accountId = User.FindFirstValue("AccountId");
            var user = await _dbContext.UserAccounts!.FirstOrDefaultAsync(u => u.Id == Guid.Parse(accountId!));
            if (user != null)
            {
                return Ok(user.BillingType.ToString());
            }
            return NotFound();
        }
    }
}


// TODO: Add these values to the user controller as a get
//public EnterpriseAgreement? EnterpriseAgreement { get; set; }
//public string? MicrosoftEnterpriseAgreementNumber { get; set; }
//public AccountTier AccountTier { get; set; }
//public int ImagesRemaining { get; set; }
//public int AppLockerStorageAvailable { get; set; }
//public int AppLockerStorageUsed { get; set; }