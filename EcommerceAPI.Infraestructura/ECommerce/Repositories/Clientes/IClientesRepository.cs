using EcommerceAPI.Infraestructura.Database.Entities.Authenticate;
using EcommerceAPI.Infraestructura.Database.Entities.Clientes;

namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.Clientes
{
    public interface IClientesRepository
    {

        /// <summary>
        /// Obtiene la lista ade clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        Task<List<ClientesEntities>> GetAll();

        /// <summary>
        /// Metodo para consultar un cliente por su id
        /// </summary>
        /// <param name="id">parametro de consulta</param>
        /// <returns>Cliente</returns>
        Task<ClientesEntities> Get(int id);

        /// <summary>
        /// Metodo para obtener datos de cliente por correo
        /// </summary>
        /// <param name="correo">correo del cliente</param>
        /// <returns>cliente consultado</returns>
        Task<ClientesEntities> GetByCorreo(string correo);

        /// <summary>
        /// Metodo para crear Clientes
        /// </summary>
        /// <param name="entities">Objeto con datos para insertar cliente</param>
        /// <returns>Cliente insertado</returns>
        Task<ClientesEntities> Create(ClientesEntities entities);

        /// <summary>
        /// Metodo para actualizar los datos de un cliente
        /// </summary>
        /// <param name="entities">Objeto con datos para actualización</param>
        /// <returns>Objeto Cliente actualizado</returns>
        Task<ClientesEntities> Update(ClientesEntities entities);

        /// <summary>
        /// Metodo para eliminar un cliente
        /// </summary>
        /// <param name="id">Id de cliente</param>
        /// <returns>Si se elimino o no</returns>
        Task<bool> Delete(int id);

        /// <summary>
        /// Metodo de login para Cliente
        /// </summary>
        /// <param name="request">objeto con datos de usuario</param>
        /// <returns>Cliente logueado</returns>
        Task<ClientesEntities> Login(LoginRequestEntities request);


    }
}
