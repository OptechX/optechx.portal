using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OptechX.Portal.Server.Data;
using OptechX.Portal.Shared.Models.Engine.ImageBuilds;

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

        [HttpGet("orderslistbyaccountid/{accountId}")]
        public async Task<ActionResult<IEnumerable<ImageBuildBasic>>> GetImageBuildBasicByAccountId(string accountId)
        {
            var result = await _context.ImageBuildBasics!.Where(r => r.AccountId == accountId).ToListAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // POST: api/Orders
        [HttpPost()]
        public async Task<ActionResult<ImageBuildBasic>> PostImageBuildBasic(ImageBuildBasic imageBuildBasic)
        {
            if (_context.ImageBuildBasics == null)
                return Problem("Entity set 'ApiDbContext.ImageBuildBasics' is null");

            try
            {
                _context.ImageBuildBasics.Add(imageBuildBasic);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                // Handle the exception caused by a duplicate UID
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                {
                    return Conflict("An ImageBuildBasic with the same ID already exists.");
                }

                return Problem("An error occurred while saving the application.", statusCode: 500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageBuildBasic(int id)
        {
            if (_context.ImageBuildBasics == null)
                return Problem("Entity set 'ApiDbContext.ImageBuildBasics' is null");
            var build = await _context.ImageBuildBasics.FindAsync(id);
            if (build == null)
                return NotFound();
            _context.ImageBuildBasics.Remove(build);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
