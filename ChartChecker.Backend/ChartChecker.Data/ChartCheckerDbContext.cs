using ChartChecker.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ChartChecker.Data
{
    public class ChartCheckerDbContext : DbContext
    {
        public virtual DbSet<ChartCheck> Depots { get; set; }

        public ChartCheckerDbContext(DbContextOptions<ChartCheckerDbContext> options) 
            : base(options)
        {}
        
        public ChartCheckerDbContext()
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
