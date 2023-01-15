using CustomerManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CustomerManagement.Permissions;

public class CustomerManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var CustomerManagementGroup = context.AddGroup(CustomerManagementPermissions.GroupName, L("Permission:CustomerManagement"));

        var customers = CustomerManagementGroup.AddPermission(CustomerManagementPermissions.Customers.Default, L("Permission:Customers"));
        customers.AddChild(CustomerManagementPermissions.Customers.Create, L("Permission:Create"));
        customers.AddChild(CustomerManagementPermissions.Customers.Update, L("Permission:Update"));
        customers.AddChild(CustomerManagementPermissions.Customers.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CustomerManagementResource>(name);
    }
}
