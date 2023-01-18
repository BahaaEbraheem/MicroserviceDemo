using AmlManagement.Aml_Person;
using AmlManagement.Aml_Remittance;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AmlManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(AmlManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AmlManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AmlManagementDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                
                options.AddRepository<AmlPerson, AmlPersonRepository>();
                options.AddRepository<AmlRemittance, AmlRemittanceRepository>();
                options.AddDefaultRepositories();

            });
        }
    }
}