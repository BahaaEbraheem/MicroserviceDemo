using AmlManagement.Localization;
using RemittanceManagement;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AmlManagement.Permissions
{
    public class AmlManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {

            var AmlManagementGroup = context.AddGroup(AmlManagementPermissions.GroupName, L("Permission:AmlManagement"));
            var remittances = AmlManagementGroup.AddPermission(AmlManagementPermissions.AmlRemittances.Default, L("Permission:AmlRemittance"));
            remittances.AddChild(AmlManagementPermissions.AmlRemittances.Check, L("Permission:Check"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AmlManagementResource>(name);
        }
    }
}