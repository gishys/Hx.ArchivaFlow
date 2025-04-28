using Localization;
using Volo.Abp.Application.Services;

namespace Hx.ArchiveFlow.Application
{
    public class BaseAppService : ApplicationService
    {
        protected BaseAppService()
        {
            LocalizationResource = typeof(ArchivaFlowResource);
        }
        public string GetLocalization(string name)
        {
            return L[name];
        }
    }
}
