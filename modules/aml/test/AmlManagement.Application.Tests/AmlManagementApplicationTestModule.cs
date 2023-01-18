using Volo.Abp.Modularity;

namespace AmlManagement
{
    [DependsOn(
        typeof(AmlManagementApplicationModule),
        typeof(AmlManagementDomainTestModule)
        )]
    public class AmlManagementApplicationTestModule : AbpModule
    {

    }
}
