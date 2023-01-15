using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using CurrencyManagment;
using CustomerManagement;
using Volo.Abp.Localization;
using Volo.Abp.VirtualFileSystem;

namespace RemittanceManagement;

[DependsOn(
    typeof(RemittanceManagementDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule),
    typeof(AbpDddApplicationModule),
    typeof(CurrencyManagmentApplicationContractsModule),
    typeof(CustomerManagementApplicationContractsModule)
    )]
public class RemittanceManagementApplicationContractsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<RemittanceManagementApplicationContractsModule>();
        });

     
    }
}
