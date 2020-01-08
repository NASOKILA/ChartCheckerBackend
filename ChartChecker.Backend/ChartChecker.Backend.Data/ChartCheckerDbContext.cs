using ChartChecker.Backend.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace ChartChecker.Backend.Data
{
    public class ChartCheckerDbContext : DbContext
    {
        public ChartCheckerDbContext(DbContextOptions<ChartCheckerDbContext> options)
            : base(options)
        { }

        public ChartCheckerDbContext()
        { }

        public virtual DbSet<ChartCheck> ChartCheck { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
