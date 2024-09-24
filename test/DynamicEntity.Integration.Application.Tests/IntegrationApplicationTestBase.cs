using Volo.Abp.Modularity;

namespace DynamicEntity.Integration;

public abstract class IntegrationApplicationTestBase<TStartupModule> : IntegrationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
