namespace EcommerceAPI.Common.Classes.Contracts.Clientes
{
    public class ClientesContract
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
        public string? password { get; set; } = string.Empty;
        public decimal telefono { get; set; }
        public string direccionfacturacion { get; set; } = string.Empty;
    }
}
