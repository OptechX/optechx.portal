using System;
using System.Collections.Generic;
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
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;

        public UserController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
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