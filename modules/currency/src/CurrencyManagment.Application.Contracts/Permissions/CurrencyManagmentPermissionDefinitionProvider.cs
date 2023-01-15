using CurrencyManagment.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CurrencyManagment.Permissions;

public class CurrencyManagmentPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var CurrencyManagmentGroup = context.AddGroup(CurrencyManagmentPermissions.GroupName, L("Permission:CurrencyManagment"));


        var currencies = CurrencyManagmentGroup.AddPermission(CurrencyManagmentPermissions.Currencies.Default, L("Permission:Currencies"));
        currencies.AddChild(CurrencyManagmentPermissions.Currencies.Create, L("Permission:Create"));
        currencies.AddChild(CurrencyManagmentPermissions.Currencies.Update, L("Permission:Update"));
        currencies.AddChild(CurrencyManagmentPermissions.Currencies.Delete, L("Permission:Delete"));






    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<CurrencyManagmentResource>(name);
    }
}
