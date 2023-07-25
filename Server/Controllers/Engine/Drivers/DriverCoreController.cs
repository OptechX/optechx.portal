using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptechX.Portal.Server.Data;
using OptechX.Portal.Shared.Models.Constants;
using OptechX.Portal.Shared.Models.Engine.Drivers;

namespace OptechX.Portal.Server.Controllers.Engine.Drivers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverCoreController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public DriverCoreController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/DriverCore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            return await _context.DriverCores.ToListAsync();
        }

        // GET: api/DriverCore/Dell
        [HttpGet("Dell")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetDellDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Dell)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Lenovo
        [HttpGet("Lenovo")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetLenovoDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Lenovo)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/HP
        [HttpGet("HP")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetHPDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.HP)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Apple
        [HttpGet("Apple")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetAppleDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Apple)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Acer
        [HttpGet("Acer")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetAcerDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Acer)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Asus
        [HttpGet("Asus")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetAsusDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Asus)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/MSI
        [HttpGet("MSI")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetMSIDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.MSI)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Toshiba
        [HttpGet("Toshiba")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetToshibaDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Toshiba)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/NEC
        [HttpGet("NEC")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetNECDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.NEC)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/IBM
        [HttpGet("IBM")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetIBMDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.IBM)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Compaq
        [HttpGet("Compaq")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetCompaqDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Compaq)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Packard_Bell_NEC
        [HttpGet("Packard_Bell_NEC")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetPackard_Bell_NECDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Packard_Bell_NEC)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Fujitsu
        [HttpGet("Fujitsu")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetFujitsuDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Fujitsu)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Sharp
        [HttpGet("Sharp")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetSharpDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Sharp)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/MSX
        [HttpGet("MSX")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetMSXDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.MSX)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Microsoft
        [HttpGet("Microsoft")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetMicrosoftDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Microsoft)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/Other
        [HttpGet("Other")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetOtherDrivers()
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .Where(driver => driver.Oem == OriginalEquipmentManufacturer.Other)
                .ToListAsync();

            return drivers;
        }

        // GET: api/DriverCore/search/{term}
        [HttpGet("search/{term}")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> SearchDrivers(string term)
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .ToListAsync();

            var filteredDrivers = drivers
                .Where(d => d.Model!.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (filteredDrivers.Count > 0)
            {
                return filteredDrivers;
            }
            else
            {
                return new List<DriverCore>();
            }
        }


        // GET: api/DriverCore/by-release/{release}
        [HttpGet("by-release/{release}")]
        public async Task<ActionResult<IEnumerable<DriverCore>>> GetDriversByRelease(string release)
        {
            if (_context.DriverCores == null)
            {
                return NotFound();
            }

            var drivers = await _context.DriverCores
                .ToListAsync();

            var filteredDrivers = drivers
                .Where(d => d.SupportedWinReleaseString.Contains(release))
                .ToList();

            if (filteredDrivers.Count > 0)
            {
                return filteredDrivers;
            }
            else
            {
                return new List<DriverCore>();
            }
        }
    }
}
