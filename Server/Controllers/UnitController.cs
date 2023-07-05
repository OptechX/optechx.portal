using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptechX.Portal.Shared;

namespace OptechX.Portal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        public IList<Unit> Units => new List<Unit>
        {
            new Unit { Id = 1, Title = "Knight", Attack = 10, Defense = 10, BananaCost = 100},
            new Unit { Id = 2, Title = "Archer", Attack = 10, Defense = 10, BananaCost = 100},
            new Unit { Id = 3, Title = "Mage", Attack = 10, Defense = 10, BananaCost = 100},
        };

        [HttpGet]
        public IActionResult GetUnits()
        {
            return Ok(Units);
        }
    }
}
