using Microsoft.Extensions.DependencyInjection;
using RemittanceManagement.Remittances;
using RemittanceManagement.Status;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace RemittanceManagement.EntityFrameworkCore;

[DependsOn(
    typeof(RemittanceManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class RemittanceManagementEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<RemittanceManagementDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddRepository<Remittance, EfCoreRemittanceRepository>();
            options.AddRepository<RemittanceStatus, EfCoreRemittanceStatusRepository>();

            options.AddDefaultRepositories();
        });
    }
}
