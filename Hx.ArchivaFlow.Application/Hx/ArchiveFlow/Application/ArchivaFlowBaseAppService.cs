using Localization;
using Volo.Abp.Application.Services;

namespace Hx.ArchiveFlow.Application
{
    public class ArchivaFlowBaseAppService : ApplicationService
    {
        protected ArchivaFlowBaseAppService()
        {
            LocalizationResource = typeof(ArchivaFlowResource);
        }
        public string GetLocalization(string name)
        {
            return L[name];
        }
    }
}
