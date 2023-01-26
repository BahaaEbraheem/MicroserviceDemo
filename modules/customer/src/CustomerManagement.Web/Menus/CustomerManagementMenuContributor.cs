using CustomerManagement.Localization;
using CustomerManagement.Permissions;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace CustomerManagement.Web.Menus;

public class CustomerManagementMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<CustomerManagementResource>();
        var rootMenuItem = new ApplicationMenuItem(CustomerManagementMenus.Prefix, displayName: l["Menu:CustomerManagement"]);

        if (await context.IsGrantedAsync(CustomerManagementPermissions.Customers.Default))
        {
            //Add main menu items.
            rootMenuItem.AddItem(new ApplicationMenuItem(CustomerManagementMenus.Prefix, displayName: l["Menu:CustomerManagement"], "~/CustomerManagement", icon: "fa fa-globe"));
        }
        //context.Menu.AddItem(rootMenuItem);
        //Add main menu items.

    }
}
