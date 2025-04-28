using Localization;
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
            menuPermission.AddChild("ArchivaFlow.CreateAttachment", L("Permission:ArchivaFlow.CreateAttachment"));
            menuPermission.AddChild("ArchivaFlow.DeleteAttachment", L("Permission:ArchivaFlow.DeleteAttachment"));
            menuPermission.AddChild("ArchivaFlow.AttachmentList", L("Permission:ArchivaFlow.AttachmentList"));
        }
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ArchivaFlowResource>(name);
        }
    }
}
