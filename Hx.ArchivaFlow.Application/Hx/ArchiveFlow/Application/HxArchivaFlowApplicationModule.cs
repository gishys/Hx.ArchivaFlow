using Hx.ArchivaFlow.Application.Contracts;
using Hx.ArchivaFlow.Domain;
using Hx.ArchivaFlow.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Hx.ArchiveFlow.Application
{
    [DependsOn(typeof(AbpAutoMapperModule))]
    [DependsOn(typeof(AbpDddApplicationModule))]
    [DependsOn(typeof(HxArchivaFlowDomainModule))]
    [DependsOn(typeof(HxArchivaFlowEntityFrameworkCoreModule))]
    [DependsOn(typeof(HxArchivaFlowApplicationContractsModule))]
    public class HxArchivaFlowApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<HxArchivaFlowApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<ArchivaFlowProfile>(validate: true);
            });
        }
    }
}
