using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using VClients.Api.Controllers;
using VClients.Api.DTOs;
using VClients.Api.Services.Interfaces;
using VClients.UnitTests.Fixtures;

namespace VClients.UnitTests.Systems.Controllers;
public class CustomerControllerTest
{
    private Mock<ICustomerService> _service;
    private CustomerController _controller;

    public CustomerControllerTest()
    {
        _service = new Mock<ICustomerService>();
        _controller = new CustomerController(_service.Object);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        _service.Setup(service => service.GetCustomers()).ReturnsAsync(CustomerFixture.GetTestCustomerDTOs);

        // Act
        var actionResult = await _controller.Get();
        var result = actionResult.Result as OkObjectResult;
        var actual = result as IEnumerable<CustomerDTO>;

        // Assert
        Assert.NotNull(result);
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Get_OnSuccess_CallsUserServiceExactlyOnce()
    {
        // Arrange
        _service.Setup(service => service.GetCustomers()).ReturnsAsync(CustomerFixture.GetTestCustomerDTOs);

        // Act
        var actionResult = await _controller.Get();
        var result = actionResult.Result;
        var actual = result as IEnumerable<CustomerDTO>;

        // Assert

        Assert.NotNull(result);
        _service.Verify(service => service.GetCustomers(), Times.Once());
    }

    [Fact]
    public async Task Get_OnSucces_ReuturnsListOfCustomerFromService()
    {
        // Arrange
        var mockCustomersDtoList = CustomerFixture.GetTestCustomerDTOs();
        _service.Setup(service => service.GetCustomers()).ReturnsAsync(mockCustomersDtoList);

        // Act
        var actionResult = await _controller.Get();

        // Assert

        actionResult.Result.Should().BeOfType<OkObjectResult>();
        var result = actionResult.Result as OkObjectResult;
        Assert.NotNull(result);

        var actual = result.Value;
        actual.Should().BeOfType<List<CustomerDTO>>().And.BeSameAs(mockCustomersDtoList);
    }

    [Fact]
    public async Task Get_OnNoUserFound_ReturnsStatusCode404()
    {
        // Arrange
        _service.Setup(service => service.GetCustomers()).ReturnsAsync(new List<CustomerDTO>());

        // Act
        var actionResult = await _controller.Get();

        // Assert

        actionResult.Result.Should().BeOfType<NotFoundObjectResult>();
        var result = actionResult.Result as NotFoundObjectResult;
        Assert.NotNull(result);
        result.StatusCode.Should().Be(404);
    }

}
