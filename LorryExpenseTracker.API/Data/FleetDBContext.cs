using Microsoft.EntityFrameworkCore;
using LorryExpenseTracker.API.Models;

namespace LorryExpenseTracker.API.Data
{
    public class FleetDbContext : DbContext
    {
        public FleetDbContext(DbContextOptions<FleetDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
