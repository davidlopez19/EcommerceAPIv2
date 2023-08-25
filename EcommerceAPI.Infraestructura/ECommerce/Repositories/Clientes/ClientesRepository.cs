using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities.Authenticate;
using EcommerceAPI.Infraestructura.Database.Entities.Clientes;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.Clientes
{
    public class ClientesRepository : IClientesRepository
    {

        private readonly ApplicationContext _context;

        public ClientesRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ClientesEntities> Get(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<List<ClientesEntities>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<ClientesEntities> Create(ClientesEntities cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public Task<ClientesEntities> Login(LoginRequestEntities request)
        {
            throw new NotImplementedException();
        }

        public async Task<ClientesEntities> Update(ClientesEntities cliente)
        {
            _context.Clientes.Add(cliente);
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<ClientesEntities> GetByCorreo(string correo)
        {
            return await _context.Clientes.FirstOrDefaultAsync(x => x.correo.Trim().ToLower() == correo.Trim().ToLower());
        }
    }
}
