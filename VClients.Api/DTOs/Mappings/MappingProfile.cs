using AutoMapper;

namespace VClients.Api.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.Client, ClientDto>().ReverseMap();
        CreateMap<Models.Adress, AdressDto>().ReverseMap();
    }
}