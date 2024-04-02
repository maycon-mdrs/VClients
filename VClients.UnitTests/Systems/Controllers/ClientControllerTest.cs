using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VClients.Api.Controllers;
using VClients.Api.DTOs;
using VClients.Api.Services.Interfaces;
using VClients.UnitTests.Fixtures;

namespace VClients.UnitTests.Systems.Controllers;
public class ClientControllerTest
{
    private Mock<IClientService> _service;
    private ClientController _controller;

    public ClientControllerTest()
    {
        _service = new Mock<IClientService>();
        _controller = new ClientController(_service.Object);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {

        // Act
        var actionResult = await _controller.Get();
        var result = actionResult.Result as OkObjectResult;
        var actual = result as IEnumerable<ClientDto>;

        // Assert

        Assert.NotNull(result);
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_CallsUserServiceExactlyOnce()
    {
        // Arrange
        _service.Setup(service => service.GetClients()).ReturnsAsync(ClientFixture.GetTestClientDtos);

        // Act
        var actionResult = await _controller.Get();
        var result = actionResult.Result;
        var actual = result as IEnumerable<ClientDto>;

        // Assert

        Assert.NotNull(result);
        _service.Verify(service => service.GetClients(), Times.Once());
    }

    [Fact]
    public async Task Get_OnSucces_ReuturnsListOfClientFromService()
    {
        // Arrange
        var mockClientsDtoList = ClientFixture.GetTestClientDtos();
        _service.Setup(service => service.GetClients()).ReturnsAsync(mockClientsDtoList);

        // Act
        var actionResult = await _controller.Get();

        // Assert

        actionResult.Result.Should().BeOfType<OkObjectResult>();
        var result = actionResult.Result as OkObjectResult;
        Assert.NotNull(result);

        var actual = result.Value;
        actual.Should().BeOfType<List<ClientDto>>().And.BeSameAs(mockClientsDtoList);
    }

    [Fact]
    public async Task Get_OnNoUserFound_ReturnsStatusCode404()
    {
        // Arrange
        _service.Setup(service => service.GetClients()).ReturnsAsync(new List<ClientDto>());

        // Act
        var actionResult = await _controller.Get();

        // Assert

        actionResult.Result.Should().BeOfType<NotFoundObjectResult>();
        var result = actionResult.Result as NotFoundObjectResult;
        Assert.NotNull(result);
        result.StatusCode.Should().Be(404);
    }

}
