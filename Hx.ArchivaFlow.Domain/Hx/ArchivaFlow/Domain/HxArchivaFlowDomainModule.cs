using Hx.ArchivaFlow.Domain.Shared;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hx.ArchivaFlow.Domain
{
    [DependsOn(typeof(AbpDddDomainModule))]
    [DependsOn(typeof(HxArchivaFlowDomainSharedModule))]
    public class HxArchivaFlowDomainModule : AbpModule
    {

    }
}