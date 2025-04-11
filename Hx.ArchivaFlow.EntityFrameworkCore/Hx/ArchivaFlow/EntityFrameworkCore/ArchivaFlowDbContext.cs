using Hx.ArchivaFlow.Domain;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hx.ArchivaFlow.EntityFrameworkCore
{
    public class ArchivaFlowDbContext(DbContextOptions<ArchivaFlowDbContext> options) : AbpDbContext<ArchivaFlowDbContext>(options)
    {
        public virtual DbSet<Archive> Archives { get; set; }
        public virtual DbSet<Metadata> Metadata { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArchiveConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MetadataConfiguration).Assembly);
        }
    }
}
