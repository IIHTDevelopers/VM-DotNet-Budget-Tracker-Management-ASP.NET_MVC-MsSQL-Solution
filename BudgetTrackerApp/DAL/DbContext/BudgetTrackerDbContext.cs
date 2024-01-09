
using BudgetTrackerApp.Models;
using System.Data.Entity;

namespace BudgetTrackerApp.DAL
{
    public class BudgetTrackerDbContext : DbContext
    {
        public BudgetTrackerDbContext()
            : base("name=DefaultConnection")
        {
        }
        public DbSet<Budget> Budgets { get; set; }
    }
}