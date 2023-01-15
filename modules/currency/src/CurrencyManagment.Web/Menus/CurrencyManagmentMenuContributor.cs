using CurrencyManagment.Localization;
using CurrencyManagment.Permissions;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace CurrencyManagment.Web.Menus;

public class CurrencyManagmentMenuContributor : IMenuContributor
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
        var l = context.GetLocalizer<CurrencyManagmentResource>();
        var rootMenuItem = new ApplicationMenuItem("CurrencyManagment", l["Menu:CurrencyManagment"]);

        if (await context.IsGrantedAsync(CurrencyManagmentPermissions.Currencies.Default))
        {
            //Add main menu items.
            rootMenuItem.AddItem(new ApplicationMenuItem(CurrencyManagmentMenus.Prefix, displayName: l["Menu:CurrencyManagment"], "~/CurrencyManagment", icon: "fa fa-globe"));
        }
        context.Menu.AddItem(rootMenuItem);
    }
}
