using AutoMapper;
using EcommerceAPI.Comunes.Classes.Contracts.Ecommerce;
using EcommerceAPI.Dominio.Services.Encripcion;
using EcommerceAPI.Dominio.Services.JWT;
using EcommerceAPI.Infraestructura.Database.Entities;
using EcommerceAPI.Infraestructura.Repositorios.Clientes;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Clientes
{
    public class ClientesService : IClientesService
    {
        private readonly IClientesRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICryptoService _cryptoService;
        private readonly IJWTService _jWTService;

        public ClientesService(
            IClientesRepository clientesRepository,
            IMapper mapper,
            ICryptoService cryptoService,
            IJWTService jWTService
            )
        {
            _repository = clientesRepository;
            _mapper = mapper;
            _cryptoService = cryptoService;
            _jWTService = jWTService;
        }

        public ClienteContract Crear(ClienteContract contract)
        {
            ClienteEntity entity = _mapper.Map<ClienteEntity>(contract);
            string contrEncript = _cryptoService.Encript(contract.contrasena);
            entity.contrasena = contrEncript;
            ClienteEntity entityResultado = _repository.Crear(entity);

            ClienteContract response = _mapper.Map<ClienteContract>(entityResultado);
            return response;
        }

        public bool Delete(int id)
        {
            ClienteEntity cliente = _repository.ObtenerCliente(id);
            if (cliente != null)
            {
                _repository.Delete(cliente);
                return true;
            }
            return false;
        }

        public ClienteContract ObtenerCliente(int id)
        {
            return _mapper.Map<ClienteContract>(_repository.ObtenerCliente(id));
        }

        public List<ClienteContract> ObtenerClientes()
        {
            //string Token = _jWTService.GenerarToken();
            return _mapper.Map<List<ClienteContract>>(_repository.ObtenerClientes());
        }

        public ClienteContract Update(ClienteContract contract)
        {
            ClienteEntity entidad = _repository.ObtenerCliente(contract.Consecutivo);
            string passEncript = _cryptoService.Encript(contract.contrasena);
            if (entidad != null)
            {
                ClienteEntity entidadActualizar = _mapper.Map<ClienteEntity>(contract);

                if (entidad.contrasena != passEncript)
                    entidadActualizar.contrasena = passEncript;
                else
                    entidadActualizar.contrasena = entidad.contrasena;

                if (entidad.nombre != contract.nombre)
                    entidadActualizar.nombre = contract.nombre;
                else
                    entidadActualizar.nombre = entidad.nombre;

                return _mapper.Map<ClienteContract>(_repository.Update(entidadActualizar));
            }
            else
                return null;
        }
    }
}
