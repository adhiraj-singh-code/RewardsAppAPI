using Microsoft.EntityFrameworkCore;
using RewardsAppAPI.Models;

namespace RewardsAppAPI.Data
{
    public class RewardsDbContext : DbContext
    {
        public RewardsDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
