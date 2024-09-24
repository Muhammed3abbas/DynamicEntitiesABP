using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace DynamicEntity.Integration.Entities
{
    public class DynamicEntitey : FullAuditedEntity<int>
    {
        public string TableName { get; set; }
        public string? Description { get; set; }
    }
}
