using Hx.ArchivaFlow.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;

namespace Hx.ArchivaFlow.EntityFrameworkCore
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    [DependsOn(typeof(AbpEntityFrameworkCorePostgreSqlModule))]
    public class HxArchivaFlowEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            context.Services.AddAbpDbContext<ArchivaFlowDbContext>(options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });
            context.Services.AddAbpDbContext<ArchivaFlowDbContext>(options =>
            {
                options.AddRepository<Archive, EfCoreAchiveRepository>();
                options.AddRepository<Metadata, EfCoreMetadataRepository>();
            });
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseNpgsql(options =>
                {
                });
            });
        }
    }
}
