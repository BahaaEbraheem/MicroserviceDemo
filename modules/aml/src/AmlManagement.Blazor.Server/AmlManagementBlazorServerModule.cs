using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace AmlManagement.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(AmlManagementBlazorModule)
        )]
    public class AmlManagementBlazorServerModule : AbpModule
    {
        
    }
}