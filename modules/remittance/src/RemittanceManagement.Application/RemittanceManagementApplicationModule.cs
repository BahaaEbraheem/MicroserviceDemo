using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using CurrencyManagment;
using CustomerManagement;
using Volo.Abp.EventBus.RabbitMq;

namespace RemittanceManagement;

[DependsOn(
    typeof(RemittanceManagementDomainModule),
    typeof(RemittanceManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(CurrencyManagmentHttpApiClientModule),
    typeof(CustomerManagementHttpApiClientModule),
    typeof(AbpEventBusRabbitMqModule)


    )]
public class RemittanceManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<RemittanceManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<RemittanceManagementApplicationModule>(validate: true);
        });
    }
}
