using KotelUtilizatorLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculatorAPI.Data
{
    public class CalculationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<VariantUser> VariantUsers { get; set; }

        public CalculationDbContext(DbContextOptions<CalculationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
