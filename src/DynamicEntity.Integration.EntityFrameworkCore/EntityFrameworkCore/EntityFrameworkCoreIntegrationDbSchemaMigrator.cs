using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DynamicEntity.Integration.Data;
using Volo.Abp.DependencyInjection;

namespace DynamicEntity.Integration.EntityFrameworkCore;

public class EntityFrameworkCoreIntegrationDbSchemaMigrator
    : IIntegrationDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreIntegrationDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the IntegrationDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<IntegrationDbContext>()
            .Database
            .MigrateAsync();
    }
}
