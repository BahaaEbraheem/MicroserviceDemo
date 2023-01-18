using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using RemittanceManagement.Localization;
using Microsoft.Extensions.Localization;
using RemittanceManagement.Remittances;

namespace RemittanceManagement.Web.Menus;

public class RemittanceManagementMenuContributor : IMenuContributor
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
        var l = context.GetLocalizer<RemittanceManagementResource>();

        var rootMenuItem = new ApplicationMenuItem("RemittanceManagement", l["Menu:RemittanceManagement"]);
        if (await context.IsGrantedAsync(RemittanceManagementPermissions.Remittances.Default))
        {
            rootMenuItem.AddItem(new ApplicationMenuItem("Remittances", l["Menu:Remittances"], "~/RemittanceManagement", icon: "fa fa-globe"));
        
        if (await context.IsGrantedAsync(RemittanceManagementPermissions.Remittances.Approved))
        {
            rootMenuItem.AddItem(new ApplicationMenuItem("Remittances", l["Menu:RemittanceForSupervisor"], "~/RemittanceForSupervisor", icon: "fa fa-globe"));
        }
        if (await context.IsGrantedAsync(RemittanceManagementPermissions.Remittances.Released))
        {
            rootMenuItem.AddItem(new ApplicationMenuItem("Remittances", l["Menu:RemittanceForReleaser"], "~/RemittanceForReleaser", icon: "fa fa-globe"));
        }
            rootMenuItem.AddItem(new ApplicationMenuItem("Remittances", l["Menu:RemittanceStatusForAll"], "~/RemittanceStatus", icon: "fa fa-globe"));
        }
        
        context.Menu.AddItem(rootMenuItem);




        //RMSMenu.AddItem(new ApplicationMenuItem(RemittanceManagementMenus.RemittancesStatus, l["Menu:RemittancesStatus"],url: "/remittancesstatus",icon: "fas fa-home",order: 0));

        //RMSMenu.AddItem(new ApplicationMenuItem(RemittanceManagementMenus.Remittances,l["Menu:Remittances"],url: "~/RemittanceManagement", icon: "fas fa-home",order: 0));

        //RMSMenu.AddItem(new ApplicationMenuItem(RemittanceManagementMenus.ReadyRemittances,l["Menu:ReadyRemittances"],url: "/readyremittances",icon: "fas fa-home",order: 0));

        //RMSMenu.AddItem(new ApplicationMenuItem(RemittanceManagementMenus.ApprovedRemittances,l["Menu:ApprovedRemittances"],url: "/approvedremittances",icon: "fas fa-home",order: 0));


        //Add main menu items.
        //context.Menu.AddItem(new ApplicationMenuItem(RemittanceManagementMenus.Prefix, displayName: "RemittanceManagement", "~/RemittanceManagement", icon: "fa fa-globe"));

    }
}
