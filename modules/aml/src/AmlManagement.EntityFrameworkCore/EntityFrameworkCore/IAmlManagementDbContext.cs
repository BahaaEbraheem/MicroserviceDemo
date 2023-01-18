using AmlManagement.Aml_Person;
using AmlManagement.Aml_Remittance;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace AmlManagement.EntityFrameworkCore
{
    [ConnectionStringName(AmlManagementDbProperties.ConnectionStringName)]
    public interface IAmlManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        public DbSet<AmlRemittance> AmlRemittances { get; set; }
        public DbSet<AmlPerson> AmlPersons { get; set; }

    }
}