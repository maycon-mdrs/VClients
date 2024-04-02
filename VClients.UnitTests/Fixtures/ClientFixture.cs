using VClients.Api.DTOs;
using VClients.Api.Models;

namespace VClients.UnitTests.Fixtures;
public static class ClientFixture
{
    public static List<ClientDto> GetTestClientDtos()
    {
        return new List<ClientDto>{
            new()
            {
                Id =1,
                FullName = "Test1",
            },
            new()
            {
                Id=2,
                FullName="Test2",
            }
        };
    }

    public static List<Client> GetTestClients()
    {
        return new List<Client>
        {
            new()
            {
                Id =1,
                FullName = "Test1",
            },
            new()
            {
                Id =2,
                FullName= "Test2",
            },
        };
    }
}
