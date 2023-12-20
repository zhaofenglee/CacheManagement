using JS.Abp.CacheManagement.MongoDB;
using JS.Abp.CacheManagement.Samples;
using Xunit;

namespace JS.Abp.CacheManagement.MongoDb.Applications;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleAppService_Tests : SampleAppService_Tests<CacheManagementMongoDbTestModule>
{

}
