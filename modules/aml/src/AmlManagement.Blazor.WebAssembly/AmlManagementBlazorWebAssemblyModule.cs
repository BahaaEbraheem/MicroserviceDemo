using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace AmlManagement.Blazor.WebAssembly
{
    [DependsOn(
        typeof(AmlManagementBlazorModule),
        typeof(AmlManagementHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class AmlManagementBlazorWebAssemblyModule : AbpModule
    {
        
    }
}