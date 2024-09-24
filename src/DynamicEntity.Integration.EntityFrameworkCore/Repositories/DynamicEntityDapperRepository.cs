using Dapper;
using DynamicEntity.Integration.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.Dapper;
using Volo.Abp.EntityFrameworkCore;

namespace DynamicEntity.Integration.Repositories
{
    public class DynamicEntityDapperRepository :
        DapperRepository<IntegrationDbContext>, ITransientDependency
    {
        public DynamicEntityDapperRepository(IDbContextProvider<IntegrationDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Method to create a table dynamically
        public async Task CreateTableAsync(string tableName, string description)
        {
            var dbConnection = await GetDbConnectionAsync();
            var sql = $"CREATE TABLE {tableName} (Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(255) NOT NULL)";

            await dbConnection.ExecuteAsync(sql);
        }

        // Method to add a column dynamically
        public async Task AddColumnAsync(string tableName, string columnName, string sqlType, bool isRequired)
        {
            var dbConnection = await GetDbConnectionAsync();
            var sql = $"ALTER TABLE {tableName} ADD {columnName} {sqlType} {(isRequired ? "NOT NULL" : "NULL")}";

            await dbConnection.ExecuteAsync(sql);
        }
    }

}
