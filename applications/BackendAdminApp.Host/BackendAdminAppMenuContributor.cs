using System;
using System.Threading.Tasks;
using CurrencyManagment.Localization;
using CurrencyManagment.Permissions;
using CurrencyManagment.Web.Menus;
using CustomerManagement.Localization;
using CustomerManagement.Permissions;
using CustomerManagement.Web.Menus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement;
using ProductManagement.Localization;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace BackendAdminApp.Host
{
    public class BackendAdminAppMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public BackendAdminAppMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.User)
            {
                await ConfigureUserMenuAsync(context);
            }
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }
        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l1 = context.GetLocalizer<CustomerManagementResource>();
            var l2 = context.GetLocalizer<CurrencyManagmentResource>();
            var l3 = context.GetLocalizer<ProductManagementResource>();

            var rootMenuItem = new ApplicationMenuItem("MicroseviceStatics", "MicroseviceStatics");

            if (await context.IsGrantedAsync(CurrencyManagmentPermissions.Currencies.Default))
            {
                rootMenuItem.AddItem(new ApplicationMenuItem(CurrencyManagmentMenus.Prefix, displayName: l2["Menu:CurrencyManagment"], "~/CurrencyManagment", icon: "fa fa-money"));
            }
            if (await context.IsGrantedAsync(CustomerManagementPermissions.Customers.Default))
            {
                rootMenuItem.AddItem(new ApplicationMenuItem(CustomerManagementMenus.Prefix, displayName: l1["Menu:CustomerManagement"], "~/CustomerManagement", icon: "fa fa-users"));
            }
            if (await context.IsGrantedAsync(ProductManagementPermissions.Products.Default))
            {
                rootMenuItem.AddItem(new ApplicationMenuItem("Products", l3["Menu:Products"], "~/ProductManagement/Products", icon: "fa fa-globe"));
            }
            context.Menu.AddItem(rootMenuItem);
        }
        private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var currentUser = context.ServiceProvider.GetRequiredService<ICurrentUser>();

            var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";

            if (currentUser.IsAuthenticated)
            {
                //TODO: Localize menu items
                context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", "Manage Your Profile", $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog", order: 1000, null, "_blank"));
                context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", "Logout", url: "/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000));
            }

            return Task.CompletedTask;
        }
    }
}
