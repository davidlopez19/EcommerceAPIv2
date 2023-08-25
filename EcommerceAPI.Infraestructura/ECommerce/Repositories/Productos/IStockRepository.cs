using EcommerceAPI.Infraestructura.Database.Entities.Productos;

namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.Productos
{
    public interface IStockRepository
    {
        Task<StockEntities> Create(StockEntities entity);
        Task<StockEntities> Update(StockEntities entity);
        Task<StockEntities> GetStockByProducto(int productoId);
    }
}
