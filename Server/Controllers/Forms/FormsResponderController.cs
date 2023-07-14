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

        [HttpGet("winreleaseresult/{selectString}")]
        public async Task<ActionResult<WinReleaseApiResult>> GetWinReleaseResult(string selectString)
        {
            var result = await _context.WinReleaseApiResults!.FirstOrDefaultAsync(r => r.ReleaseSelect == selectString);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("wineditionresult/{selectString}")]
        public async Task<ActionResult<WinEditionApiResult>> GetWinEditionResult(string selectString)
        {
            var result = await _context.WinEditionApiResults!.FirstOrDefaultAsync(r => r.EditionSelect == selectString);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("winversionresult/{selectString}")]
        public async Task<ActionResult<WinVersionApiResult>> GetWinVersionResult(string selectString)
        {
            var result = await _context.WinVersionApiResults!.FirstOrDefaultAsync(r => r.VersionSelect == selectString);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("winarchresult/{selectString}")]
        public async Task<ActionResult<WinArchApiResult>> GetWinArchResult(string selectString)
        {
            var result = await _context.WinArchApiResults!.FirstOrDefaultAsync(r => r.ArchSelect == selectString);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}

