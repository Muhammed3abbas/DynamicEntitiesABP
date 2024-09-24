using Dapper;
using DynamicEntity.Integration.Dtos;
using DynamicEntity.Integration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace DynamicEntity.Integration.Services.DynamicEntityService
{
    public class DynamicEntityAppService : CrudAppService<DynamicEntitey, DynamicEntityDto, int, PagedResultRequestDto>
    {
        public DynamicEntityAppService(IRepository<DynamicEntitey, int> repository) : base(repository)
        {
        }

        // Override CreateAsync to include logic for dynamically creating a table
        public override async Task<DynamicEntityDto> CreateAsync(DynamicEntityDto input)
        {

            var DynamicEntitiesName = await Repository.FirstOrDefaultAsync(e => e.TableName == input.TableName);

            if (DynamicEntitiesName != null) {

                throw new UserFriendlyException($"Table '{input.TableName}' already exists.");

            }

            var newEntity = await base.CreateAsync(input);

            // After the entity is created, dynamically create the corresponding table in the DB using Dapper
            var dbContext = await Repository.GetDbContextAsync();
            var dbConnection = dbContext.Database.GetDbConnection();
            var dbTransaction = dbContext.Database.CurrentTransaction?.GetDbTransaction();



            var createTableSql = $@"
                CREATE TABLE [dbo].{input.TableName} (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(255)
                )";

            // Execute the table creation
            await dbConnection.ExecuteAsync(createTableSql, transaction: dbTransaction);

            return newEntity ;
        }

        public async Task<DynamicEntityUpdateDto> AddColumnAsync(DynamicEntityUpdateDto input)
        {
            // Step 1: Fetch the DynamicEntity (Table) from the database by TableName
            var dynamicEntity = await Repository.FirstOrDefaultAsync(e => e.TableName == input.TableName);

            if (dynamicEntity == null)
            {
                throw new UserFriendlyException($"Dynamic Entity with table name '{input.TableName}' does not exist.");
            }

            // Step 2: Validate that the column does not already exist in the table
            var dbContext = await Repository.GetDbContextAsync();
            var dbConnection = dbContext.Database.GetDbConnection();
            var dbTransaction = dbContext.Database.CurrentTransaction?.GetDbTransaction();

            // Query to check if the column already exists
            var checkColumnSql = $@"
                                    SELECT COUNT(*) 
                                    FROM INFORMATION_SCHEMA.COLUMNS 
                                    WHERE TABLE_NAME = @TableName 
                                    AND COLUMN_NAME = @ColumnName";

            var columnExists = await dbConnection.ExecuteScalarAsync<int>(
                checkColumnSql,
                new { TableName = input.TableName, ColumnName = input.ColumnName },
                transaction: dbTransaction
            );

            if (columnExists > 0)
            {
                throw new UserFriendlyException($"Column '{input.ColumnName}' already exists in table '{input.TableName}'.");
            }

            // Step 3: Add the new column to the table with the provided SQL type
            //var addColumnSql = $@"
            //ALTER TABLE {input.TableName} 
            //ADD {input.ColumnName} {input.SqlType}";


            var addColumnSql = $@"
            ALTER TABLE 
            {input.TableName} 
            ADD 
            {input.ColumnName} {input.SqlType} {(input.IsRequired ? "NOT NULL" : "NULL")}";
            await dbConnection.ExecuteAsync(addColumnSql, transaction: dbTransaction);
            return input;
        }

        public async Task<DynamicEntityBulkUpdateDto> BulkAddColumnsAsync(DynamicEntityBulkUpdateDto input)
        {
            // Step 1: Fetch the DynamicEntity (Table) from the database by TableName
            var dynamicEntity = await Repository.FirstOrDefaultAsync(e => e.TableName == input.TableName);

            if (dynamicEntity == null)
            {
                throw new UserFriendlyException($"Dynamic Entity with table name '{input.TableName}' does not exist.");
            }

            // Step 2: Get DB connection and transaction
            var dbContext = await Repository.GetDbContextAsync();
            var dbConnection = dbContext.Database.GetDbConnection();
            var dbTransaction = dbContext.Database.CurrentTransaction?.GetDbTransaction();

            // Step 3: Loop through each column in the input
            foreach (var column in input.Columns)
            {
                // Query to check if the column already exists
                var checkColumnSql = $@"
            SELECT COUNT(*) 
            FROM INFORMATION_SCHEMA.COLUMNS 
            WHERE TABLE_NAME = @TableName 
            AND COLUMN_NAME = @ColumnName";

                var columnExists = await dbConnection.ExecuteScalarAsync<int>(
                    checkColumnSql,
                    new { TableName = input.TableName, ColumnName = column.ColumnName },
                    transaction: dbTransaction
                );

                if (columnExists > 0)
                {
                    throw new UserFriendlyException($"Column '{column.ColumnName}' already exists in table '{input.TableName}'.");
                }

                // Step 4: Add the new column to the table with the provided SQL type and required/not required
                var addColumnSql = $@"
            ALTER TABLE {input.TableName} 
            ADD {column.ColumnName} {column.SqlType} {(column.IsRequired ? "NOT NULL" : "NULL")}";

                await dbConnection.ExecuteAsync(addColumnSql, transaction: dbTransaction);
            }

            return input;
        }



        public override Task<PagedResultDto<DynamicEntityDto>> GetListAsync(PagedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        public override Task<DynamicEntityDto> GetAsync(int id)
        {
            return base.GetAsync(id);

        }

        protected override Task DeleteByIdAsync(int id)
        {
            return base.DeleteByIdAsync(id);
        }

        public List<SqlTypeDto> GetSupportedSqlTypes()
        {
            var sqlTypes = new List<SqlTypeDto>
        {
            new SqlTypeDto { Name = "INT" },
            new SqlTypeDto { Name = "NVARCHAR(255)" },
            new SqlTypeDto { Name = "DECIMAL(18,2)" },
            new SqlTypeDto { Name = "DATETIME" },
            new SqlTypeDto { Name = "BIT" },
            new SqlTypeDto { Name = "FLOAT" }
        };

            return sqlTypes;
        }


    }
}
