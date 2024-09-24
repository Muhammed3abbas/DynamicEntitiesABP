using Xunit;

namespace DynamicEntity.Integration.EntityFrameworkCore;

[CollectionDefinition(IntegrationTestConsts.CollectionDefinitionName)]
public class IntegrationEntityFrameworkCoreCollection : ICollectionFixture<IntegrationEntityFrameworkCoreFixture>
{

}
