using Hx.ArchivaFlow.Domain.Shared;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Hx.ArchivaFlow.Application.Contracts
{
    [DependsOn(typeof(HxArchivaFlowDomainSharedModule))]
    [DependsOn(typeof(AbpDddApplicationContractsModule))]
    public class HxArchivaFlowApplicationContractsModule : AbpModule
    {
    }
}
