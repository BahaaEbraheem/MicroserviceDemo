using Localization.Resources.AbpUi;
using AmlManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace AmlManagement
{
    [DependsOn(
        typeof(AmlManagementApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AmlManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AmlManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AmlManagementResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
