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

        [HttpGet("appresult/{selectString}")]
        public async Task<ActionResult<List<ApplicationTableApiResult>>> GetApplicationByArch(string selectString)
        {
            var applications = await _context.Applications!
                .ToListAsync();

            var filteredApplications = applications
                .Where(app => app.CpuArchString != null && app.CpuArchString.Split(',', StringSplitOptions.RemoveEmptyEntries).Any(c => c.Contains(selectString)))
                .ToList();

            if (filteredApplications.Count == 0)
            {
                return NotFound();
            }

            var mappedApplicationTableApiResult = filteredApplications
                .Select(appResult => new ApplicationTableApiResult
                {
                    Id = appResult.Id,
                    Uid = appResult.UID,
                    Name = appResult.Name,
                    Publisher = appResult.Publisher,
                    Version = appResult.Version,
                    Icon = appResult.Icon,
                    Docs = appResult.Docs,
                    LastUpdated = appResult.LastUpdate.ToString("yyyy-MM-dd"),
                    Category = appResult.ApplicationCategory.ToString(),
                })
                .ToList();

            return Ok(mappedApplicationTableApiResult);
        }

        [HttpGet("driverresult/{selectString}")]
        public async Task<ActionResult<List<DriverTableApiResult>>> GetDrivedrByArch(string selectString)
        {
            var driverCores = await _context.DriverCores!
                .ToListAsync();

            var filteredDriversCores = driverCores
                .Where(x => x.SupportedWinReleaseString != null && x.SupportedWinReleaseString.Split(',', StringSplitOptions.RemoveEmptyEntries).Any(c => c.Contains(selectString)))
                .ToList();

            if (filteredDriversCores.Count == 0)
                return NotFound();

            var mappedDriverTableApiResult = filteredDriversCores
                .Select(m => new DriverTableApiResult
                {
                    Id = m.Id,
                    Uid = m.UID,
                    Oem = m.Oem.ToString(),
                    Make = m.Make,
                    Model = m.Model,
                    LastUpdated = m.LastUpdated,
                })
                .ToList();

            return Ok(mappedDriverTableApiResult);
        }
    }
}

