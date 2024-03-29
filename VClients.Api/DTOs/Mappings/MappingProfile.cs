using AutoMapper;

namespace VClients.Api.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.ClientModel, ClientDto>().ReverseMap();
        CreateMap<Models.AdressModel, AdressDto>().ReverseMap();
    }
}