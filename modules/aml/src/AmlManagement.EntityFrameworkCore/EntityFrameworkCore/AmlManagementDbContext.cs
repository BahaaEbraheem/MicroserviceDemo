using AmlManagement.Aml_Person;
using AmlManagement.Aml_Remittance;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AmlManagement.EntityFrameworkCore
{
    [ConnectionStringName(AmlManagementDbProperties.ConnectionStringName)]
    public class AmlManagementDbContext : AbpDbContext<AmlManagementDbContext>, IAmlManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<AmlRemittance> AmlRemittances { get; set; }
        public DbSet<AmlPerson> AmlPersons { get; set; }

        public AmlManagementDbContext(DbContextOptions<AmlManagementDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAmlManagement();
        }
    }
}