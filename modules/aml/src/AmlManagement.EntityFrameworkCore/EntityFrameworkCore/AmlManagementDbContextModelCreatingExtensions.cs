using AmlManagement.Aml_Person;
using AmlManagement.Aml_Remittance;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace AmlManagement.EntityFrameworkCore
{
    public static class AmlManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureAmlManagement(
            this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));


            builder.Entity<AmlRemittance>(b =>
            {
                b.ToTable(AmlManagementDbProperties.DbTablePrefix + "AmlRemittances", AmlManagementDbProperties.DbSchema);

                b.ConfigureByConvention();
            });
            builder.Entity<AmlPerson>(b =>
            {
                b.ToTable(AmlManagementDbProperties.DbTablePrefix + "AmlPersons", AmlManagementDbProperties.DbSchema);

                b.ConfigureByConvention();
            });

        }
    }
}
