using EcommerceAPI.Infraestructura.Database.Entities.Clientes;

namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.Authenticate
{
    public interface IAuthenticateRepository
    {
        Task<ClientesEntities> GetClientebyEmail(string email);
    }
}
