namespace EcommerceAPI.Common.Classes.Contracts.Compras
{
    public class ComprasContract
    {
        public int id_compra { get; set; }
        public DateTime fecha { get; set; }
        public double valortotal { get; set; }
        public string direccionentrega { get; set; } = string.Empty;
        public int id_cliente { get; set; }
        public int id_estado { get; set; }
        public List<DetalleComprasContract> detalles { get; set; } = new List<DetalleComprasContract>();
    }
}
