using Volo.Abp.Modularity;

namespace DynamicEntity.Integration;

/* Inherit from this class for your domain layer tests. */
public abstract class IntegrationDomainTestBase<TStartupModule> : IntegrationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
