using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptechX.Portal.Server.Data;
using OptechX.Portal.Shared.Models.Forms;

namespace OptechX.Portal.Server.Controllers.Forms
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsResponderController : ControllerBase
	{
        private readonly ApiDbContext _context;

		public FormsResponderController(ApiDbContext context)
		{
			_context = context;
		}

        [HttpGet("ReleaseResult/{release}")]
        public async Task<ActionResult<EditionResult>> GetEditionResult(string release)
        {
            var result = await _context.EditionResults.FirstOrDefaultAsync(r => r.ReleaseSelect == release);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

    }
}

