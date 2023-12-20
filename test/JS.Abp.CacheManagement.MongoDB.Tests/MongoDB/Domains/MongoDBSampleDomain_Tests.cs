using JS.Abp.CacheManagement.Samples;
using Xunit;

namespace JS.Abp.CacheManagement.MongoDB.Domains;

[Collection(MongoTestCollection.Name)]
public class MongoDBSampleDomain_Tests : SampleManager_Tests<CacheManagementMongoDbTestModule>
{

}
