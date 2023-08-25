using EcommerceAPI.Common.Classes.Constans;
using EcommerceAPI.Common.Classes.Contracts.Authenticate;
using EcommerceAPI.Common.Classes.Contracts.Clientes;
using EcommerceAPI.Dominio.Services.Ecommerce.Clientes;
using EcommerceAPI.Infraestructura.Database.Entities.Clientes;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.Authenticate;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Authenticate
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IAuthenticateRepository _authenticateRepository;
        private readonly IClientesService _clientesService;
        private readonly IJWTService _jwtService;

        public AuthenticateService(IAuthenticateRepository authenticateRepository, IClientesService clientesService, IJWTService jwtService)
        {
            _authenticateRepository = authenticateRepository;
            _clientesService = clientesService;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseContract> Login(LoginRequestContract request)
        {
            if (await IsAuthenticated(request))
            {
                ClientesContract cliente = await _clientesService.GetByCorreo(request.Email);
                string token = _jwtService.GenerateJwtToken(cliente);
                return new LoginResponseContract(cliente, token);
            }
            else
            {
                throw new UnauthorizedAccessException(GeneralConstants.MSG_CLI_INCORRECTO);
            }
        }

        private async Task<bool> IsAuthenticated(LoginRequestContract request)
        {
            bool response = false;
            ClientesEntities clienteEntity = await _authenticateRepository.GetClientebyEmail(request.Email);
            if (clienteEntity != null)
            {
                response = clienteEntity.password == request.Password;
            }
            return response;
        }
    }
}
