using EcommerceAPI.Common.Classes.Contracts.Clientes;
using EcommerceAPI.Dominio.Services.Ecommerce.Clientes;
using EcommerceAPI.UnitTests.Fixtures;
using EcommerceAPI.UnitTests.Helpers;
using Moq;
using Moq.Protected;

namespace EcommerceAPI.UnitTests.Systems.Services
{
    public class TestClientesService
    {
        [Fact]
        public async Task GetAllClientes_WhenCalled_InvokesHttpGetRequest()
        {
            // Arrange
            var mockLoginService = new Mock<IClientesService>();
            var expectedResponse = ClientesFixture.GetTestClientes();
            var handlerMock = MockHttpMessageHandler<ClientesContract>.SetupBasicGetresourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            //var sut = new ClientesService(mockLoginService.Object,);
            // Act
            //await sut.GetAll();
            // Assert
            handlerMock.Protected().Verify("SendAsync", Times.Exactly(1), ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get), ItExpr.IsAny<CancellationToken>());

        }
    }
}
