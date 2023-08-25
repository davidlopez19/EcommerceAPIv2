using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities.Productos;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.Productos
{
    public class StockRepository : ICrudRepository<StockEntities>, IStockRepository
    {
        private readonly ApplicationContext _context;

        public StockRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<StockEntities> Create(StockEntities entity)
        {
            _context.Stocks.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<StockEntities>> GetAll()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<StockEntities> GetbyID(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }


        public async Task<StockEntities> GetStockByProducto(int productoId)
        {
            return await _context.Stocks.FirstOrDefaultAsync(x => x.id_producto == productoId);
        }

        public async Task<StockEntities> Update(StockEntities entity)
        {
            _context.Stocks.Add(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
