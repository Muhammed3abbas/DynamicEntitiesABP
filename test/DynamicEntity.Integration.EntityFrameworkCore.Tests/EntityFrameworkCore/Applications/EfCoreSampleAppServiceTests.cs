using DynamicEntity.Integration.Samples;
using Xunit;

namespace DynamicEntity.Integration.EntityFrameworkCore.Applications;

[Collection(IntegrationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<IntegrationEntityFrameworkCoreTestModule>
{

}
