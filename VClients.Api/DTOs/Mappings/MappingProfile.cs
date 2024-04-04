using AutoMapper;

namespace VClients.Api.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Models.Customer, CustomerDTO>().ReverseMap();
        CreateMap<Models.Customer, CustomerRequestDTO>().ReverseMap();
        CreateMap<Models.FullAddress, FullAddressDTO>().ReverseMap();
    }
}