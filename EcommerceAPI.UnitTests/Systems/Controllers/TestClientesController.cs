using EcommerceAPI.Common.Classes.Contracts.Clientes;
using EcommerceAPI.Controllers;
using EcommerceAPI.Dominio.Services.Ecommerce.Clientes;
using EcommerceAPI.UnitTests.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EcommerceAPI.UnitTests.Systems.Controllers
{
    public class TestClientesController
    {
        [Fact]
        public async Task Get_onSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var mockLoginService = new Mock<IClientesService>();
            var sut = new ClientesController(mockLoginService.Object);
            mockLoginService.Setup(service => service
                    .GetAll())
                  .ReturnsAsync(ClientesFixture.GetTestClientes());
            // Act
            var result = (OkObjectResult)await sut.Get();

            // Assert
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task Get_onSuccess_InvokesLoginServiceExactlyOnce()
        {
            //Arrange
            var mockLoginService = new Mock<IClientesService>();
            mockLoginService.Setup(service => service
                    .GetAll())
                    .ReturnsAsync(new List<ClientesContract>());

            var sut = new ClientesController(mockLoginService.Object);

            // Act
            var result = await sut.Get();

            // Assert
            mockLoginService.Verify(
                service => service.GetAll(),
                Times.Once()
            );
        }
        [Fact]
        public async Task Get_On_Success_ReturnsListOfClients()
        {
            //Arrange
            var mockLoginService = new Mock<IClientesService>();
            mockLoginService.Setup(service => service
                    .GetAll())
                    .ReturnsAsync(ClientesFixture.GetTestClientes());

            var sut = new ClientesController(mockLoginService.Object);

            //Act
            var result = await sut.Get();

            //Assert

            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<ClientesContract>>();
        }
        [Fact]
        public async Task Get_On_NoClientesFound_Returns404()
        {
            //Arrange
            var mockLoginService = new Mock<IClientesService>();
            mockLoginService.Setup(service => service
                    .GetAll())
                    .ReturnsAsync(new List<ClientesContract>());

            var sut = new ClientesController(mockLoginService.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }
    }
}
