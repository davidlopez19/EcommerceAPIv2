using EcommerceAPI.Common.Classes.Contracts.Authenticate;

namespace EcommerceAPI.Dominio.Services.Ecommerce.Authenticate
{
    public interface IAuthenticateService
    {
        /// <summary>
        /// Metodo para login de clientes
        /// </summary>
        /// <param name="request">objeto con datos para login de cliente</param>
        /// <returns>Response con datos de token generado</returns>
        Task<LoginResponseContract> Login(LoginRequestContract request);
    }
}
