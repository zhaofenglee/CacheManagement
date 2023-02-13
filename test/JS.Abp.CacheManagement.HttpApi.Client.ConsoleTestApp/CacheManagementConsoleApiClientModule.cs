using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace JS.Abp.CacheManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CacheManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class CacheManagementConsoleApiClientModule : AbpModule
{

}
