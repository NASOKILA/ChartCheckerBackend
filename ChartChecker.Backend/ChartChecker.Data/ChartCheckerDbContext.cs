using ChartChecker.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ChartChecker.Data
{
    public class ChartCheckerDbContext : DbContext
    {
        public ChartCheckerDbContext(DbContextOptions<ChartCheckerDbContext> options) 
            : base(options)
        {}
        
        public ChartCheckerDbContext()
        {}

        public virtual DbSet<ChartCheck> ChartChecks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured) {
                
                optionsBuilder.UseSqlServer("");
            }
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
