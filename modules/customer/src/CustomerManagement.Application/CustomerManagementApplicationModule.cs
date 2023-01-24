using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using RemittanceManagement;

namespace CustomerManagement;

[DependsOn(
    typeof(CustomerManagementDomainModule),
    typeof(CustomerManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(RemittanceManagementHttpApiClientModule)




    )]
public class CustomerManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<CustomerManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CustomerManagementApplicationModule>(validate: true);
        });
    }
}
