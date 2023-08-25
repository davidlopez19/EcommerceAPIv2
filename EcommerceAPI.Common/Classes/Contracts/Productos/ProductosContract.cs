namespace EcommerceAPI.Common.Classes.Contracts.Productos
{
    public class ProductosContract
    {
        public int id_producto { get; set; }
        public string descripcion { get; set; } = string.Empty;
        public float valor { get; set; }
        public string? imagen { get; set; } = string.Empty;
        public int id_estado { get; set; }
        public StockContract? Stock { get; set; }
    }
}
