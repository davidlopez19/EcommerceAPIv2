using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities.Clientes;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.Authenticate
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly ApplicationContext _context;
        public AuthenticateRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ClientesEntities> GetClientebyEmail(string email)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.correo.Trim().ToLower() == email.Trim().ToLower());
        }
    }
}
