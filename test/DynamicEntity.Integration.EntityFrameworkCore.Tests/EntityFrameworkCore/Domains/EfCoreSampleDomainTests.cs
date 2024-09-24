using DynamicEntity.Integration.Samples;
using Xunit;

namespace DynamicEntity.Integration.EntityFrameworkCore.Domains;

[Collection(IntegrationTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<IntegrationEntityFrameworkCoreTestModule>
{

}
