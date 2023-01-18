using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.EventBus.RabbitMq;

namespace AmlManagement
{
    [DependsOn(
        typeof(AmlManagementDomainModule),
        typeof(AmlManagementApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule),
        typeof(AbpEventBusRabbitMqModule)

        )]
    public class AmlManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AmlManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AmlManagementApplicationModule>(validate: true);
            });
        }
    }
}
