using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities.Compras;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.Compras
{
    public class DetalleComprasRepository : ICrudRepository<DetalleComprasEntities>, IDetalleComprasRepository
    {
        private readonly ApplicationContext _context;
        public DetalleComprasRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<DetalleComprasEntities> Create(DetalleComprasEntities entity)
        {
            _context.DetalleCompras.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<DetalleComprasEntities>> GetAll()
        {
            return await _context.DetalleCompras.ToListAsync();
        }

        public async Task<DetalleComprasEntities> GetbyID(int id)
        {
            return await _context.DetalleCompras.FindAsync(id);
        }

        public async Task<DetalleComprasEntities> Update(DetalleComprasEntities entity)
        {
            _context.DetalleCompras.Add(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<List<DetalleComprasEntities>> GetDetallesCompra(int idCompra)
        {
            return await _context.DetalleCompras.Where(x => x.id_compra == idCompra).ToListAsync();
        }
    }
}
