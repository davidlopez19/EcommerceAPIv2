using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Clientes
{
    public interface IClientesService
    {
        List<ClienteContract> ObtenerClientes();
        ClienteContract ObtenerCliente(int id);
        ClienteContract Crear(ClienteContract contract);
        ClienteContract Update(ClienteContract contract);
        bool Delete(int id);
    }
}
