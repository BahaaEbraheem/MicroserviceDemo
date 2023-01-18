using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace AmlManagement
{
    [DependsOn(
        typeof(AmlManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AmlManagementHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AmlManagementApplicationContractsModule).Assembly,
                AmlManagementRemoteServiceConsts.RemoteServiceName
            );

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AmlManagementHttpApiClientModule>();
            });

        }
    }
}
