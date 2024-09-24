using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace DynamicEntity.Integration.Dtos
{
    public class DynamicEntityDto : EntityDto<int>
    {
        public string TableName { get; set; }
        public string? Description { get; set; }

    }
}
