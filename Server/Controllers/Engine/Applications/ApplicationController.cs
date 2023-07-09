using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptechX.Portal.Server.Data;
using OptechX.Portal.Shared.Models.Engine.Applications;

namespace OptechX.Portal.Server.Controllers.Engine.Applications
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ApplicationController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Application
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }

            return await _context.Applications.ToListAsync();
        }
    }
}
