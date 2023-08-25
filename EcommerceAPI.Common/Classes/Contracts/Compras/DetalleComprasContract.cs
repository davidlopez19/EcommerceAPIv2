using EcommerceAPI.Common.Classes.Contracts.Productos;

namespace EcommerceAPI.Common.Classes.Contracts.Compras
{
    public class DetalleComprasContract
    {
        public int id_detallecompra { get; set; }
        public int cantidad { get; set; }
        public double valorunitario { get; set; }
        public int id_compra { get; set; }
        public int id_producto { get; set; }
        public ProductosContract? Producto { get; set; }
    }
}
