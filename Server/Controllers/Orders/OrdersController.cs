using Microsoft.AspNetCore.Mvc;
using OptechX.Portal.Server.Data;

namespace OptechX.Portal.Server.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public OrdersController(ApiDbContext context)
        {
            _context = context;
        }
    }
}
