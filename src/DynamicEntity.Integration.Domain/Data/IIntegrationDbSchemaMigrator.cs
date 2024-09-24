using System.Threading.Tasks;

namespace DynamicEntity.Integration.Data;

public interface IIntegrationDbSchemaMigrator
{
    Task MigrateAsync();
}
