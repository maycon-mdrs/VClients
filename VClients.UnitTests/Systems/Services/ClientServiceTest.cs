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
    public class ClientServiceTest
    {
        private ClientService _service;
        private Mock<IClientRepository> _repository;
        private Mock<IMapper> _mapper;
        private IMapper realMapper;

        public ClientServiceTest()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            realMapper = new Mapper(configuration);

            _mapper = new Mock<IMapper>();
            _repository = new Mock<IClientRepository>();
            _service = new ClientService(_repository.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetClients_OnSuccess_CallsClientRepository()
        {
            // Arrange
            // Act
            var actual = await _service.GetClients();

            // Assert
            _repository.Verify(repository => repository.GetAll(), Times.Once);

        }

        [Fact]
        public async Task GetClients_OnSuccess_ReturnsMappedClientDto()
        {
            // Arrange
            var clients = ClientFixture.GetTestClients();
            var expectedResponse = realMapper.Map<IEnumerable<ClientDto>>(clients);

            _repository.Setup(repository => repository.GetAll()).ReturnsAsync(clients);

            _mapper.Setup(mapper => mapper.Map<IEnumerable<ClientDto>>(clients))
                      .Returns(expectedResponse);

            // Act
            var actual = await _service.GetClients();

            // Assert
            _mapper.Verify(
                mapper => mapper.Map<IEnumerable<ClientDto>>(It.IsAny<IEnumerable<Client>>()),
                Times.Once);

            actual.Should().BeOfType<List<ClientDto>>().And.BeSameAs(expectedResponse);
        }
    }
}
