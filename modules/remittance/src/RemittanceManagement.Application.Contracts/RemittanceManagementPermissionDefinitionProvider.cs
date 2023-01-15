using RemittanceManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RemittanceManagement;

public class RemittanceManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var RemittanceManagementGroup = context.AddGroup(RemittanceManagementPermissions.GroupName, L("Permission:RemittanceManagement"));
        var remittances = RemittanceManagementGroup.AddPermission(RemittanceManagementPermissions.Remittances.Default, L("Permission:Remittances"));
        remittances.AddChild(RemittanceManagementPermissions.Remittances.Create, L("Permission:Create"));
        remittances.AddChild(RemittanceManagementPermissions.Remittances.Update, L("Permission:Edit"));
        remittances.AddChild(RemittanceManagementPermissions.Remittances.Delete, L("Permission:Delete"));
        remittances.AddChild(RemittanceManagementPermissions.Remittances.Ready, L("Permission:Ready"));
        remittances.AddChild(RemittanceManagementPermissions.Remittances.Approved, L("Permission:Approved"));
        remittances.AddChild(RemittanceManagementPermissions.Remittances.Released, L("Permission:Released"));

    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RemittanceManagementResource>(name);
    }
}
