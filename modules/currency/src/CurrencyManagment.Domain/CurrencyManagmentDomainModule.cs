using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace CurrencyManagment;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(CurrencyManagmentDomainSharedModule)
)]
[DependsOn(typeof(AbpAuthorizationModule))]
    public class CurrencyManagmentDomainModule : AbpModule
{

}
