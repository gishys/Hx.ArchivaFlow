using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Hx.ArchivaFlow.Domain
{
    [DependsOn(typeof(AbpDddDomainModule))]
    public class HxArchivaFlowDomainModule : AbpModule
    {

    }
}