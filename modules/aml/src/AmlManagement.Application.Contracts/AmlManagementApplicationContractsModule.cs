using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using RemittanceManagement;

namespace AmlManagement
{
    [DependsOn(
        typeof(AmlManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule),
        typeof(RemittanceManagementApplicationContractsModule)

        )]
    public class AmlManagementApplicationContractsModule : AbpModule
    {

    }
}
