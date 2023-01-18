using Volo.Abp;
using Volo.Abp.MongoDB;

namespace AmlManagement.MongoDB
{
    public static class AmlManagementMongoDbContextExtensions
    {
        public static void ConfigureAmlManagement(
            this IMongoModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
        }
    }
}
