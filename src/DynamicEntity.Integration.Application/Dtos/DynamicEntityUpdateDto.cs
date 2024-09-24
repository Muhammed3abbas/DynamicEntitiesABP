using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace DynamicEntity.Integration.Dtos
{
    public class DynamicEntityUpdateDto : EntityDto<int>
    {
        public string TableName { get; set; }
        //public string? Description { get; set; }
        public string ColumnName { get; set; }
        public string SqlType { get; set; }  // Holds the SQL type like "INT", "NVARCHAR(255)", etc.
        public bool IsRequired { get; set; }  // To determine if the column is NOT NULL or NULL

    }
}
