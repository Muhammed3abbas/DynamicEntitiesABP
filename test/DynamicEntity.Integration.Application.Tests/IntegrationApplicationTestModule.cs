using Volo.Abp.Modularity;

namespace DynamicEntity.Integration;

[DependsOn(
    typeof(IntegrationApplicationModule),
    typeof(IntegrationDomainTestModule)
)]
public class IntegrationApplicationTestModule : AbpModule
{

}
