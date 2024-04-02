using AutoMapper;
using FluentAssertions;
using Moq;
using VClients.Api.DTOs;
using VClients.Api.DTOs.Mappings;
using VClients.Api.Models;
using VClients.Api.Repositories.Interfaces;
using VClients.Api.Services;
using VClients.UnitTests.Fixtures;

namespace VClients.UnitTests.Systems.Services
{
    public class CustomerServiceTest
    {
        private CustomerService _service;
        private Mock<ICustomerRepository> _repository;
        private Mock<IMapper> _mapper;
        private IMapper realMapper;

        public CustomerServiceTest()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            realMapper = new Mapper(configuration);

            _mapper = new Mock<IMapper>();
            _repository = new Mock<ICustomerRepository>();
            _service = new CustomerService(_repository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetCustomers_OnSuccess_CallsCustomerRepository()
        {
            // Arrange
            // Act
            var actual = await _service.GetCustomers();

            // Assert
            _repository.Verify(repository => repository.GetAll(), Times.Once);

        }

        [Fact]
        public async Task GetCustomers_OnSuccess_ReturnsMappedCustomerDTO()
        {
            // Arrange
            var customers = CustomerFixture.GetTestCustomers();
            var expectedResponse = realMapper.Map<IEnumerable<CustomerDTO>>(customers);

            _repository.Setup(repository => repository.GetAll()).ReturnsAsync(customers);

            _mapper.Setup(mapper => mapper.Map<IEnumerable<CustomerDTO>>(customers))
                      .Returns(expectedResponse);

            // Act
            var actual = await _service.GetCustomers();

            // Assert
            _mapper.Verify(
                mapper => mapper.Map<IEnumerable<CustomerDTO>>(It.IsAny<IEnumerable<Customer>>()),
                Times.Once);

            actual.Should().BeOfType<List<CustomerDTO>>().And.BeSameAs(expectedResponse);
        }
    }
}
