using EcommerceAPI.Infraestructura.Database.Entities.Compras;

namespace EcommerceAPI.Infraestructura.ECommerce.Repositories.Compras
{
    public interface IDetalleComprasRepository
    {
        /// <summary>
        /// Obtiene lista de detalles de una compra
        /// </summary>
        /// <param name="idCompra">parametro de consulta</param>
        /// <returns>Lista de Detalles</returns>
        Task<List<DetalleComprasEntities>> GetDetallesCompra(int idCompra);
    }
}
