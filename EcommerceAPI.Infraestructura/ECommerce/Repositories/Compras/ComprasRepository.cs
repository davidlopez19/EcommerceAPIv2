using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities.Compras;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.Compras
{
    public class ComprasRepository : ICrudRepository<ComprasEntities>
    {
        private readonly ApplicationContext _context;
        public ComprasRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ComprasEntities> Create(ComprasEntities entity)
        {
            _context.Compras.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<ComprasEntities>> GetAll()
        {
            return await _context.Compras.ToListAsync();
        }

        public async Task<ComprasEntities> GetbyID(int id)
        {
            return await _context.Compras.FindAsync(id);
        }

        public async Task<ComprasEntities> Update(ComprasEntities entity)
        {
            _context.Compras.Add(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
