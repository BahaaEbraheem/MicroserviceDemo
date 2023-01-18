using AmlManagement.Localization;
using AmlManagement.Permissions;
using RemittanceManagement;
using RemittanceManagement.Localization;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace AmlManagement.Web.Menus
{
    public class AmlManagementMenuContributor : IMenuContributor
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
            var l = context.GetLocalizer<AmlManagementResource>();

            //var RMSMenu = new ApplicationMenuItem(RemittanceManagementMenus.RemittancesStatus, l["Menu:RemittancesStatus"]);
            var rootMenuItem = new ApplicationMenuItem("AmlManagement", l["Menu:AmlManagement"]);
            if (await context.IsGrantedAsync(AmlManagementPermissions.AmlRemittances.Default))
            {
                rootMenuItem.AddItem(new ApplicationMenuItem("AmlRemittances", l["Menu:AmlManagement"], "~/AmlManagement"));
            }
            context.Menu.AddItem(rootMenuItem);

        }
    }
}