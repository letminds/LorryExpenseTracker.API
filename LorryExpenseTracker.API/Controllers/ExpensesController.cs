using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LorryExpenseTracker.API.Data;
using LorryExpenseTracker.API.Models;

namespace LorryExpenseTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly FleetDbContext _context;
        public ExpensesController(FleetDbContext context) => _context = context;

        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetForVehicle(int vehicleId)
        {
            var expenses = await _context.Expenses
                .Where(e => e.VehicleId == vehicleId)
                .ToListAsync();
            return Ok(expenses);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Expense e)
        {
            _context.Expenses.Add(e);
            await _context.SaveChangesAsync();
            return Ok(e);
        }
    }
}
