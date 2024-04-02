using VClients.Api.DTOs;
using VClients.Api.Models;

namespace VClients.UnitTests.Fixtures;
public static class CustomerFixture
{
    public static List<CustomerDTO> GetTestCustomerDTOs()
    {
        return new List<CustomerDTO>{
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

    public static List<Customer> GetTestCustomers()
    {
        return new List<Customer>
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
