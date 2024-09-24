using DynamicEntity.Integration.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DynamicEntity.Integration.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IntegrationEntityFrameworkCoreModule),
    typeof(IntegrationApplicationContractsModule)
)]
public class IntegrationDbMigratorModule : AbpModule
{
}
