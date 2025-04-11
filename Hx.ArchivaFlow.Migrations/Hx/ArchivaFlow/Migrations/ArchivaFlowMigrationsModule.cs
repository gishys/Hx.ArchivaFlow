using Hx.ArchivaFlow.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Hx.MenuSystem.Migrations
{
    public class ArchivaFlowMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ArchivaFlowDbContext>();
        }
    }
}
