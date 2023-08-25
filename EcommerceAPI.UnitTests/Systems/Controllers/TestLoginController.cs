using EcommerceAPI.Common.Classes.Contracts.Clientes;
using EcommerceAPI.Controllers;
using EcommerceAPI.Dominio.Services.Ecommerce.Clientes;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EcommerceAPI.UnitTests.Systems.Controllers;

public class TestLoginController
{
    [Fact]
    public async Task Get_onSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var mockLoginService = new Mock<IClientesService>();
        var sut = new ClientesController(mockLoginService.Object);
        mockLoginService.Setup(service => service
                .GetAll())
                .ReturnsAsync(new List<ClientesContract>()
                {
                    new()
                    {
                        id_cliente = 1,
                        nombre="Pepito",
                        correo="test@test.com",
                        telefono=1212312,
                        direccionfacturacion="Calle 18 main street"
                    }
                });
        // Act
        var result = (OkObjectResult)await sut.Get();

        // Assert
        result.StatusCode.Should().Be(200);
    }
}