using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace AmlManagement.MongoDB
{
    [ConnectionStringName(AmlManagementDbProperties.ConnectionStringName)]
    public class AmlManagementMongoDbContext : AbpMongoDbContext, IAmlManagementMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureAmlManagement();
        }
    }
}