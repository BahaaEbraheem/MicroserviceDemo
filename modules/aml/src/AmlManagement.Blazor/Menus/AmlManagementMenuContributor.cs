using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace AmlManagement.Blazor.Menus
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

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(AmlManagementMenus.Prefix, displayName: "AmlManagement", "/AmlManagement", icon: "fa fa-globe"));
            
            return Task.CompletedTask;
        }
    }
}