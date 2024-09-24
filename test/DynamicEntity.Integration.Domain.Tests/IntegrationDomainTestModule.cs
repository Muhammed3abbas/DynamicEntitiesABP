using Volo.Abp.Modularity;

namespace DynamicEntity.Integration;

[DependsOn(
    typeof(IntegrationDomainModule),
    typeof(IntegrationTestBaseModule)
)]
public class IntegrationDomainTestModule : AbpModule
{

}
