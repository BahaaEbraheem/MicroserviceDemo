using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AmlManagement.EntityFrameworkCore
{
    public class AmlManagementHttpApiHostMigrationsDbContext : AbpDbContext<AmlManagementHttpApiHostMigrationsDbContext>
    {
        public AmlManagementHttpApiHostMigrationsDbContext(DbContextOptions<AmlManagementHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureAmlManagement();
        }
    }
}
