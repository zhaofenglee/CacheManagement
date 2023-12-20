using System;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace JS.Abp.CacheManagement.MongoDB;

[DependsOn(
    typeof(CacheManagementApplicationTestModule),
    typeof(CacheManagementMongoDbModule)
)]
public class CacheManagementMongoDbTestModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
        });
    }
}
