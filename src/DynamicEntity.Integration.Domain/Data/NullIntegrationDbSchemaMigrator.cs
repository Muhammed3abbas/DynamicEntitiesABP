using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DynamicEntity.Integration.Data;

/* This is used if database provider does't define
 * IIntegrationDbSchemaMigrator implementation.
 */
public class NullIntegrationDbSchemaMigrator : IIntegrationDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
