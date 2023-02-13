using Volo.Abp;
using Volo.Abp.MongoDB;

namespace JS.Abp.CacheManagement.MongoDB;

public static class CacheManagementMongoDbContextExtensions
{
    public static void ConfigureCacheManagement(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
