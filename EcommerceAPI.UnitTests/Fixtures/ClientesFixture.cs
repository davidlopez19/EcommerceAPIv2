using EcommerceAPI.Common.Classes.Contracts.Clientes;

namespace EcommerceAPI.UnitTests.Fixtures
{
    public static class ClientesFixture
    {
        public static List<ClientesContract> GetTestClientes() =>
            new()
            {
                new ClientesContract
                {
                     id_cliente = 1,
                        nombre="Pepito1",
                        correo="test@test.com",
                        telefono=1212312,
                        direccionfacturacion="Calle 18 main street"
                },
                new ClientesContract
                {
                     id_cliente = 2,
                        nombre="Pepito2",
                        correo="test@test.com",
                        telefono=1212312,
                        direccionfacturacion="Calle 18 main street"
                },
                new ClientesContract
                {
                     id_cliente = 3,
                        nombre="Pepito3",
                        correo="test@test.com",
                        telefono=1212312,
                        direccionfacturacion="Calle 18 main street"
                },
                new ClientesContract
                {
                     id_cliente = 4,
                        nombre="Pepito4",
                        correo="test@test.com",
                        telefono=1212312,
                        direccionfacturacion="Calle 18 main street"
                }
            };
    }
}
