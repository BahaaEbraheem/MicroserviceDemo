using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AmlManagement
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AmlManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AmlManagementConsoleApiClientModule : AbpModule
    {

    }
}
