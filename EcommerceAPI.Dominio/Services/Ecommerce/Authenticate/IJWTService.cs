using EcommerceAPI.Common.Classes.Contracts.Clientes;
using EcommerceAPI.Infraestructura.Database.Entities.Clientes;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Authenticate
{
    public interface IJWTService
    {
        public string GenerateJwtToken(ClientesContract cliente);
        public int? ValidationToken(string token);
    }
}
