using EcommerceAPI.Infraestructura.Database.Context;
using EcommerceAPI.Infraestructura.Database.Entities.Productos;
using EcommerceAPI.Infraestructura.ECommerce.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.Productos
{
    public class ProductosRepository : ICrudRepository<ProductosEntities>
    {
        private readonly ApplicationContext _context;

        public ProductosRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ProductosEntities> Create(ProductosEntities producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<List<ProductosEntities>> GetAll()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<ProductosEntities> GetbyID(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<StockEntities> GetStockbyProducto(int id)
        {
            return await _context.Stocks.FirstOrDefaultAsync(x => x.id_producto == id);
        }

        public async Task<ProductosEntities> Update(ProductosEntities producto)
        {
            _context.Productos.Add(producto);
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return producto;
        }
    }
}
