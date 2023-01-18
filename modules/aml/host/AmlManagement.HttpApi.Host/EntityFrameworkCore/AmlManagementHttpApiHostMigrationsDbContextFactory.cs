using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AmlManagement.EntityFrameworkCore
{
    public class AmlManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<AmlManagementHttpApiHostMigrationsDbContext>
    {
        public AmlManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AmlManagementHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("AmlManagement"));

            return new AmlManagementHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
