using Hx.ArchivaFlow.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Hx.ArchivaFlow.HttpApi
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(HxArchivaFlowApplicationContractsModule))]
    public class HxArchivaFlowHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure(delegate (IMvcBuilder mvcBuilder)
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(HxArchivaFlowHttpApiModule).Assembly);
            });
        }
    }
}
