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

        // GET: api/Application/Enabled
        [HttpGet("Enabled")]
        public async Task<ActionResult<IEnumerable<Application>>> GetEnabledApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }

            var enabledApplications = await _context.Applications
                .Where(app => app.Enabled)
                .ToListAsync();

            return enabledApplications;
        }

        // GET: api/Application/last5
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

        // GET: api/Application/category/Internet
        [HttpGet("category/Internet")]
        public async Task<ActionResult<IEnumerable<Application>>> GetInternetApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.INTERNET && app.Enabled)
                .ToListAsync();

            return apps;
        }

        // GET: api/Application/category/DeveloperTools
        [HttpGet("category/DeveloperTools")]
        public async Task<ActionResult<IEnumerable<Application>>> GetDeveloperToolsApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.DEVELOPERTOOLS && app.Enabled)
                .ToListAsync();

            return apps;
        }
        // GET: api/Application/category/Education
        [HttpGet("category/Education")]
        public async Task<ActionResult<IEnumerable<Application>>> GetEducationApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.EDUCATION && app.Enabled)
                .ToListAsync();

            return apps;
        }
        // GET: api/Application/category/Entertainment
        [HttpGet("category/Entertainment")]
        public async Task<ActionResult<IEnumerable<Application>>> GetEntertainmentApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.ENTERTAINMENT && app.Enabled)
                .ToListAsync();

            return apps;
        }
        // GET: api/Application/category/Games
        [HttpGet("category/Games")]
        public async Task<ActionResult<IEnumerable<Application>>> GetGamesApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.GAMES && app.Enabled)
                .ToListAsync();

            return apps;
        }
        // GET: api/Application/category/Lifestyle
        [HttpGet("category/Lifestyle")]
        public async Task<ActionResult<IEnumerable<Application>>> GetLifestyleApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.LIFESTYLE && app.Enabled)
                .ToListAsync();

            return apps;
        }
        // GET: api/Application/category/Microsoft
        [HttpGet("category/Microsoft")]
        public async Task<ActionResult<IEnumerable<Application>>> GetMicrosoftApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.MICROSOFT && app.Enabled)
                .ToListAsync();

            return apps;
        }
        // GET: api/Application/category/PhotoDesign
        [HttpGet("category/PhotoDesign")]
        public async Task<ActionResult<IEnumerable<Application>>> GetPhotoDesignApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.PHOTODESIGN && app.Enabled)
                .ToListAsync();

            return apps;
        }
        // GET: api/Application/category/Productivity
        [HttpGet("category/Productivity")]
        public async Task<ActionResult<IEnumerable<Application>>> GetProductivityApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.PRODUCTIVITY && app.Enabled)
                .ToListAsync();

            return apps;
        }
        // GET: api/Application/category/Security
        [HttpGet("category/Security")]
        public async Task<ActionResult<IEnumerable<Application>>> GetSecurityApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.SECURITY && app.Enabled)
                .ToListAsync();

            return apps;
        }
        // GET: api/Application/category/Utility
        [HttpGet("category/Utility")]
        public async Task<ActionResult<IEnumerable<Application>>> GetUtilityApplications()
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }
            var apps = await _context.Applications
                .Where(app => app.ApplicationCategory == Shared.Models.Engine.Constants.ApplicationCategory.UTILITY && app.Enabled)
                .ToListAsync();

            return apps;
        }

        // GET: api/Application/search-tags/{searchString}
        [HttpGet("search-tags/{searchString}")]
        public async Task<ActionResult<IEnumerable<Application>>> SearchApplicationTags(string searchString)
        {
            if (_context.Applications == null)
            {
                return NotFound();
            }

            var apps = await _context.Applications
                .Where(app => app.Enabled)
                .ToListAsync();

            var filteredApps = apps
                .Where(app => app.Tags != null && app.Tags.Contains(searchString.ToLower()))
                .ToList();

            if (filteredApps.Count > 0)
            {
                return filteredApps;
            }
            else
            {
                return new List<Application>();
            }
        }
    }
}


