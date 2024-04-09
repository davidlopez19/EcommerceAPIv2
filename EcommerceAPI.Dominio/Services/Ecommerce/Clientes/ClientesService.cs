using AutoMapper;
using EcommerceAPI.Common.Classes.Contracts.Clientes;
using EcommerceAPI.Infraestructura.Database.Entities.Clientes;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.Clientes;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Clientes
{
    public interface IClientesService
    {
        /// <summary>
        /// Metodo para obtener lista de clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        Task<List<ClientesContract>> GetAll();

        /// <summary>
        /// Metodo para obtener cliente por su ID
        /// </summary>
        /// <param name="id">parametro de consulta</param>
        /// <returns>Cliente</returns>
        Task<ClientesContract> GetById(int id);

        /// <summary>
        /// Metodo para obtener cliente por su Email
        /// </summary>
        /// <param name="correo">parametro de consulta</param>
        /// <returns>Cliente</returns>
        Task<ClientesContract> GetByCorreo(string correo);

        /// <summary>
        /// Metodo para Crear Clientes en el sistema
        /// </summary>
        /// <param name="contract">Objeto con datos de cliente</param>
        /// <returns>Cliente creado en el sistema</returns>
        Task<ClientesContract> Create(ClientesContract contract);

        /// <summary>
        /// Metodo para actualizar Clientes
        /// </summary>
        /// <param name="contract">Objeto con datos de cliente actualizar</param>
        /// <returns>Cliente actualizado en el sistema</returns>
        Task<ClientesContract> Update(ClientesContract contract);


        Task<bool> Delete(int id);

    }

    public class ClientesService : IClientesService
    {
        private readonly IMapper _mapper;
        private readonly IClientesRepository _clientesRepository;

        public ClientesService(IMapper mapper, IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
            _mapper = mapper;
        }

        public async Task<ClientesContract> GetById(int id)
        {
            return _mapper.Map<ClientesContract>(await _clientesRepository.Get(id));
        }

        public async Task<List<ClientesContract>> GetAll()
        {
            return _mapper.Map<List<ClientesContract>>(await _clientesRepository.GetAll());
        }

        public async Task<ClientesContract> GetByCorreo(string correo)
        {
            return _mapper.Map<ClientesContract>(await _clientesRepository.GetByCorreo(correo));
        }

        public async Task<ClientesContract> Create(ClientesContract contract)
        {
            ClientesContract cliente = await GetByCorreo(contract.correo);
            if (cliente != null)
            {
                return cliente;
            }

            return _mapper.Map<ClientesContract>(await _clientesRepository.Create(_mapper.Map<ClientesEntities>(contract)));
        }

        public async Task<ClientesContract> Update(ClientesContract contract)
        {
            return _mapper.Map<ClientesContract>(await _clientesRepository.Update(_mapper.Map<ClientesEntities>(contract)));
        }


        public async Task<bool> Delete(int id)
        {
            return await _clientesRepository.Delete(id);
        }
    }
}
