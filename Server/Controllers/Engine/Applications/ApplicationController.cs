using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptechX.Portal.Server.Data;
using OptechX.Portal.Shared.Models.Engine.Applications;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpGet("last5")]
        public async Task<ActionResult<IEnumerable<ApplicationDashboardView>>> GetLast5Updates()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }

            var apps = await _context.Applications
                .ToListAsync();

            var last5Apps = apps.Count >= 5 ? apps.Skip(apps.Count - 5) : apps;

            List<ApplicationDashboardView> returnedApps = new();
            foreach (var app in last5Apps)
            {
                ApplicationDashboardView addApp = new ApplicationDashboardView() { Icon = app.Icon, Name = app.Name, Publisher = app.Publisher, Version = app.Version };
                returnedApps.Add(addApp);
            }

            return returnedApps;
        }
    }
}
