using Crumbs.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Crumbs.Data
{
    public class CrumbsDbContext : DbContext
    {
        public CrumbsDbContext(DbContextOptions<CrumbsDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public virtual DbSet<Crumb> Crumbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Crumb>()
                .HasKey(e => e.Id);
            
            modelBuilder
                .Entity<Crumb>()
                .HasMany(e => e.Observers)
                .WithOne(e => e.Broadcaster);

            base.OnModelCreating(modelBuilder);
        }
    }
}