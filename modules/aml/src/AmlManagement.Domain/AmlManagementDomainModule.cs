using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace AmlManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AmlManagementDomainSharedModule)
    )]
    public class AmlManagementDomainModule : AbpModule
    {

    }
}
