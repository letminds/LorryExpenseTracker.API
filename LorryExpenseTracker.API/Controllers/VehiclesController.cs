using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LorryExpenseTracker.API.Data;
using LorryExpenseTracker.API.Models;

namespace LorryExpenseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly FleetDbContext _context;
        public VehiclesController(FleetDbContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Vehicles.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Add(Vehicle v)
        {
            _context.Vehicles.Add(v);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = v.Id }, v);
        }
    }
}
