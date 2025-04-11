using Hx.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hx.ArchivaFlow.Application.Contracts
{
    public class ArchivaFlowDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup("ArchivaFlow", L("Permission:ArchivaFlow"));
            var menuPermission = myGroup.AddPermission("ArchivaFlow.Default", L("Permission:ArchivaFlow.Default"));
            menuPermission.AddChild("ArchivaFlow.CreateOrUpdate", L("Permission:ArchivaFlow.CreateOrUpdate"));
            menuPermission.AddChild("ArchivaFlow.Delete", L("Permission:ArchivaFlow.Delete"));
        }
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ArchivaFlowResource>(name);
        }
    }
}
