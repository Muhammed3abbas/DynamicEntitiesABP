using AutoMapper;
using DynamicEntity.Integration.Dtos;
using DynamicEntity.Integration.Entities;

namespace DynamicEntity.Integration;

public class IntegrationApplicationAutoMapperProfile : Profile
{
    public IntegrationApplicationAutoMapperProfile()
    {

        CreateMap<DynamicEntitey, DynamicEntityDto>();
        CreateMap<DynamicEntityDto, DynamicEntitey>();


        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
