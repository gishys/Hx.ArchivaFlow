using Hx.ArchivaFlow.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.MenuSystem.Migrations
{
    public class ArchivaFlowMigrationsContext(DbContextOptions<ArchivaFlowMigrationsContext> options) : AbpDbContext<ArchivaFlowMigrationsContext>(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArchiveConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetadataConfiguration).Assembly);
        }
    }
}
